using UnityEngine;
using UnityEditor;
using UnityEngine.Tilemaps;
using System.Collections.Generic;

/// <summary>
/// Map Builder Pro – Công cụ build tilemap nâng cao.
/// Mở: Tools ▶ Map Builder Pro   hoặc   Ctrl+Shift+M
/// </summary>
public class MapBuilderEditorWindow : EditorWindow
{
    // ══════════════════════════════════════════════════════
    // ENUMS
    // ══════════════════════════════════════════════════════
    private enum ActiveTab  { Paint, Stamp, Sheet, Templates, Prefabs }
    private enum PaintTool  { Pencil, BoxFill, Line, Erase, Fill, Eyedropper }

    // ══════════════════════════════════════════════════════
    // CORE STATE
    // ══════════════════════════════════════════════════════
    private ActiveTab _tab  = ActiveTab.Sheet;   // mặc định mở Sheet tab
    private PaintTool _tool = PaintTool.Pencil;

    // Tilemaps
    private Tilemap[] _tilemaps     = new Tilemap[0];
    private string[]  _tilemapNames = new string[0];
    private int       _activeTmIdx  = 0;
    private Tilemap ActiveTM => _tilemaps != null && _activeTmIdx < _tilemaps.Length
                                 ? _tilemaps[_activeTmIdx] : null;

    // Tile Palette (Paint tab)
    private TileBase[]  _tiles        = new TileBase[0];
    private Texture2D[] _tilePreviews = new Texture2D[0];
    private string      _tilesFolder  = "Assets/Tiles";
    private int         _selTileIdx   = -1;
    private Vector2     _palScroll;
    private int         _palCols      = 5;
    private int         _previewSize  = 52;

    // Scene Painting
    private bool       _sceneActive = false;
    private Vector3Int _boxStart;
    private bool       _isDragging  = false;
    private bool       _linePhase2  = false;

    // ══════════════════════════════════════════════════════
    // SHEET VIEWER STATE  ← tính năng mới chính
    // ══════════════════════════════════════════════════════
    private Texture2D  _sheetTex;
    private int        _sheetTileW     = 32;
    private int        _sheetTileH     = 32;
    private float      _sheetZoom      = 2f;
    private Vector2    _sheetScroll;
    private Vector2Int _sheetSelA      = new Vector2Int(-1, -1);
    private Vector2Int _sheetSelB      = new Vector2Int(-1, -1);
    private bool       _sheetDragging  = false;
    private string     _sheetStampName = "New Stamp";
    private Vector2Int _sheetHover     = new Vector2Int(-1, -1);

    // Stamp Placement Pivot & Offset
    private int        _stampPivot     = 5; // Mặc định là Center (phím số 5)
    private Vector2Int _stampKeyOffset = Vector2Int.zero;

    // Grid-position → TileBase lookup (built by ScanSheet)
    private Dictionary<Vector2Int, TileBase> _sheetMap
        = new Dictionary<Vector2Int, TileBase>();

    // (unused field removed for compatibility)

    // ── Stamp ─────────────────────────────────────────────
    [System.Serializable]
    private class Stamp
    {
        public string   name;
        public int      width, height;
        public string[] guids;
        public Stamp(string n, int w, int h)
        { name = n; width = w; height = h; guids = new string[w * h]; }
    }
    private List<Stamp> _stamps       = new List<Stamp>();
    private int         _selStampIdx  = -1;
    private int         _editStampW   = 3;
    private int         _editStampH   = 2;
    private string      _newStampName = "New Stamp";
    private TileBase[]  _stampEdit;
    private Vector2     _stampScroll;

    // ── Templates ─────────────────────────────────────────
    private Vector2Int _tmplPos    = Vector2Int.zero;
    private int        _tmplWidth  = 10;
    private int        _tmplHeight = 5;

    // ── Prefabs ───────────────────────────────────────────
    private GameObject[] _prefabs       = new GameObject[0];
    private int          _selPrefabIdx  = -1;
    private string       _prefabsFolder = "Assets/Prefabs";
    private bool         _snapToGrid    = true;
    private float        _gridSnap      = 1f;
    private Vector2      _prefabScroll;

    // ── Visual ────────────────────────────────────────────
    private bool  _showGrid  = true;
    private Color _gridColor = new Color(0.3f, 0.9f, 1f, 0.20f);
    private Vector2 _mainScroll;

    // ── Styles ────────────────────────────────────────────
    private bool     _stylesReady;
    private GUIStyle _titleStyle, _sectionStyle;

    // ══════════════════════════════════════════════════════
    [MenuItem("Tools/Map Builder Pro %#m")]
    public static void Open()
    {
        var w = GetWindow<MapBuilderEditorWindow>("🗺 Map Builder Pro");
        w.minSize = new Vector2(460, 560);
        w.Show();
    }

    private void OnEnable()
    {
        SceneView.duringSceneGui += OnSceneGUI;
        RefreshTilemaps();
        LoadTiles();
        LoadPrefabs();
    }
    private void OnDisable() => SceneView.duringSceneGui -= OnSceneGUI;

    // ══════════════════════════════════════════════════════
    // MAIN GUI
    // ══════════════════════════════════════════════════════
    private void OnGUI()
    {
        InitStyles();
        DrawHeader();

        // 5 tabs
        string[] tabLabels = { "🖊 Paint", "🧩 Stamp", "📸 Sheet", "🏗 Templates", "📦 Prefabs" };
        _tab = (ActiveTab)GUILayout.Toolbar((int)_tab, tabLabels, GUILayout.Height(27));
        EditorGUILayout.Space(4);

        _mainScroll = EditorGUILayout.BeginScrollView(_mainScroll);
        switch (_tab)
        {
            case ActiveTab.Paint:     DrawPaintTab();     break;
            case ActiveTab.Stamp:     DrawStampTab();     break;
            case ActiveTab.Sheet:     DrawSheetTab();     break;
            case ActiveTab.Templates: DrawTemplatesTab(); break;
            case ActiveTab.Prefabs:   DrawPrefabsTab();   break;
        }
        EditorGUILayout.EndScrollView();

        DrawStatusBar();
    }

    // ══════════════════════════════════════════════════════
    // HEADER
    // ══════════════════════════════════════════════════════
    private void DrawHeader()
    {
        var r = EditorGUILayout.GetControlRect(false, 38);
        EditorGUI.DrawRect(r, new Color(0.12f, 0.14f, 0.20f));
        GUI.Label(r, "  ⚒  Map Builder Pro", _titleStyle);
        var btnR = new Rect(r.xMax - 148, r.y + 8, 142, 22);
        Color old = GUI.backgroundColor;
        GUI.backgroundColor = _sceneActive ? new Color(0.2f, 0.85f, 0.3f) : new Color(0.35f, 0.35f, 0.40f);
        bool tog = GUI.Toggle(btnR, _sceneActive,
            _sceneActive ? "🟢  Scene Paint: ON" : "⚪  Scene Paint: OFF", "Button");
        GUI.backgroundColor = old;
        if (tog != _sceneActive) { _sceneActive = tog; SceneView.RepaintAll(); }
    }

    private void DrawStatusBar()
    {
        EditorGUILayout.Space(2);
        var r = EditorGUILayout.GetControlRect(false, 1);
        EditorGUI.DrawRect(r, new Color(0.4f, 0.4f, 0.4f, 0.5f));
        using (new EditorGUILayout.HorizontalScope())
        {
            string tm = ActiveTM != null ? $"Tilemap: {ActiveTM.name}" : "⚠ Chưa chọn Tilemap";
            string sel = _selStampIdx >= 0 && _selStampIdx < _stamps.Count
                ? $"Stamp: {_stamps[_selStampIdx].name}"
                : (_selTileIdx >= 0 && _selTileIdx < _tiles.Length ? $"Tile: {_tiles[_selTileIdx].name}" : "—");
            GUILayout.Label(tm, EditorStyles.miniLabel);
            GUILayout.FlexibleSpace();
            GUILayout.Label(sel, EditorStyles.miniLabel);
        }
    }

    // ══════════════════════════════════════════════════════
    // TAB: SHEET VIEWER  (tính năng mới)
    // ══════════════════════════════════════════════════════
    private void DrawSheetTab()
    {
        // ── Hướng dẫn ─────────────────────────────────────
        EditorGUILayout.HelpBox(
            "Kéo sprite sheet vào ô bên dưới → Grid tự động hiện ra.\n" +
            "Kéo chuột trên hình để CHỌN VÙNG (ví dụ: cánh cửa 2×3 tile).\n" +
            "Sau đó: Đặt vào Map  hoặc  Lưu thành Stamp để dùng lại.",
            MessageType.Info);

        // ── Target Tilemap ─────────────────────────────────
        Section("🗺  Target Tilemap", DrawTilemapSelectorMini);

        // ── Sprite Sheet Loader ────────────────────────────
        Section("🖼  Sprite Sheet", () =>
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                var newTex = (Texture2D)EditorGUILayout.ObjectField(
                    "Texture", _sheetTex, typeof(Texture2D), false);
                if (newTex != _sheetTex) { _sheetTex = newTex; _sheetMap.Clear(); }
                if (GUILayout.Button("Scan Tiles", GUILayout.Width(80))) ScanSheetTiles();
            }

            using (new EditorGUILayout.HorizontalScope())
            {
                _sheetTileW = EditorGUILayout.IntField("Tile W (px)", _sheetTileW);
                _sheetTileH = EditorGUILayout.IntField("Tile H (px)", _sheetTileH);
                if (GUILayout.Button("Re-Scan", GUILayout.Width(60))) ScanSheetTiles();
            }

            _sheetZoom = EditorGUILayout.Slider("Zoom", _sheetZoom, 0.5f, 5f);

            // Quick-load buttons cho sprite sheets trong dự án
            EditorGUILayout.Space(2);
            EditorGUILayout.LabelField("Load nhanh:", EditorStyles.boldLabel);
            DrawQuickSheetButtons();
        });

        if (_sheetTex == null)
        {
            EditorGUILayout.HelpBox("👆 Chọn sprite sheet ở trên để bắt đầu.", MessageType.None);
            return;
        }

        // ── Sheet Info ─────────────────────────────────────
        int cols = Mathf.Max(1, _sheetTex.width  / _sheetTileW);
        int rows = Mathf.Max(1, _sheetTex.height / _sheetTileH);
        EditorGUILayout.LabelField(
            $"Sheet: {_sheetTex.width}×{_sheetTex.height}px  |  " +
            $"Grid: {cols}×{rows} tiles  |  Mapped: {_sheetMap.Count} TileBases",
            EditorStyles.miniLabel);

        if (_sheetMap.Count == 0)
        {
            GUI.backgroundColor = new Color(1f, 0.8f, 0.2f);
            if (GUILayout.Button("⚠  Nhấn SCAN TILES để map tiles với sheet này", GUILayout.Height(28)))
                ScanSheetTiles();
            GUI.backgroundColor = Color.white;
        }

        // ── Sheet Preview (drag-to-select) ─────────────────
        Section("🎨  Kéo để chọn vùng", () => DrawSheetPreview(cols, rows));

        // ── Selection Info + Actions ───────────────────────
        DrawSheetSelectionPanel(cols, rows);
    }

    // ── Quick sheet loader buttons ─────────────────────────
    private void DrawQuickSheetButtons()
    {
        // Tìm các texture phổ biến trong dự án
        var knownPaths = new[]
        {
            ("Assets/Art/Sprites/Map/Dungeon Tile Set.png",   "Dungeon Tile Set"),
            ("Assets/Art/Sprites/Map/Terrain (32x32).png",    "Terrain 32×32"),
            ("Assets/Art/Sprites/Map/Decorations (32x32).png","Decorations 32×32"),
            ("Assets/Art/Sprites/Map/Dungeon Tile Set 1.png", "Dungeon Set 1"),
        };

        int btnPerRow = 2;
        for (int i = 0; i < knownPaths.Length; i += btnPerRow)
        {
            using (new EditorGUILayout.HorizontalScope())
            {
                for (int j = i; j < System.Math.Min(i + btnPerRow, knownPaths.Length); j++)
                {
                    int lj = j;
                    if (GUILayout.Button(knownPaths[lj].Item2, GUILayout.Height(24)))
                    {
                        var tex = AssetDatabase.LoadAssetAtPath<Texture2D>(knownPaths[lj].Item1);
                        if (tex != null) { _sheetTex = tex; _sheetMap.Clear(); ScanSheetTiles(); }
                        else EditorUtility.DisplayDialog("Không tìm thấy",
                            $"Không có file tại:\n{knownPaths[lj].Item1}", "OK");
                    }
                }
            }
        }
    }

    // ── Sheet Preview with grid + drag-select ──────────────
    private void DrawSheetPreview(int cols, int rows)
    {
        float dispW  = _sheetTex.width  * _sheetZoom;
        float dispH  = _sheetTex.height * _sheetZoom;
        float cellW  = _sheetTileW * _sheetZoom;
        float cellH  = _sheetTileH * _sheetZoom;
        float viewH  = Mathf.Clamp(dispH + 6, 120, 480);

        _sheetScroll = EditorGUILayout.BeginScrollView(_sheetScroll, false, false, GUILayout.Height(viewH));

        // Reserve rect for the sheet with explicit width and height options to prevent layout squishing
        Rect pr = GUILayoutUtility.GetRect(dispW, dispH, GUILayout.Width(dispW), GUILayout.Height(dispH));

        // Draw texture
        GUI.DrawTexture(pr, _sheetTex, ScaleMode.StretchToFill);

        // ── Draw grid lines ────────────────────────────────
        Color gridCol = new Color(0f, 0.8f, 1f, 0.35f);
        for (int x = 0; x <= cols; x++)
            EditorGUI.DrawRect(new Rect(pr.x + x * cellW - 0.5f, pr.y, 1, dispH), gridCol);
        for (int y = 0; y <= rows; y++)
            EditorGUI.DrawRect(new Rect(pr.x, pr.y + y * cellH - 0.5f, dispW, 1), gridCol);

        // ── Draw hover highlight ───────────────────────────
        if (_sheetHover.x >= 0)
        {
            var hr = TileRect(pr, _sheetHover.x, _sheetHover.y, cellW, cellH);
            EditorGUI.DrawRect(hr, new Color(1f, 1f, 0.3f, 0.25f));
        }

        // ── Draw selection highlight ───────────────────────
        if (_sheetSelA.x >= 0 && _sheetSelB.x >= 0)
        {
            int x0 = Mathf.Min(_sheetSelA.x, _sheetSelB.x);
            int y0 = Mathf.Min(_sheetSelA.y, _sheetSelB.y);
            int x1 = Mathf.Max(_sheetSelA.x, _sheetSelB.x);
            int y1 = Mathf.Max(_sheetSelA.y, _sheetSelB.y);

            var selR = new Rect(
                pr.x + x0 * cellW,
                pr.y + y0 * cellH,
                (x1 - x0 + 1) * cellW,
                (y1 - y0 + 1) * cellH);

            EditorGUI.DrawRect(selR, new Color(0.2f, 0.55f, 1f, 0.35f));

            // Border
            float b = 2f;
            EditorGUI.DrawRect(new Rect(selR.x, selR.y, selR.width, b),           new Color(0.3f, 0.7f, 1f));
            EditorGUI.DrawRect(new Rect(selR.x, selR.yMax - b, selR.width, b),     new Color(0.3f, 0.7f, 1f));
            EditorGUI.DrawRect(new Rect(selR.x, selR.y, b, selR.height),           new Color(0.3f, 0.7f, 1f));
            EditorGUI.DrawRect(new Rect(selR.xMax - b, selR.y, b, selR.height),    new Color(0.3f, 0.7f, 1f));

            // Size label inside selection
            GUI.color = Color.white;
            GUI.Label(new Rect(selR.x + 4, selR.y + 2, selR.width, 18),
                $"{x1 - x0 + 1}×{y1 - y0 + 1}", EditorStyles.boldLabel);
        }

        // ── Draw "has tile" dots ───────────────────────────
        foreach (var kv in _sheetMap)
        {
            var dot = new Rect(
                pr.x + kv.Key.x * cellW + cellW - 8,
                pr.y + kv.Key.y * cellH + 2,
                6, 6);
            EditorGUI.DrawRect(dot, new Color(0.2f, 1f, 0.4f, 0.85f));
        }

        // ── Mouse input ───────────────────────────────────
        var e = Event.current;
        if (pr.Contains(e.mousePosition))
        {
            float lx = e.mousePosition.x - pr.x;
            float ly = e.mousePosition.y - pr.y;
            int col = Mathf.Clamp(Mathf.FloorToInt(lx / cellW), 0, cols - 1);
            int row = Mathf.Clamp(Mathf.FloorToInt(ly / cellH), 0, rows - 1);
            _sheetHover = new Vector2Int(col, row);

            // Tooltip with tile name
            if (_sheetMap.TryGetValue(_sheetHover, out var hTile))
            {
                var tipR = new Rect(e.mousePosition.x + 12, e.mousePosition.y, 160, 18);
                GUI.Box(tipR, GUIContent.none);
                GUI.Label(tipR, hTile.name, EditorStyles.miniLabel);
            }

            if (e.type == EventType.MouseDown && e.button == 0)
            {
                _sheetSelA    = new Vector2Int(col, row);
                _sheetSelB    = new Vector2Int(col, row);
                _sheetDragging = true;
                e.Use();
            }
            else if (e.type == EventType.MouseDrag && _sheetDragging)
            {
                _sheetSelB = new Vector2Int(col, row);
                e.Use(); Repaint();
            }
            else if (e.type == EventType.MouseUp && e.button == 0)
            {
                _sheetSelB    = new Vector2Int(col, row);
                _sheetDragging = false;
                // Auto-name stamp from single tile
                if (_sheetMap.TryGetValue(_sheetSelA, out var t))
                    _sheetStampName = t.name.Replace("_" + GetTileIndex(t.name), "")
                                       .TrimEnd('_').Trim();
                e.Use(); Repaint();
            }

            // Repaint on hover
            if (e.type == EventType.MouseMove) { Repaint(); }
        }
        else _sheetHover = new Vector2Int(-1, -1);

        EditorGUILayout.EndScrollView();
    }

    // ── Selection actions panel ────────────────────────────
    private void DrawSheetSelectionPanel(int cols, int rows)
    {
        bool hasSelection = _sheetSelA.x >= 0 && _sheetSelB.x >= 0;

        if (!hasSelection)
        {
            EditorGUILayout.HelpBox("Kéo chuột trên hình để chọn vùng.", MessageType.None);
            return;
        }

        int x0 = Mathf.Min(_sheetSelA.x, _sheetSelB.x);
        int y0 = Mathf.Min(_sheetSelA.y, _sheetSelB.y);
        int x1 = Mathf.Max(_sheetSelA.x, _sheetSelB.x);
        int y1 = Mathf.Max(_sheetSelA.y, _sheetSelB.y);
        int selW = x1 - x0 + 1;
        int selH = y1 - y0 + 1;

        // Count matched tiles
        int matched = 0;
        for (int r = y0; r <= y1; r++)
            for (int c = x0; c <= x1; c++)
                if (_sheetMap.ContainsKey(new Vector2Int(c, r))) matched++;

        Section("✅  Vùng đang chọn", () =>
        {
            // Info
            using (new EditorGUILayout.HorizontalScope("box"))
            {
                using (new EditorGUILayout.VerticalScope())
                {
                    EditorGUILayout.LabelField($"Vùng:  ({x0},{y0}) → ({x1},{y1})", EditorStyles.boldLabel);
                    EditorGUILayout.LabelField($"Kích thước:  {selW} × {selH} tiles");
                    Color mc = matched == selW * selH ? new Color(0.3f,1f,0.4f) : new Color(1f,0.6f,0.2f);
                    GUI.color = mc;
                    EditorGUILayout.LabelField($"TileBase tìm thấy:  {matched} / {selW * selH}");
                    GUI.color = Color.white;
                }

                // Mini preview
                var previewRect = GUILayoutUtility.GetRect(selW * 20f, selH * 20f,
                    GUILayout.Width(selW * 20f), GUILayout.Height(selH * 20f));

                if (_sheetTex != null)
                {
                    float tw = _sheetTileW * selW, th = _sheetTileH * selH;
                    float u0 = (float)(x0 * _sheetTileW) / _sheetTex.width;
                    float v0 = 1f - (float)((y1 + 1) * _sheetTileH) / _sheetTex.height;
                    float u1 = (float)((x1 + 1) * _sheetTileW) / _sheetTex.width;
                    float v1 = 1f - (float)(y0 * _sheetTileH) / _sheetTex.height;
                    GUI.DrawTextureWithTexCoords(previewRect, _sheetTex, new Rect(u0, v0, u1 - u0, v1 - v0));
                    // border
                    EditorGUI.DrawRect(new Rect(previewRect.x, previewRect.y, previewRect.width, 1), Color.cyan);
                    EditorGUI.DrawRect(new Rect(previewRect.x, previewRect.yMax-1, previewRect.width, 1), Color.cyan);
                    EditorGUI.DrawRect(new Rect(previewRect.x, previewRect.y, 1, previewRect.height), Color.cyan);
                    EditorGUI.DrawRect(new Rect(previewRect.xMax-1, previewRect.y, 1, previewRect.height), Color.cyan);
                }
            }

            EditorGUILayout.Space(4);

            // Action buttons
            if (matched == 0)
            {
                EditorGUILayout.HelpBox(
                    "Không tìm thấy TileBase nào trong vùng này.\n" +
                    "→ Nhấn Scan Tiles hoặc load thư mục Tiles trước.", MessageType.Warning);
                return;
            }

            // 1. Đặt bằng chuột (Khuyên dùng)
            EditorGUILayout.LabelField("👉 Đặt linh hoạt bằng Chuột (Khuyên dùng):", EditorStyles.boldLabel);
            GUI.backgroundColor = new Color(0.25f, 0.85f, 0.45f);
            if (GUILayout.Button("🖱️  Bật chế độ Kéo Thả & Đặt bằng Chuột (Di chuyển linh hoạt)", GUILayout.Height(36)))
            {
                SaveSheetSelectionAsStamp(x0, y0, x1, y1);
                _selStampIdx = _stamps.Count - 1;
                _sceneActive = true;
                _tool = PaintTool.Pencil;
                _selTileIdx = -1;
                _stampPivot = 5; // Mặc định Center cho linh hoạt khi kéo thả
                _stampKeyOffset = Vector2Int.zero;
                SceneView.RepaintAll();
            }
            GUI.backgroundColor = Color.white;
            EditorGUILayout.HelpBox("Di chuột trên Scene để đặt. Nhấn phím 1-9 để đổi Tâm (Pivot), phím Mũi tên/WASD để dịch chuyển.", MessageType.Info);

            EditorGUILayout.Space(6);

            // 2. Đặt nhanh cố định
            EditorGUILayout.LabelField("📍 Đặt nhanh tại vị trí cố định:", EditorStyles.boldLabel);
            using (new EditorGUILayout.HorizontalScope())
            {
                GUI.backgroundColor = new Color(0.25f, 0.65f, 1f);
                if (GUILayout.Button($"🎯  Đặt tại (0,0)", GUILayout.Height(28)))
                    PlaceSheetSelection(x0, y0, x1, y1, Vector3Int.zero);
                if (GUILayout.Button("🖥️  Đặt giữa màn hình Scene", GUILayout.Height(28)))
                    PlaceSheetSelectionAtSceneCenter(x0, y0, x1, y1);
                GUI.backgroundColor = Color.white;
            }

            EditorGUILayout.Space(6);

            // 3. Lưu thành Stamp
            EditorGUILayout.LabelField("💾 Lưu thành Stamp để dùng lâu dài:", EditorStyles.boldLabel);
            using (new EditorGUILayout.HorizontalScope())
            {
                _sheetStampName = EditorGUILayout.TextField("Tên Stamp", _sheetStampName);
                GUI.backgroundColor = new Color(1f, 0.75f, 0.2f);
                if (GUILayout.Button($"Lưu Stamp", GUILayout.Width(100), GUILayout.Height(20)))
                    SaveSheetSelectionAsStamp(x0, y0, x1, y1);
                GUI.backgroundColor = Color.white;
            }
        });
    }

    // ── Scan: map sprite positions → TileBase ─────────────
    private void ScanSheetTiles()
    {
        _sheetMap.Clear();
        if (_sheetTex == null || _sheetTileW <= 0 || _sheetTileH <= 0) return;

        string texPath = AssetDatabase.GetAssetPath(_sheetTex);

        // Load all sprites embedded in this texture
        var allAssets = AssetDatabase.LoadAllAssetsAtPath(texPath);
        var sprites   = new Dictionary<string, Sprite>();
        foreach (var a in allAssets)
            if (a is Sprite s) sprites[s.name] = s;

        if (sprites.Count == 0)
        {
            // Also try loading tiles that reference sprites from this texture
            Debug.LogWarning($"[MapBuilder] Không tìm thấy sprite nào trong '{texPath}'. " +
                             "Đảm bảo texture đã được slice (Sprite Mode = Multiple).");
        }

        int totalRows = _sheetTex.height / _sheetTileH;

        // Build position map from sprites
        foreach (var kvp in sprites)
        {
            var sp  = kvp.Value;
            var r   = sp.textureRect;
            // textureRect.y is from bottom of texture; convert to visual row from top
            int col  = Mathf.FloorToInt(r.x / _sheetTileW);
            int rowFromBottom = Mathf.FloorToInt(r.y / _sheetTileH);
            int rowFromTop    = totalRows - 1 - rowFromBottom;
            var gridPos = new Vector2Int(col, rowFromTop);

            // Find matching TileBase in _tiles array
            bool found = false;
            foreach (var tile in _tiles)
            {
                if (tile == null) continue;
                Sprite tileSprite = null;
                if (tile is Tile t)
                {
                    tileSprite = t.sprite;
                }
                else
                {
                    var prop = tile.GetType().GetProperty("sprite");
                    if (prop != null) tileSprite = prop.GetValue(tile) as Sprite;
                }

                if (tileSprite == sp)
                {
                    _sheetMap[gridPos] = tile;
                    found = true;
                    break;
                }

                string cleanTileName = System.Text.RegularExpressions.Regex.Replace(tile.name, @"\s+\d+$", "").Trim();
                if (cleanTileName.Equals(sp.name, System.StringComparison.OrdinalIgnoreCase))
                {
                    _sheetMap[gridPos] = tile;
                    found = true;
                    break;
                }
            }

            // Fallback: search entire project for this sprite
            if (!found)
            {
                var tileGuids = AssetDatabase.FindAssets("t:TileBase");
                foreach (var g in tileGuids)
                {
                    var tilePath = AssetDatabase.GUIDToAssetPath(g);
                    var tile = AssetDatabase.LoadAssetAtPath<TileBase>(tilePath);
                    if (tile == null) continue;

                    Sprite tileSprite = null;
                    if (tile is Tile t2)
                    {
                        tileSprite = t2.sprite;
                    }
                    else
                    {
                        var prop = tile.GetType().GetProperty("sprite");
                        if (prop != null) tileSprite = prop.GetValue(tile) as Sprite;
                    }

                    if (tileSprite == sp)
                    {
                        _sheetMap[gridPos] = tile;
                        found = true;
                        break;
                    }

                    string cleanTileName = System.Text.RegularExpressions.Regex.Replace(tile.name, @"\s+\d+$", "").Trim();
                    if (cleanTileName.Equals(sp.name, System.StringComparison.OrdinalIgnoreCase))
                    {
                        _sheetMap[gridPos] = tile;
                        found = true;
                        break;
                    }
                }
            }
        }

        Debug.Log($"[MapBuilder] Scan xong: {_sheetMap.Count}/{sprites.Count} tile mapped từ '{_sheetTex.name}'.");
        Repaint();
    }

    // ── Place selection directly ───────────────────────────
    private void PlaceSheetSelection(int x0, int y0, int x1, int y1, Vector3Int origin)
    {
        if (ActiveTM == null) { ShowErr("Chọn Tilemap!"); return; }
        Undo.RecordObject(ActiveTM, "Place Sheet Selection");
        int placed = 0;
        for (int r = y0; r <= y1; r++)
            for (int c = x0; c <= x1; c++)
            {
                if (!_sheetMap.TryGetValue(new Vector2Int(c, r), out var tile)) continue;
                // c,r in sheet → offset from top-left of selection
                // In tilemap: x increases right, y increases up
                // In sheet display: y increases down → nên flip y
                int tmX = origin.x + (c - x0);
                int tmY = origin.y - (r - y0);   // flip y
                ActiveTM.SetTile(new Vector3Int(tmX, tmY, 0), tile);
                placed++;
            }
        ActiveTM.RefreshAllTiles();
        EditorUtility.SetDirty(ActiveTM);
        Debug.Log($"[MapBuilder] Đặt {placed} tiles vào tilemap.");
    }

    private void PlaceSheetSelectionAtSceneCenter(int x0, int y0, int x1, int y1)
    {
        if (ActiveTM == null) { ShowErr("Chọn Tilemap!"); return; }
        Vector3 center = Vector3.zero;
        if (SceneView.lastActiveSceneView != null)
        {
            var p = SceneView.lastActiveSceneView.pivot;
            center = new Vector3(p.x, p.y, 0);
        }
        var originCell = ActiveTM.WorldToCell(center);
        PlaceSheetSelection(x0, y0, x1, y1, originCell);
    }

    // ── Save selection as Stamp ────────────────────────────
    private void SaveSheetSelectionAsStamp(int x0, int y0, int x1, int y1)
    {
        int selW = x1 - x0 + 1;
        int selH = y1 - y0 + 1;
        var stamp = new Stamp(_sheetStampName, selW, selH);

        for (int r = y0; r <= y1; r++)
            for (int c = x0; c <= x1; c++)
            {
                int stampCol = c - x0;
                int stampRow = r - y0;
                int si = stampRow * selW + stampCol;
                if (_sheetMap.TryGetValue(new Vector2Int(c, r), out var tile))
                    stamp.guids[si] = AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(tile));
            }

        _stamps.Add(stamp);
        Debug.Log($"[MapBuilder] Đã lưu stamp '{_sheetStampName}' {selW}×{selH}. Chuyển sang tab Stamp để dùng.");
    }

    // ── Tile rect helper ──────────────────────────────────
    private Rect TileRect(Rect pr, int col, int row, float cellW, float cellH)
        => new Rect(pr.x + col * cellW, pr.y + row * cellH, cellW, cellH);

    private string GetTileIndex(string name)
    {
        int last = name.LastIndexOf('_');
        return last >= 0 ? name.Substring(last + 1) : "";
    }

    // ══════════════════════════════════════════════════════
    // TAB: PAINT
    // ══════════════════════════════════════════════════════
    private void DrawPaintTab()
    {
        Section("🗺  Target Tilemap", DrawTilemapSelectorMini);

        Section("🔧  Tools", () =>
        {
            string[] tL = { "✏ Pencil", "▬ Box", "╱ Line", "◻ Erase", "💧 Fill", "👁 Pick" };
            string[] tH = {
                "Click / kéo để vẽ tile  (nếu đang chọn Stamp → vẽ cả stamp)\nChuột phải = xóa",
                "Kéo để tô hình chữ nhật – thả chuột để hoàn tất",
                "Click điểm 1 rồi click điểm 2 để vẽ đường thẳng",
                "Click / kéo để xóa tile",
                "Click để flood-fill toàn vùng kết nối bằng tile đang chọn",
                "Click tile trong scene → tự động chọn tile đó trong palette"
            };
            var tr = EditorGUILayout.GetControlRect(false, 30);
            float bw = tr.width / tL.Length;
            for (int i = 0; i < tL.Length; i++)
            {
                var br = new Rect(tr.x + i * bw, tr.y, bw, 30);
                GUI.backgroundColor = (int)_tool == i ? new Color(0.25f, 0.65f, 1f) : Color.white;
                if (GUI.Button(br, tL[i])) _tool = (PaintTool)i;
            }
            GUI.backgroundColor = Color.white;
            EditorGUILayout.HelpBox(tH[(int)_tool], MessageType.None);
        });

        Section("🎨  Tile Palette", DrawTilePalette);

        Section("⚙  Tiện ích", () =>
        {
            _showGrid = EditorGUILayout.Toggle("Hiển thị Grid trong Scene", _showGrid);
            if (_showGrid) _gridColor = EditorGUILayout.ColorField("Màu Grid", _gridColor);
            EditorGUILayout.Space(3);
            using (new EditorGUILayout.HorizontalScope())
            {
                if (GUILayout.Button("TilemapCollider2D",  GUILayout.Height(24))) AddTilemapCollider();
                if (GUILayout.Button("CompositeCollider2D", GUILayout.Height(24))) AddCompositeCollider();
            }
            if (GUILayout.Button("🗑  Xóa tất cả tile", GUILayout.Height(24))) ClearAllTiles();
        });
    }

    private void DrawTilePalette()
    {
        using (new EditorGUILayout.HorizontalScope())
        {
            _tilesFolder = EditorGUILayout.TextField(_tilesFolder);
            if (GUILayout.Button("Load", GUILayout.Width(50))) LoadTiles();
        }
        using (new EditorGUILayout.HorizontalScope())
        {
            GUILayout.Label($"{_tiles.Length} tiles", EditorStyles.miniLabel);
            GUILayout.FlexibleSpace();
            GUILayout.Label("Cột:", EditorStyles.miniLabel, GUILayout.Width(28));
            _palCols = EditorGUILayout.IntSlider(_palCols, 2, 9, GUILayout.Width(110));
            GUILayout.Label("Cỡ:", EditorStyles.miniLabel, GUILayout.Width(22));
            _previewSize = EditorGUILayout.IntSlider(_previewSize, 36, 80, GUILayout.Width(110));
        }

        if (_tiles.Length == 0)
        { EditorGUILayout.HelpBox("Nhấn Load để tải tiles.", MessageType.Warning); return; }

        float avail  = EditorGUIUtility.currentViewWidth - 26;
        float cellSz = Mathf.Floor(avail / _palCols);
        int   rows   = Mathf.CeilToInt((float)_tiles.Length / _palCols);
        float palH   = Mathf.Min(rows * cellSz, 280);

        _palScroll = EditorGUILayout.BeginScrollView(_palScroll, GUILayout.Height(palH));
        for (int row = 0; row < rows; row++)
            using (new EditorGUILayout.HorizontalScope())
                for (int col = 0; col < _palCols; col++)
                {
                    int idx = row * _palCols + col;
                    if (idx >= _tiles.Length) break;
                    bool sel = idx == _selTileIdx;
                    GUI.backgroundColor = sel ? new Color(0.25f, 0.65f, 1f) : new Color(0.22f, 0.22f, 0.26f);
                    Texture2D tx = idx < _tilePreviews.Length ? _tilePreviews[idx] : null;
                    GUIContent gc = tx != null ? new GUIContent(tx) : new GUIContent("T");
                    gc.tooltip = _tiles[idx]?.name;
                    if (GUILayout.Button(gc, GUILayout.Width(cellSz-2), GUILayout.Height(cellSz-2)))
                    { _selTileIdx = idx; _selStampIdx = -1; Repaint(); }
                    GUI.backgroundColor = Color.white;
                }
        EditorGUILayout.EndScrollView();

        if (_selTileIdx >= 0 && _selTileIdx < _tiles.Length)
            using (new EditorGUILayout.HorizontalScope("box"))
            {
                Texture2D tx = _selTileIdx < _tilePreviews.Length ? _tilePreviews[_selTileIdx] : null;
                if (tx != null) GUILayout.Label(tx, GUILayout.Width(40), GUILayout.Height(40));
                using (new EditorGUILayout.VerticalScope())
                {
                    GUILayout.Label(_tiles[_selTileIdx].name, EditorStyles.boldLabel);
                    if (GUILayout.Button("Ping", GUILayout.Width(60)))
                        EditorGUIUtility.PingObject(_tiles[_selTileIdx]);
                }
            }
    }

    // ══════════════════════════════════════════════════════
    // TAB: STAMP
    // ══════════════════════════════════════════════════════
    private void DrawStampTab()
    {
        EditorGUILayout.HelpBox(
            "Tạo Stamp thủ công theo ô.\n" +
            "Hoặc: Tab Sheet → kéo chọn vùng → 'Lưu thành Stamp' → stamp xuất hiện ở đây.",
            MessageType.Info);

        Section("✏  Tạo / Chỉnh sửa Stamp", DrawStampEditor);
        Section("💾  Stamps đã lưu", DrawSavedStamps);
    }

    private void DrawStampEditor()
    {
        using (new EditorGUILayout.HorizontalScope())
        { GUILayout.Label("Tên:", GUILayout.Width(32)); _newStampName = EditorGUILayout.TextField(_newStampName); }
        using (new EditorGUILayout.HorizontalScope())
        {
            int nw = EditorGUILayout.IntSlider("W", _editStampW, 1, 10);
            int nh = EditorGUILayout.IntSlider("H", _editStampH, 1, 8);
            if (nw != _editStampW || nh != _editStampH)
            { _editStampW = nw; _editStampH = nh; _stampEdit = new TileBase[_editStampW * _editStampH]; }
        }
        if (_stampEdit == null || _stampEdit.Length != _editStampW * _editStampH)
            _stampEdit = new TileBase[_editStampW * _editStampH];

        GUILayout.Label($"Lưới {_editStampW}×{_editStampH}  (click = gán tile, chuột phải = xóa)",
            EditorStyles.boldLabel);

        float avail  = EditorGUIUtility.currentViewWidth - 30f;
        float cellSz = Mathf.Min(avail / _editStampW, 62f);
        _stampScroll = EditorGUILayout.BeginScrollView(_stampScroll,
            GUILayout.Height(_editStampH * cellSz + 6));
        for (int y = _editStampH - 1; y >= 0; y--)
        {
            GUILayout.BeginHorizontal();
            for (int x = 0; x < _editStampW; x++)
            {
                int si   = y * _editStampW + x;
                var tile = _stampEdit[si];
                Texture2D tx = tile != null ? TilePreview(tile) : null;
                GUI.backgroundColor = tile != null ? new Color(0.4f, 0.82f, 0.5f) : new Color(0.26f, 0.26f, 0.30f);
                GUIContent gc = tx != null ? new GUIContent(tx, tile.name) : new GUIContent(tile != null ? "✓" : "+");
                var btnR = GUILayoutUtility.GetRect(cellSz-2, cellSz-2, GUILayout.Width(cellSz-2), GUILayout.Height(cellSz-2));
                if (GUI.Button(btnR, gc))
                {
                    if (Event.current.button == 1) _stampEdit[si] = null;
                    else if (_selTileIdx >= 0 && _selTileIdx < _tiles.Length)
                        _stampEdit[si] = _tiles[_selTileIdx];
                }
                GUI.backgroundColor = Color.white;
            }
            GUI.backgroundColor = new Color(0.75f, 0.25f, 0.25f);
            if (GUILayout.Button("✕", GUILayout.Width(20), GUILayout.Height(cellSz-2)))
                for (int x=0; x<_editStampW; x++) _stampEdit[y*_editStampW+x] = null;
            GUI.backgroundColor = Color.white;
            GUILayout.EndHorizontal();
        }
        EditorGUILayout.EndScrollView();

        using (new EditorGUILayout.HorizontalScope())
        {
            GUI.backgroundColor = new Color(0.25f, 0.85f, 0.45f);
            if (GUILayout.Button("💾  Lưu Stamp", GUILayout.Height(30))) SaveManualStamp();
            GUI.backgroundColor = new Color(0.85f, 0.45f, 0.20f);
            if (GUILayout.Button("🗑  Xóa lưới",   GUILayout.Height(30)))
                _stampEdit = new TileBase[_editStampW * _editStampH];
            GUI.backgroundColor = Color.white;
        }
    }

    private void DrawSavedStamps()
    {
        if (_stamps.Count == 0)
        { EditorGUILayout.HelpBox("Chưa có stamp. Tạo từ Sheet tab hoặc lưới ở trên.", MessageType.None); return; }
        for (int i = 0; i < _stamps.Count; i++)
        {
            var s = _stamps[i]; bool sel = i == _selStampIdx;
            GUI.backgroundColor = sel ? new Color(0.25f, 0.65f, 1f) : Color.white;
            using (new EditorGUILayout.HorizontalScope("box"))
            {
                GUI.backgroundColor = Color.white;
                if (GUILayout.Button($"【{s.width}×{s.height}】  {s.name}", GUILayout.Height(28)))
                { _selStampIdx = i; LoadStampToEditor(i); }
                GUI.backgroundColor = new Color(0.85f, 0.25f, 0.25f);
                if (GUILayout.Button("✕", GUILayout.Width(26), GUILayout.Height(28)))
                { _stamps.RemoveAt(i); if (_selStampIdx == i) _selStampIdx = -1; break; }
                GUI.backgroundColor = Color.white;
            }
        }
        if (_selStampIdx >= 0 && _selStampIdx < _stamps.Count)
        {
            GUI.backgroundColor = new Color(0.25f, 0.85f, 0.45f);
            if (GUILayout.Button($"\ud83d\udd0c  Dùng Stamp '{_stamps[_selStampIdx].name}' để vẽ", GUILayout.Height(30)))
            { 
                _sceneActive = true; 
                _tool = PaintTool.Pencil; 
                _selTileIdx = -1; 
                _stampPivot = 5; 
                _stampKeyOffset = Vector2Int.zero; 
                SceneView.RepaintAll(); 
            }
            GUI.backgroundColor = Color.white;
        }
    }

    // ══════════════════════════════════════════════════════
    // TAB: TEMPLATES
    // ══════════════════════════════════════════════════════
    private void DrawTemplatesTab()
    {
        Section("🗺  Tilemap", DrawTilemapSelectorMini);
        Section("🎨  Tile", () =>
        {
            if (_tiles.Length == 0) { GUILayout.Label("Load tile từ tab Paint."); return; }
            float cSz = 40f; int maxC = Mathf.FloorToInt((EditorGUIUtility.currentViewWidth-20)/cSz);
            int show = Mathf.Min(_tiles.Length, maxC * 3);
            for (int i=0; i<show; i+=maxC)
                using (new EditorGUILayout.HorizontalScope())
                    for (int j=i; j<Mathf.Min(i+maxC,show); j++)
                    {
                        bool sel = j==_selTileIdx;
                        GUI.backgroundColor = sel ? new Color(0.25f,0.65f,1f) : new Color(0.22f,0.22f,0.26f);
                        Texture2D tx = j < _tilePreviews.Length ? _tilePreviews[j] : null;
                        GUIContent gc = tx!=null ? new GUIContent(tx) : new GUIContent("T");
                        gc.tooltip = _tiles[j]?.name;
                        if (GUILayout.Button(gc, GUILayout.Width(cSz), GUILayout.Height(cSz))) _selTileIdx = j;
                        GUI.backgroundColor = Color.white;
                    }
            if (_selTileIdx>=0&&_selTileIdx<_tiles.Length)
                GUILayout.Label($"✓ {_tiles[_selTileIdx].name}", EditorStyles.miniLabel);
        });
        Section("📐  Kích thước", () =>
        {
            _tmplPos    = EditorGUILayout.Vector2IntField("Vị trí bắt đầu (tile)", _tmplPos);
            _tmplWidth  = EditorGUILayout.IntSlider("Rộng W",  _tmplWidth,  2, 40);
            _tmplHeight = EditorGUILayout.IntSlider("Cao  H",  _tmplHeight, 2, 20);
        });
        Section("🏗  Mẫu", () =>
        {
            var tpls = new (string lbl, System.Func<List<Vector2Int>> fn)[]
            {
                ("Platform ngang",        PlatformH),("Tường dọc",           PlatformV),
                ("Phòng rỗng (viền)",     RoomHollow),("Phòng đặc",           RoomSolid),
                ("Cầu thang → phải",      StairsRight),("Cầu thang ← trái",   StairsLeft),
                ("Platform + thành 2 bên",PlatformWalled),("Hành lang",       Corridor),
                ("Platform có hố",        PlatformGap),("Cột giữa",           CenterPillar),
                ("Zigzag",                Zigzag),("Cầu thang cuộn",          SpiralStairs),
            };
            for (int i=0; i<tpls.Length; i+=2)
                using (new EditorGUILayout.HorizontalScope())
                    for (int j=i; j<System.Math.Min(i+2,tpls.Length); j++)
                    { int lj=j; GUI.backgroundColor=new Color(0.22f,0.50f,0.85f);
                      if (GUILayout.Button(tpls[lj].lbl, GUILayout.Height(28))) PlacePositions(tpls[lj].fn());
                      GUI.backgroundColor=Color.white; }
        });
    }

    // ══════════════════════════════════════════════════════
    // TAB: PREFABS
    // ══════════════════════════════════════════════════════
    private void DrawPrefabsTab()
    {
        using (new EditorGUILayout.HorizontalScope())
        { _prefabsFolder = EditorGUILayout.TextField("Thư mục", _prefabsFolder);
          if (GUILayout.Button("Load",GUILayout.Width(50))) LoadPrefabs(); }
        _snapToGrid = EditorGUILayout.Toggle("Snap to Grid", _snapToGrid);
        if (_snapToGrid) _gridSnap = EditorGUILayout.Slider("Grid Size", _gridSnap, 0.25f, 4f);
        GUILayout.Label($"Prefabs ({_prefabs.Length}):", EditorStyles.boldLabel);
        _prefabScroll = EditorGUILayout.BeginScrollView(_prefabScroll, GUILayout.Height(200));
        for (int i=0; i<_prefabs.Length; i++)
        {
            if (_prefabs[i]==null) continue;
            GUI.backgroundColor = i==_selPrefabIdx ? new Color(0.25f,0.65f,1f) : Color.white;
            using (new EditorGUILayout.HorizontalScope("box"))
            {
                var prev = AssetPreview.GetAssetPreview(_prefabs[i]);
                GUILayout.Label(prev!=null?new GUIContent(prev):new GUIContent("📦"), GUILayout.Width(32),GUILayout.Height(32));
                if (GUILayout.Button(_prefabs[i].name, GUILayout.Height(32))) _selPrefabIdx=i;
                if (GUILayout.Button("Ping",GUILayout.Width(40),GUILayout.Height(32)))
                    EditorGUIUtility.PingObject(_prefabs[i]);
            }
            GUI.backgroundColor=Color.white;
        }
        EditorGUILayout.EndScrollView();
        if (_selPrefabIdx>=0&&_selPrefabIdx<_prefabs.Length)
        { GUI.backgroundColor=new Color(0.25f,0.85f,0.45f);
          if (GUILayout.Button($"\u2795  Đặt '{_prefabs[_selPrefabIdx].name}' vào Scene",GUILayout.Height(30)))
              PlacePrefab(); GUI.backgroundColor=Color.white; }
        Section("⚙  Tạo nhanh", () =>
        {
            using (new EditorGUILayout.HorizontalScope())
            { if (GUILayout.Button("➕ Moving Platform",GUILayout.Height(28))) MakeMovingPlatform();
              if (GUILayout.Button("☠ Hazard Zone",GUILayout.Height(28))) MakeHazardZone(); }
            using (new EditorGUILayout.HorizontalScope())
            { if (GUILayout.Button("💀 Fall Trap",GUILayout.Height(28))) MakeFallTrap();
              if (GUILayout.Button("🚪 Secret Trigger",GUILayout.Height(28))) MakeSecretTrigger(); }
        });
    }

    // ══════════════════════════════════════════════════════
    // SCENE GUI
    // ══════════════════════════════════════════════════════
    private void OnSceneGUI(SceneView sv)
    {
        if (_showGrid) DrawGrid(sv);
        if (!_sceneActive || ActiveTM == null) return;
        var e = Event.current;
        Vector2 mp = e.mousePosition; mp.y = sv.camera.pixelHeight - mp.y;
        var wp = sv.camera.ScreenToWorldPoint(new Vector3(mp.x, mp.y, 0f)); wp.z = 0f;
        var cell = ActiveTM.WorldToCell(wp);

        // Listen to keyboard shortcuts for stamp placement (pivot & arrow key offset fine-tuning)
        HandleKeyboardInput(e, sv);

        DrawCellHighlight(cell);
        bool erase = e.button == 1 || _tool == PaintTool.Erase;
        if (e.type == EventType.MouseDown && (e.button==0||e.button==1))
        {
            if (_tool==PaintTool.Line&&!_linePhase2) {_boxStart=cell;_linePhase2=true;}
            else if (_tool==PaintTool.BoxFill)       {_boxStart=cell;_isDragging=true;}
            else ApplyTool(cell,erase);
            e.Use();
        }
        else if (e.type==EventType.MouseDrag&&(e.button==0||e.button==1))
        { if (_tool==PaintTool.Pencil||_tool==PaintTool.Erase) ApplyTool(cell,erase); e.Use(); }
        else if (e.type==EventType.MouseUp&&(e.button==0||e.button==1))
        {
            if (_tool==PaintTool.BoxFill&&_isDragging)  {PaintBox(_boxStart,cell,erase?null:SelectedTile);_isDragging=false;}
            else if (_tool==PaintTool.Line&&_linePhase2) {PaintLine(_boxStart,cell,erase?null:SelectedTile);_linePhase2=false;}
            else if (_tool==PaintTool.Fill) FloodFill(cell,SelectedTile);
            e.Use();
        }
        if (e.type==EventType.Layout)
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));

        // Draw Scene View HUD card overlay
        Handles.BeginGUI();
        DrawSceneHUD(sv);
        Handles.EndGUI();

        sv.Repaint();
    }

    private void ApplyTool(Vector3Int cell, bool erase)
    {
        if (erase||_tool==PaintTool.Erase) {PaintCell(cell,null); return;}
        if (_tool==PaintTool.Eyedropper)   {PickTile(cell); return;}
        if (_tool==PaintTool.Pencil)
        {
            if (_selStampIdx>=0&&_selStampIdx<_stamps.Count) PaintStamp(cell,_stamps[_selStampIdx]);
            else PaintCell(cell,SelectedTile);
        }
    }

    private void DrawCellHighlight(Vector3Int cell)
    {
        if (ActiveTM==null) return;
        Color hc = _tool==PaintTool.Erase ? new Color(1f,0.2f,0.2f,0.45f) : new Color(0.3f,1f,0.4f,0.45f);
        var size = ActiveTM.cellSize;

        if (_selStampIdx>=0&&_selStampIdx<_stamps.Count&&_tool==PaintTool.Pencil)
        {
            var s=_stamps[_selStampIdx];
            GetStampPivotOffset(_stampPivot, s.width, s.height, out int dx, out int dy);
            int startX = cell.x + dx + _stampKeyOffset.x;
            int startY = cell.y + dy + _stampKeyOffset.y;
            for (int sy=0;sy<s.height;sy++) 
                for (int sx=0;sx<s.width;sx++)
                    DrawCellRect(new Vector3Int(startX+sx,startY-sy,0),
                        new Color(0.3f,0.8f,1f,0.18f),new Color(0.3f,0.8f,1f,0.7f));
        }
        else
        {
            DrawCellRect(cell, hc, new Color(hc.r,hc.g,hc.b,1f));
        }
        if (_tool==PaintTool.BoxFill&&_isDragging)
        {
            int x0=Mathf.Min(_boxStart.x,cell.x),x1=Mathf.Max(_boxStart.x,cell.x);
            int y0=Mathf.Min(_boxStart.y,cell.y),y1=Mathf.Max(_boxStart.y,cell.y);
            var wMin=ActiveTM.CellToWorld(new Vector3Int(x0,y0,0));
            var wMax=ActiveTM.CellToWorld(new Vector3Int(x1+1,y1+1,0));
            Handles.DrawSolidRectangleWithOutline(
                new[]{wMin,new Vector3(wMax.x,wMin.y),wMax,new Vector3(wMin.x,wMax.y)},
                new Color(0.3f,0.65f,1f,0.18f),new Color(0.3f,0.65f,1f,0.9f));
            Handles.Label(wMax+Vector3.up*0.25f,$"{x1-x0+1}×{y1-y0+1}");
        }
        if (_tool==PaintTool.Line&&_linePhase2)
        { var wA=ActiveTM.CellToWorld(_boxStart)+(Vector3)size*0.5f;
          var wB=ActiveTM.CellToWorld(cell)+(Vector3)size*0.5f;
          Handles.color=new Color(1f,0.8f,0.2f,0.9f); Handles.DrawDottedLine(wA,wB,4f); }
    }

    private void DrawCellRect(Vector3Int cell, Color fill, Color border)
    {
        var wm=ActiveTM.CellToWorld(cell); var size=ActiveTM.cellSize;
        Handles.DrawSolidRectangleWithOutline(
            new[]{wm,wm+new Vector3(size.x,0,0),wm+new Vector3(size.x,size.y,0),wm+new Vector3(0,size.y,0)},
            fill,border);
    }

    private void DrawGrid(SceneView sv)
    {
        if (!_showGrid) return;
        Handles.color=_gridColor;
        var pivot=sv.pivot; float ch=sv.camera.orthographicSize*2f; float cw=ch*sv.camera.aspect;
        int lim=80;
        int x0=Mathf.Max(Mathf.FloorToInt(pivot.x-cw)-1,Mathf.FloorToInt(pivot.x)-lim);
        int x1=Mathf.Min(Mathf.CeilToInt(pivot.x+cw)+1,Mathf.FloorToInt(pivot.x)+lim);
        int y0=Mathf.Max(Mathf.FloorToInt(pivot.y-ch)-1,Mathf.FloorToInt(pivot.y)-lim);
        int y1=Mathf.Min(Mathf.CeilToInt(pivot.y+ch)+1,Mathf.FloorToInt(pivot.y)+lim);
        for (int x=x0;x<=x1;x++) Handles.DrawLine(new Vector3(x,y0,0),new Vector3(x,y1,0));
        for (int y=y0;y<=y1;y++) Handles.DrawLine(new Vector3(x0,y,0),new Vector3(x1,y,0));
    }

    // ══════════════════════════════════════════════════════
    // PAINT OPS
    // ══════════════════════════════════════════════════════
    private void PaintCell(Vector3Int c, TileBase t)
    { if (ActiveTM==null) return; Undo.RecordObject(ActiveTM,"Paint"); ActiveTM.SetTile(c,t); EditorUtility.SetDirty(ActiveTM); }

    private void PaintBox(Vector3Int a, Vector3Int b, TileBase t)
    {
        if (ActiveTM==null) return;
        int x0=Mathf.Min(a.x,b.x),x1=Mathf.Max(a.x,b.x);
        int y0=Mathf.Min(a.y,b.y),y1=Mathf.Max(a.y,b.y);
        Undo.RecordObject(ActiveTM,"Box Fill");
        for (int x=x0;x<=x1;x++) for (int y=y0;y<=y1;y++) ActiveTM.SetTile(new Vector3Int(x,y,0),t);
        ActiveTM.RefreshAllTiles(); EditorUtility.SetDirty(ActiveTM);
    }

    private void PaintLine(Vector3Int start, Vector3Int end, TileBase t)
    {
        if (ActiveTM==null) return; Undo.RecordObject(ActiveTM,"Line");
        int x=start.x,y=start.y,dx=Mathf.Abs(end.x-x),dy=Mathf.Abs(end.y-y);
        int sx=x<end.x?1:-1,sy=y<end.y?1:-1,err=dx-dy;
        while (true) { ActiveTM.SetTile(new Vector3Int(x,y,0),t); if (x==end.x&&y==end.y) break;
            int e2=2*err; if (e2>-dy){err-=dy;x+=sx;} if (e2<dx){err+=dx;y+=sy;} }
        ActiveTM.RefreshAllTiles(); EditorUtility.SetDirty(ActiveTM);
    }

    private void FloodFill(Vector3Int o, TileBase n)
    {
        if (ActiveTM==null) return; var tgt=ActiveTM.GetTile(o); if (tgt==n) return;
        Undo.RecordObject(ActiveTM,"Fill"); var q=new Queue<Vector3Int>(); q.Enqueue(o);
        var vis=new HashSet<Vector3Int>(); int lim=5000;
        while (q.Count>0&&lim-->0) { var c=q.Dequeue(); if (!vis.Add(c)) continue;
            if (ActiveTM.GetTile(c)!=tgt) continue; ActiveTM.SetTile(c,n);
            foreach (var nb in new[]{c+Vector3Int.right,c+Vector3Int.left,c+Vector3Int.up,c+Vector3Int.down})
                if (!vis.Contains(nb)) q.Enqueue(nb); }
        ActiveTM.RefreshAllTiles(); EditorUtility.SetDirty(ActiveTM);
    }

    private void PaintStamp(Vector3Int origin, Stamp s)
    {
        if (ActiveTM==null||s==null) return; 
        Undo.RecordObject(ActiveTM,"Stamp");
        
        GetStampPivotOffset(_stampPivot, s.width, s.height, out int dx, out int dy);
        int startX = origin.x + dx + _stampKeyOffset.x;
        int startY = origin.y + dy + _stampKeyOffset.y;

        for (int sy=0;sy<s.height;sy++) 
            for (int sx=0;sx<s.width;sx++)
            { 
                int i=sy*s.width+sx; 
                if (i>=s.guids.Length||string.IsNullOrEmpty(s.guids[i])) continue;
                var tile=AssetDatabase.LoadAssetAtPath<TileBase>(AssetDatabase.GUIDToAssetPath(s.guids[i]));
                if (tile!=null) 
                    ActiveTM.SetTile(new Vector3Int(startX+sx,startY-sy,0),tile); 
            }
        ActiveTM.RefreshAllTiles(); 
        EditorUtility.SetDirty(ActiveTM);
    }

    private void PickTile(Vector3Int cell)
    { if (ActiveTM==null) return; var t=ActiveTM.GetTile(cell); if (t==null) return;
      for (int i=0;i<_tiles.Length;i++) if (_tiles[i]==t){_selTileIdx=i;Repaint();return;} }

    // ══════════════════════════════════════════════════════
    // TEMPLATES
    // ══════════════════════════════════════════════════════
    private List<Vector2Int> PlatformH()    {var r=new List<Vector2Int>();for(int x=0;x<_tmplWidth;x++)r.Add(new(x,0));return r;}
    private List<Vector2Int> PlatformV()    {var r=new List<Vector2Int>();for(int y=0;y<_tmplHeight;y++)r.Add(new(0,y));return r;}
    private List<Vector2Int> RoomHollow()   {var r=new List<Vector2Int>();for(int x=0;x<_tmplWidth;x++)for(int y=0;y<_tmplHeight;y++)if(x==0||x==_tmplWidth-1||y==0||y==_tmplHeight-1)r.Add(new(x,y));return r;}
    private List<Vector2Int> RoomSolid()    {var r=new List<Vector2Int>();for(int x=0;x<_tmplWidth;x++)for(int y=0;y<_tmplHeight;y++)r.Add(new(x,y));return r;}
    private List<Vector2Int> StairsRight()  {var r=new List<Vector2Int>();for(int i=0;i<_tmplWidth;i++)for(int x=0;x<=i;x++)r.Add(new(i,x));return r;}
    private List<Vector2Int> StairsLeft()   {var r=new List<Vector2Int>();for(int i=0;i<_tmplWidth;i++)for(int x=0;x<=(_tmplWidth-1-i);x++)r.Add(new(i,x));return r;}
    private List<Vector2Int> PlatformWalled(){var r=PlatformH();for(int y=0;y<_tmplHeight;y++){r.Add(new(0,y));r.Add(new(_tmplWidth-1,y));}return r;}
    private List<Vector2Int> Corridor()     {var r=new List<Vector2Int>();for(int x=0;x<_tmplWidth;x++){r.Add(new(x,0));r.Add(new(x,_tmplHeight-1));}return r;}
    private List<Vector2Int> PlatformGap()  {var r=new List<Vector2Int>();int g=Mathf.Max(1,_tmplWidth/5),m=_tmplWidth/2;for(int x=0;x<_tmplWidth;x++)if(x<m-g||x>m+g)r.Add(new(x,0));return r;}
    private List<Vector2Int> CenterPillar() {var r=new List<Vector2Int>();int cx=_tmplWidth/2;for(int y=1;y<_tmplHeight-1;y++)r.Add(new(cx,y));return r;}
    private List<Vector2Int> Zigzag()       {var r=new List<Vector2Int>();for(int x=0;x<_tmplWidth;x++)r.Add(new(x,(x%4<2)?0:2));return r;}
    private List<Vector2Int> SpiralStairs() {var r=new List<Vector2Int>();int cx=_tmplWidth/2,cy=_tmplHeight/2,step=0,dx=1,dy=0,x=0,y=0,seg=1,segL=1,turns=0;while(step<_tmplWidth*_tmplHeight){r.Add(new(cx+x,cy+y));x+=dx;y+=dy;step++;if(--segL==0){int t=dx;dx=-dy;dy=t;turns++;if(turns%2==0)seg++;segL=seg;}}return r;}

    private void PlacePositions(List<Vector2Int> pos)
    {
        if (ActiveTM==null){ShowErr("Chọn Tilemap!");return;}
        if (_selTileIdx<0||_selTileIdx>=_tiles.Length){ShowErr("Chọn Tile!");return;}
        var tile=_tiles[_selTileIdx]; Undo.RecordObject(ActiveTM,"Template");
        foreach (var p in pos) ActiveTM.SetTile(new Vector3Int(_tmplPos.x+p.x,_tmplPos.y+p.y,0),tile);
        ActiveTM.RefreshAllTiles(); EditorUtility.SetDirty(ActiveTM);
    }

    // ══════════════════════════════════════════════════════
    // STAMP MANAGEMENT
    // ══════════════════════════════════════════════════════
    private void SaveManualStamp()
    {
        if (_stampEdit==null) return;
        var s=new Stamp(_newStampName,_editStampW,_editStampH);
        for (int i=0;i<_stampEdit.Length;i++)
            if (_stampEdit[i]!=null)
                s.guids[i]=AssetDatabase.AssetPathToGUID(AssetDatabase.GetAssetPath(_stampEdit[i]));
        _stamps.Add(s);
    }
    private void LoadStampToEditor(int idx)
    {
        var s=_stamps[idx]; _editStampW=s.width; _editStampH=s.height; _newStampName=s.name;
        _stampEdit=new TileBase[s.width*s.height];
        for (int i=0;i<s.guids.Length;i++)
            if (!string.IsNullOrEmpty(s.guids[i]))
                _stampEdit[i]=AssetDatabase.LoadAssetAtPath<TileBase>(AssetDatabase.GUIDToAssetPath(s.guids[i]));
    }

    // ══════════════════════════════════════════════════════
    // QUICK OBJECT CREATION
    // ══════════════════════════════════════════════════════
    private void MakeMovingPlatform()
    { var go=new GameObject("Moving Platform");go.tag="Ground";go.AddComponent<SpriteRenderer>().sortingOrder=5;
      var rb=go.AddComponent<Rigidbody2D>();rb.bodyType=RigidbodyType2D.Kinematic;rb.useFullKinematicContacts=true;
      go.AddComponent<BoxCollider2D>();go.AddComponent<MovingPlatform>();
      Undo.RegisterCreatedObjectUndo(go,"Moving Platform");Selection.activeGameObject=go; }
    private void MakeHazardZone()
    { var go=new GameObject("Hazard Zone");var c=go.AddComponent<BoxCollider2D>();c.isTrigger=true;c.size=new Vector2(2f,1f);
      go.AddComponent<HazardZone>();Undo.RegisterCreatedObjectUndo(go,"Hazard Zone");Selection.activeGameObject=go; }
    private void MakeFallTrap()
    { var go=new GameObject("Fall Trap");go.AddComponent<BoxCollider2D>().isTrigger=true;go.AddComponent<SpriteRenderer>();
      var rb=go.AddComponent<Rigidbody2D>();rb.bodyType=RigidbodyType2D.Kinematic;rb.gravityScale=0;go.AddComponent<FallTrap>();
      var rp=new GameObject("Reset Point");rp.transform.SetParent(go.transform);rp.transform.localPosition=new Vector3(0,3f,0);
      Undo.RegisterCreatedObjectUndo(go,"Fall Trap");Selection.activeGameObject=go; }
    private void MakeSecretTrigger()
    { var go=new GameObject("Secret Trigger");go.AddComponent<BoxCollider2D>().isTrigger=true;
      Undo.RegisterCreatedObjectUndo(go,"Secret Trigger");Selection.activeGameObject=go; }
    private void PlacePrefab()
    {
        if (_selPrefabIdx<0||_selPrefabIdx>=_prefabs.Length) return;
        var go=(GameObject)PrefabUtility.InstantiatePrefab(_prefabs[_selPrefabIdx]);
        if (SceneView.lastActiveSceneView!=null)
        { var p=SceneView.lastActiveSceneView.pivot; var pos=new Vector3(p.x,p.y,0);
          if (_snapToGrid) pos=new Vector3(Mathf.Round(pos.x/_gridSnap)*_gridSnap,Mathf.Round(pos.y/_gridSnap)*_gridSnap,0);
          go.transform.position=pos; }
        Undo.RegisterCreatedObjectUndo(go,"Place Prefab"); Selection.activeGameObject=go;
    }

    // ══════════════════════════════════════════════════════
    // COLLIDER UTILS
    // ══════════════════════════════════════════════════════
    private void AddTilemapCollider()
    { if (ActiveTM==null){ShowErr("Chọn Tilemap!");return;}
      if (ActiveTM.GetComponent<TilemapCollider2D>()==null) Undo.AddComponent<TilemapCollider2D>(ActiveTM.gameObject); }
    private void AddCompositeCollider()
    { if (ActiveTM==null){ShowErr("Chọn Tilemap!");return;}
      var tc=ActiveTM.GetComponent<TilemapCollider2D>()??Undo.AddComponent<TilemapCollider2D>(ActiveTM.gameObject);
      tc.usedByComposite=true;
      if (ActiveTM.GetComponent<CompositeCollider2D>()==null) Undo.AddComponent<CompositeCollider2D>(ActiveTM.gameObject);
      var rb=ActiveTM.GetComponent<Rigidbody2D>()??Undo.AddComponent<Rigidbody2D>(ActiveTM.gameObject);
      rb.bodyType=RigidbodyType2D.Static; }
    private void ClearAllTiles()
    { if (ActiveTM==null){ShowErr("Chọn Tilemap!");return;}
      if (EditorUtility.DisplayDialog("Xóa","Xóa tất cả tile?","Xóa","Hủy"))
      { Undo.RecordObject(ActiveTM,"Clear");ActiveTM.ClearAllTiles();EditorUtility.SetDirty(ActiveTM); } }

    // ══════════════════════════════════════════════════════
    // ASSET LOADING
    // ══════════════════════════════════════════════════════
    private void RefreshTilemaps()
    { _tilemaps=FindObjectsOfType<Tilemap>(); _tilemapNames=System.Array.ConvertAll(_tilemaps,t=>t.name);
      if (_activeTmIdx>=_tilemaps.Length) _activeTmIdx=0; Repaint(); }

    private void LoadTiles()
    {
        var guids=AssetDatabase.FindAssets("t:TileBase",new[]{_tilesFolder});
        _tiles=new TileBase[guids.Length]; _tilePreviews=new Texture2D[guids.Length];
        for (int i=0;i<guids.Length;i++)
            _tiles[i]=AssetDatabase.LoadAssetAtPath<TileBase>(AssetDatabase.GUIDToAssetPath(guids[i]));
        EditorApplication.delayCall+=()=>{ for (int i=0;i<_tiles.Length;i++) _tilePreviews[i]=TilePreview(_tiles[i]); Repaint(); };
        _selTileIdx=-1;
    }

    private void LoadPrefabs()
    { var guids=AssetDatabase.FindAssets("t:Prefab",new[]{_prefabsFolder});
      _prefabs=new GameObject[guids.Length];
      for (int i=0;i<guids.Length;i++)
          _prefabs[i]=AssetDatabase.LoadAssetAtPath<GameObject>(AssetDatabase.GUIDToAssetPath(guids[i])); }

    private Texture2D TilePreview(TileBase tile)
    { if (tile==null) return null; var tx=AssetPreview.GetAssetPreview(tile); if (tx!=null) return tx;
      if (tile is Tile t&&t.sprite!=null) return AssetPreview.GetAssetPreview(t.sprite); return null; }

    // ══════════════════════════════════════════════════════
    // UI HELPERS
    // ══════════════════════════════════════════════════════
    private void DrawTilemapSelectorMini()
    {
        using (new EditorGUILayout.HorizontalScope())
        { if (GUILayout.Button("🔄",GUILayout.Width(26),GUILayout.Height(22))) RefreshTilemaps();
          if (_tilemaps.Length==0){GUILayout.Label("Không có Tilemap!");return;}
          _activeTmIdx=EditorGUILayout.Popup(_activeTmIdx,_tilemapNames); }
        if (ActiveTM!=null)
            using (new EditorGUILayout.HorizontalScope())
            { EditorGUILayout.ObjectField(ActiveTM,typeof(Tilemap),true);
              if (GUILayout.Button("Select",GUILayout.Width(55))) Selection.activeGameObject=ActiveTM.gameObject; }
    }

    private void Section(string title, System.Action draw)
    { EditorGUILayout.Space(2);
      var hr=EditorGUILayout.GetControlRect(false,22); EditorGUI.DrawRect(hr,new Color(0.18f,0.20f,0.28f));
      EditorGUI.LabelField(hr,title,_sectionStyle);
      using (new EditorGUILayout.VerticalScope("box")) draw?.Invoke(); }

    private TileBase SelectedTile =>
        _selTileIdx>=0&&_selTileIdx<_tiles.Length ? _tiles[_selTileIdx] : null;

    private void ShowErr(string m) => EditorUtility.DisplayDialog("Map Builder Pro",m,"OK");

    private void InitStyles()
    {
        if (_stylesReady) return;
        _titleStyle=new GUIStyle(EditorStyles.boldLabel){fontSize=15,alignment=TextAnchor.MiddleLeft,
            padding=new RectOffset(10,0,0,0),normal={textColor=new Color(0.88f,0.90f,1f)}};
        _sectionStyle=new GUIStyle(EditorStyles.boldLabel){fontSize=11,alignment=TextAnchor.MiddleLeft,
            padding=new RectOffset(8,0,0,0),normal={textColor=new Color(0.65f,0.88f,1f)}};
        _stylesReady=true;
    }

    // ── STAMP PLACEMENT HELPERS ────────────────────────────
    private void GetStampPivotOffset(int pivot, int w, int h, out int dx, out int dy)
    {
        dx = 0; dy = 0;
        switch (pivot)
        {
            case 1: dx = 0;          dy = h - 1; break; // Bottom-Left
            case 2: dx = -w / 2;     dy = h - 1; break; // Bottom-Center
            case 3: dx = -(w - 1);   dy = h - 1; break; // Bottom-Right
            case 4: dx = 0;          dy = h / 2; break; // Middle-Left
            case 5: dx = -w / 2;     dy = h / 2; break; // Center
            case 6: dx = -(w - 1);   dy = h / 2; break; // Middle-Right
            case 7: dx = 0;          dy = 0;     break; // Top-Left (Default)
            case 8: dx = -w / 2;     dy = 0;     break; // Top-Center
            case 9: dx = -(w - 1);   dy = 0;     break; // Top-Right
        }
    }

    private string GetPivotName(int pivot)
    {
        switch (pivot)
        {
            case 1: return "Bottom-Left (Phím 1)";
            case 2: return "Bottom-Center (Phím 2)";
            case 3: return "Bottom-Right (Phím 3)";
            case 4: return "Middle-Left (Phím 4)";
            case 5: return "Center (Phím 5)";
            case 6: return "Middle-Right (Phím 6)";
            case 7: return "Top-Left (Phím 7)";
            case 8: return "Top-Center (Phím 8)";
            case 9: return "Top-Right (Phím 9)";
            default: return "Center";
        }
    }

    private void HandleKeyboardInput(Event e, SceneView sv)
    {
        if (e.type == EventType.KeyDown)
        {
            bool isStamp = _selStampIdx >= 0 && _selStampIdx < _stamps.Count && _tool == PaintTool.Pencil;
            if (!isStamp) return;

            // Numpad or Alpha keys 1-9 to set Pivot
            int newPivot = -1;
            if (e.keyCode >= KeyCode.Alpha1 && e.keyCode <= KeyCode.Alpha9)
                newPivot = e.keyCode - KeyCode.Alpha1 + 1;
            else if (e.keyCode >= KeyCode.Keypad1 && e.keyCode <= KeyCode.Keypad9)
                newPivot = e.keyCode - KeyCode.Keypad1 + 1;

            if (newPivot != -1)
            {
                _stampPivot = newPivot;
                e.Use();
                sv.Repaint();
            }

            // Arrow keys or WASD to fine-tune placement offset cell-by-cell
            bool offsetChanged = false;
            if (e.keyCode == KeyCode.UpArrow || e.keyCode == KeyCode.W)
            { _stampKeyOffset.y += 1; offsetChanged = true; }
            else if (e.keyCode == KeyCode.DownArrow || e.keyCode == KeyCode.S)
            { _stampKeyOffset.y -= 1; offsetChanged = true; }
            else if (e.keyCode == KeyCode.LeftArrow || e.keyCode == KeyCode.A)
            { _stampKeyOffset.x -= 1; offsetChanged = true; }
            else if (e.keyCode == KeyCode.RightArrow || e.keyCode == KeyCode.D)
            { _stampKeyOffset.x += 1; offsetChanged = true; }

            // Reset offset with Backspace or R
            if (e.keyCode == KeyCode.Backspace || e.keyCode == KeyCode.R)
            { _stampKeyOffset = Vector2Int.zero; offsetChanged = true; }

            if (offsetChanged)
            {
                e.Use();
                sv.Repaint();
            }
        }
    }

    private void DrawSceneHUD(SceneView sv)
    {
        if (!_sceneActive || ActiveTM == null) return;

        bool isStamp = _selStampIdx >= 0 && _selStampIdx < _stamps.Count && _tool == PaintTool.Pencil;
        if (!isStamp && _selTileIdx < 0) return;

        string title = isStamp ? $"Stamp: {_stamps[_selStampIdx].name}" : $"Tile: {_tiles[_selTileIdx].name}";
        
        Rect r = new Rect(10, sv.position.height - 130, 310, 100);
        
        // GUI style configuration
        var boxStyle = new GUIStyle(GUI.skin.box);
        EditorGUI.DrawRect(r, new Color(0.12f, 0.14f, 0.20f, 0.90f));
        EditorGUI.DrawRect(new Rect(r.x, r.y, r.width, 3), new Color(0.25f, 0.65f, 1f));

        var style = new GUIStyle(EditorStyles.miniLabel) { normal = { textColor = new Color(0.8f, 0.8f, 0.85f) } };
        var titleStyle = new GUIStyle(EditorStyles.boldLabel) { normal = { textColor = new Color(0.3f, 0.8f, 1f) } };

        GUILayout.BeginArea(new Rect(r.x + 10, r.y + 8, r.width - 20, r.height - 16));
        GUILayout.Label($"🎨  Cách đặt: {title}", titleStyle);
        
        if (isStamp)
        {
            var s = _stamps[_selStampIdx];
            string pivotName = GetPivotName(_stampPivot);
            GUILayout.Label($"📐 Kích thước: {s.width}×{s.height}  |  Tâm: {pivotName}", style);
            GUILayout.Label($"⌨ Phím 1-9 để đổi Tâm  |  Mũi tên / WASD để dịch chuyển", style);
            GUILayout.Label($"📍 Lệch ô hiện tại: ({_stampKeyOffset.x}, {_stampKeyOffset.y})  [Phím R để Reset]", style);
        }
        else
        {
            GUILayout.Label($"✏ Click / Kéo chuột trái để vẽ tile", style);
            GUILayout.Label($"◻ Chuột phải để xóa tile", style);
        }
        GUILayout.EndArea();
    }
}
