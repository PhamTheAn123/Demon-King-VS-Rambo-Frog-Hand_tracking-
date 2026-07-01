using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using TMPro;

public class FeedbackManager : MonoBehaviour
{
    public enum DatabaseType
    {
        FirebaseREST,
        GoogleFormPOST
    }

    [Header("Database Configuration")]
    [Tooltip("Choose which database to send player feedback and installs to.")]
    public DatabaseType databaseType = DatabaseType.FirebaseREST;

    [Tooltip("Firebase Database URL. Example: https://mygame-db.firebaseio.com/")]
    public string firebaseUrl = "https://swd-6c4c4-default-rtdb.firebaseio.com/";

    [Tooltip("Google Form POST URL. Example: https://docs.google.com/forms/d/e/1FAIpQLSf.../formResponse")]
    public string googleFormUrl = "";

    [Header("Google Form Entry IDs (Only if using Google Form)")]
    [Tooltip("Google Form Entry ID for Player Name (e.g. entry.123456789)")]
    public string nameEntryId = "entry.1000001";
    [Tooltip("Google Form Entry ID for Rating (e.g. entry.2000002)")]
    public string ratingEntryId = "entry.1000002";
    [Tooltip("Google Form Entry ID for Feedback Message (e.g. entry.3000003)")]
    public string feedbackEntryId = "entry.1000003";
    [Tooltip("Google Form Entry ID for Device/Install Event (e.g. entry.4000004)")]
    public string installEventEntryId = "entry.1000004";

    [System.Serializable]
    public class VersionInfo
    {
        public string versionNumber;
        public string releaseDate;
        [TextArea(2, 4)]
        public string changes;
    }

    [System.Serializable]
    public class AssetAttribution
    {
        public string assetName;
        public string folderLocation;
        public string description;
    }

    [Header("Local Log Data Settings")]
    public VersionInfo[] versionHistory = new VersionInfo[]
    {
        new VersionInfo { versionNumber = "v1.1.0", releaseDate = "June 2026", changes = "• Added player feedback collection to real-time database.\n• Added first-launch download/installation counter.\n• Integrated 'Update Log & Feedback' panel into Main Menu." },
        new VersionInfo { versionNumber = "v1.0.0", releaseDate = "May 2026", changes = "• Configured MediaPipe Unity Hand Tracking landmarks.\n• Implemented player aiming and gesture-based shoot inputs.\n• Created Level 1, Level 2, and Level 3 (Boss Fight)." }
    };

    public AssetAttribution[] assetDirectory = new AssetAttribution[]
    {
        new AssetAttribution { assetName = "MediaPipe Unity SDK", folderLocation = "Assets/MediaPipeUnity/", description = "Hand landmark detection framework from Google." },
        new AssetAttribution { assetName = "Hand Gesture Logic", folderLocation = "Assets/Scripts/HandTracking/", description = "Translates landmarks into coordinates and shoot states." },
        new AssetAttribution { assetName = "Character & Enemy Art", folderLocation = "Assets/Art/", description = "Visual sprites for Rambo Frog, Demon King (Boss), and enemies." },
        new AssetAttribution { assetName = "Audio & Sounds", folderLocation = "Assets/AudioManager.cs", description = "Manages background score and shoot sound effects." },
        new AssetAttribution { assetName = "Level Scenes", folderLocation = "Assets/Scenes/", description = "MainMenu, Lever-1, Lever-2, Lever-3_Boss." }
    };

    // UI Runtime References
    private Canvas targetCanvas;
    private GameObject menuButtonGo;
    private GameObject mainPanelGo;
    private TextMeshProUGUI totalInstallsText;
    private TMP_InputField nameInputField;
    private TMP_InputField feedbackInputField;
    private Slider ratingSlider;
    private TextMeshProUGUI statusText;
    private TextMeshProUGUI contentText;

    private int activeTab = 0; // 0: Update Log, 1: Asset Directory, 2: Feedback
    private int totalInstalls = 1;

    // Data Transfer Objects
    [Serializable]
    private class FeedbackData
    {
        public string playerName;
        public int rating;
        public string feedbackText;
        public string timestamp;
        public string deviceId;
    }

    [Serializable]
    private class InstallData
    {
        public string deviceId;
        public string installDate;
    }


    void Start()
    {
        FindOrCreateCanvas();
        CreateMenuButton();
        CreateFeedbackPanel();
        CheckAndRegisterInstall();
    }

    private void FindOrCreateCanvas()
    {
        targetCanvas = FindFirstObjectByType<Canvas>();
        if (targetCanvas == null)
        {
            GameObject canvasGo = new GameObject("Canvas");
            targetCanvas = canvasGo.AddComponent<Canvas>();
            targetCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            canvasGo.AddComponent<CanvasScaler>();
            canvasGo.AddComponent<GraphicRaycaster>();
        }

        // Verify EventSystem is present
        if (FindFirstObjectByType<UnityEngine.EventSystems.EventSystem>() == null)
        {
            GameObject eventSystem = new GameObject("EventSystem");
            eventSystem.AddComponent<UnityEngine.EventSystems.EventSystem>();
            eventSystem.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
        }
    }

    private void CreateMenuButton()
    {
        menuButtonGo = new GameObject("Btn_UpdateLogFeedback");
        menuButtonGo.transform.SetParent(targetCanvas.transform, false);

        RectTransform rect = menuButtonGo.AddComponent<RectTransform>();
        rect.anchorMin = new Vector2(0f, 0f); // Bottom-left corner
        rect.anchorMax = new Vector2(0f, 0f);
        rect.pivot = new Vector2(0f, 0f);
        rect.anchoredPosition = new Vector2(25f, 25f);
        rect.sizeDelta = new Vector2(240f, 50f);

        Image img = menuButtonGo.AddComponent<Image>();
        img.color = new Color(0.12f, 0.12f, 0.12f, 0.9f); // Dark grey

        Button btn = menuButtonGo.AddComponent<Button>();
        btn.onClick.AddListener(OpenPanel);

        // Add Hover transition effect
        ColorBlock colors = btn.colors;
        colors.normalColor = new Color(0.12f, 0.12f, 0.12f, 0.9f);
        colors.highlightedColor = new Color(0.18f, 0.5f, 0.35f, 1f); // Green accent on hover
        colors.pressedColor = new Color(0.1f, 0.35f, 0.25f, 1f);
        colors.selectedColor = new Color(0.12f, 0.12f, 0.12f, 0.9f);
        btn.colors = colors;

        // Button Text
        GameObject txtGo = new GameObject("Text");
        txtGo.transform.SetParent(menuButtonGo.transform, false);
        RectTransform txtRect = txtGo.AddComponent<RectTransform>();
        txtRect.anchorMin = Vector2.zero;
        txtRect.anchorMax = Vector2.one;
        txtRect.sizeDelta = Vector2.zero;

        TextMeshProUGUI txt = txtGo.AddComponent<TextMeshProUGUI>();
        txt.text = "📢 Update Log & Feedback";
        txt.alignment = TextAlignmentOptions.Center;
        txt.fontSize = 14;
        txt.color = Color.white;
    }

    private void CreateFeedbackPanel()
    {
        // Panel Background Container
        mainPanelGo = new GameObject("Panel_UpdateLogFeedback");
        mainPanelGo.transform.SetParent(targetCanvas.transform, false);

        RectTransform mainRect = mainPanelGo.AddComponent<RectTransform>();
        mainRect.anchorMin = new Vector2(0.5f, 0.5f);
        mainRect.anchorMax = new Vector2(0.5f, 0.5f);
        mainRect.pivot = new Vector2(0.5f, 0.5f);
        mainRect.sizeDelta = new Vector2(650f, 480f);

        Image mainImg = mainPanelGo.AddComponent<Image>();
        mainImg.color = new Color(0.08f, 0.08f, 0.08f, 0.96f); // Glassmorphism dark

        // Add border outline
        Outline outline = mainPanelGo.AddComponent<Outline>();
        outline.effectColor = new Color(0.18f, 0.5f, 0.35f, 0.5f); // Semi-transparent green
        outline.effectDistance = new Vector2(2f, 2f);

        // Header Title
        GameObject titleGo = new GameObject("Title");
        titleGo.transform.SetParent(mainPanelGo.transform, false);
        RectTransform titleRect = titleGo.AddComponent<RectTransform>();
        titleRect.anchorMin = new Vector2(0f, 1f);
        titleRect.anchorMax = new Vector2(1f, 1f);
        titleRect.pivot = new Vector2(0.5f, 1f);
        titleRect.anchoredPosition = new Vector2(0f, -10f);
        titleRect.sizeDelta = new Vector2(-40f, 40f);

        TextMeshProUGUI titleTxt = titleGo.AddComponent<TextMeshProUGUI>();
        titleTxt.text = "🎮 Game Hub & Logs";
        titleTxt.fontSize = 22;
        titleTxt.fontStyle = FontStyles.Bold;
        titleTxt.alignment = TextAlignmentOptions.Left;
        titleTxt.color = new Color(0.24f, 0.81f, 0.53f, 1f); // Vibrant light green

        // Total installs stat label
        GameObject statGo = new GameObject("TotalInstallsText");
        statGo.transform.SetParent(mainPanelGo.transform, false);
        RectTransform statRect = statGo.AddComponent<RectTransform>();
        statRect.anchorMin = new Vector2(1f, 1f);
        statRect.anchorMax = new Vector2(1f, 1f);
        statRect.pivot = new Vector2(1f, 1f);
        statRect.anchoredPosition = new Vector2(-60f, -12f);
        statRect.sizeDelta = new Vector2(200f, 30f);

        totalInstallsText = statGo.AddComponent<TextMeshProUGUI>();
        totalInstallsText.text = "Downloads: Fetching...";
        totalInstallsText.fontSize = 13;
        totalInstallsText.alignment = TextAlignmentOptions.Right;
        totalInstallsText.color = new Color(0.7f, 0.7f, 0.7f, 1f);

        // Close Button
        GameObject closeGo = new GameObject("Btn_Close");
        closeGo.transform.SetParent(mainPanelGo.transform, false);
        RectTransform closeRect = closeGo.AddComponent<RectTransform>();
        closeRect.anchorMin = new Vector2(1f, 1f);
        closeRect.anchorMax = new Vector2(1f, 1f);
        closeRect.pivot = new Vector2(1f, 1f);
        closeRect.anchoredPosition = new Vector2(-15f, -12f);
        closeRect.sizeDelta = new Vector2(30f, 30f);

        Image closeImg = closeGo.AddComponent<Image>();
        closeImg.color = new Color(0.25f, 0.12f, 0.12f, 0.8f);

        Button closeBtn = closeGo.AddComponent<Button>();
        closeBtn.onClick.AddListener(ClosePanel);
        
        GameObject closeTxtGo = new GameObject("Text");
        closeTxtGo.transform.SetParent(closeGo.transform, false);
        RectTransform closeTxtRect = closeTxtGo.AddComponent<RectTransform>();
        closeTxtRect.anchorMin = Vector2.zero;
        closeTxtRect.anchorMax = Vector2.one;
        closeTxtRect.sizeDelta = Vector2.zero;
        TextMeshProUGUI closeTxt = closeTxtGo.AddComponent<TextMeshProUGUI>();
        closeTxt.text = "✖";
        closeTxt.alignment = TextAlignmentOptions.Center;
        closeTxt.fontSize = 14;
        closeTxt.color = Color.white;

        // Tabs Menu bar (Horizontal)
        GameObject tabsContainer = new GameObject("Tabs_Container");
        tabsContainer.transform.SetParent(mainPanelGo.transform, false);
        RectTransform tabsRect = tabsContainer.AddComponent<RectTransform>();
        tabsRect.anchorMin = new Vector2(0f, 1f);
        tabsRect.anchorMax = new Vector2(1f, 1f);
        tabsRect.pivot = new Vector2(0.5f, 1f);
        tabsRect.anchoredPosition = new Vector2(0f, -60f);
        tabsRect.sizeDelta = new Vector2(-40f, 40f);

        string[] tabNames = { "📋 Update Log", "📂 Assets Directory", "💬 Give Feedback" };
        for (int i = 0; i < tabNames.Length; i++)
        {
            int index = i;
            GameObject tabBtnGo = new GameObject("Tab_" + i);
            tabBtnGo.transform.SetParent(tabsContainer.transform, false);
            RectTransform tabRect = tabBtnGo.AddComponent<RectTransform>();
            tabRect.anchorMin = new Vector2(i / 3f, 0f);
            tabRect.anchorMax = new Vector2((i + 1) / 3f, 1f);
            tabRect.pivot = new Vector2(0.5f, 0.5f);
            tabRect.sizeDelta = new Vector2(-5f, 0f); // 5px gap

            Image tabImg = tabBtnGo.AddComponent<Image>();
            tabImg.color = (i == 0) ? new Color(0.18f, 0.5f, 0.35f, 0.8f) : new Color(0.15f, 0.15f, 0.15f, 0.8f);

            Button tabBtn = tabBtnGo.AddComponent<Button>();
            tabBtn.onClick.AddListener(() => SwitchTab(index));

            GameObject tabTxtGo = new GameObject("Text");
            tabTxtGo.transform.SetParent(tabBtnGo.transform, false);
            RectTransform tabTxtRect = tabTxtGo.AddComponent<RectTransform>();
            tabTxtRect.anchorMin = Vector2.zero;
            tabTxtRect.anchorMax = Vector2.one;
            tabTxtRect.sizeDelta = Vector2.zero;
            TextMeshProUGUI tabTxt = tabTxtGo.AddComponent<TextMeshProUGUI>();
            tabTxt.text = tabNames[i];
            tabTxt.alignment = TextAlignmentOptions.Center;
            tabTxt.fontSize = 13;
            tabTxt.color = Color.white;
        }

        // CONTENT SECTION (Scroll View & Feedback Form)
        GameObject contentArea = new GameObject("Content_Area");
        contentArea.transform.SetParent(mainPanelGo.transform, false);
        RectTransform areaRect = contentArea.AddComponent<RectTransform>();
        areaRect.anchorMin = Vector2.zero;
        areaRect.anchorMax = Vector2.one;
        areaRect.pivot = new Vector2(0.5f, 0.5f);
        areaRect.anchoredPosition = new Vector2(0f, -40f);
        areaRect.sizeDelta = new Vector2(-40f, -160f); // Leave room for header/footer

        // 1. Text Viewer (for Logs / Directories)
        GameObject viewerGo = new GameObject("Text_Viewer");
        viewerGo.transform.SetParent(contentArea.transform, false);
        RectTransform viewRect = viewerGo.AddComponent<RectTransform>();
        viewRect.anchorMin = Vector2.zero;
        viewRect.anchorMax = Vector2.one;
        viewRect.sizeDelta = Vector2.zero;

        ScrollRect scroll = viewerGo.AddComponent<ScrollRect>();
        Image viewImg = viewerGo.AddComponent<Image>();
        viewImg.color = new Color(0.04f, 0.04f, 0.04f, 0.6f);
        Mask mask = viewerGo.AddComponent<Mask>();
        mask.showMaskGraphic = true;

        GameObject contentContainer = new GameObject("Content");
        contentContainer.transform.SetParent(viewerGo.transform, false);
        RectTransform contentRect = contentContainer.AddComponent<RectTransform>();
        contentRect.anchorMin = new Vector2(0f, 1f);
        contentRect.anchorMax = new Vector2(1f, 1f);
        contentRect.pivot = new Vector2(0.5f, 1f);
        contentRect.sizeDelta = new Vector2(0f, 1000f); // Large scrollable height

        contentText = contentContainer.AddComponent<TextMeshProUGUI>();
        contentText.text = GetFormattedChangelog();
        contentText.fontSize = 14;
        contentText.color = new Color(0.9f, 0.9f, 0.9f, 1f);
        contentText.alignment = TextAlignmentOptions.TopLeft;
        contentText.margin = new Vector4(15f, 15f, 15f, 15f);

        scroll.content = contentRect;
        scroll.vertical = true;
        scroll.horizontal = false;

        // 2. Feedback Form Layout (Parent GameObject)
        GameObject formGo = new GameObject("Feedback_Form");
        formGo.transform.SetParent(contentArea.transform, false);
        RectTransform formRect = formGo.AddComponent<RectTransform>();
        formRect.anchorMin = Vector2.zero;
        formRect.anchorMax = Vector2.one;
        formRect.sizeDelta = Vector2.zero;
        formGo.SetActive(false);

        // Player Name Input
        CreateLabel(formGo.transform, "Player Name:", new Vector2(20f, -25f));
        nameInputField = CreateInputField(formGo.transform, "Enter your name...", new Vector2(150f, -25f), new Vector2(250f, 30f));

        // Rating Star Slider
        CreateLabel(formGo.transform, "Rating (1 - 5 ⭐):", new Vector2(20f, -75f));
        GameObject sliderGo = new GameObject("Rating_Slider");
        sliderGo.transform.SetParent(formGo.transform, false);
        RectTransform sliderRect = sliderGo.AddComponent<RectTransform>();
        sliderRect.anchorMin = new Vector2(0f, 1f);
        sliderRect.anchorMax = new Vector2(0f, 1f);
        sliderRect.pivot = new Vector2(0f, 1f);
        sliderRect.anchoredPosition = new Vector2(150f, -75f);
        sliderRect.sizeDelta = new Vector2(250f, 30f);

        ratingSlider = sliderGo.AddComponent<Slider>();
        ratingSlider.minValue = 1;
        ratingSlider.maxValue = 5;
        ratingSlider.wholeNumbers = true;
        ratingSlider.value = 5;

        // Simple Background & Fill for Slider
        Image sliderBg = sliderGo.AddComponent<Image>();
        sliderBg.color = new Color(0.2f, 0.2f, 0.2f, 1f);

        GameObject fillArea = new GameObject("Fill Area");
        fillArea.transform.SetParent(sliderGo.transform, false);
        RectTransform fillAreaRect = fillArea.AddComponent<RectTransform>();
        fillAreaRect.anchorMin = Vector2.zero;
        fillAreaRect.anchorMax = Vector2.one;
        fillAreaRect.sizeDelta = Vector2.zero;

        GameObject fill = new GameObject("Fill");
        fill.transform.SetParent(fillArea.transform, false);
        RectTransform fillRect = fill.AddComponent<RectTransform>();
        fillRect.anchorMin = Vector2.zero;
        fillRect.anchorMax = new Vector2(1f, 1f);
        fillRect.sizeDelta = Vector2.zero;
        Image fillImg = fill.AddComponent<Image>();
        fillImg.color = new Color(0.24f, 0.81f, 0.53f, 1f);
        ratingSlider.fillRect = fillRect;

        // Feedback Text Input
        CreateLabel(formGo.transform, "Your Comments:", new Vector2(20f, -125f));
        feedbackInputField = CreateInputField(formGo.transform, "Type your feedback here...", new Vector2(150f, -125f), new Vector2(400f, 80f));

        // Submit Button
        GameObject submitBtnGo = new GameObject("Btn_Submit");
        submitBtnGo.transform.SetParent(formGo.transform, false);
        RectTransform subRect = submitBtnGo.AddComponent<RectTransform>();
        subRect.anchorMin = new Vector2(0f, 1f);
        subRect.anchorMax = new Vector2(0f, 1f);
        subRect.pivot = new Vector2(0f, 1f);
        subRect.anchoredPosition = new Vector2(150f, -220f);
        subRect.sizeDelta = new Vector2(150f, 40f);

        Image subImg = submitBtnGo.AddComponent<Image>();
        subImg.color = new Color(0.18f, 0.5f, 0.35f, 1f);

        Button subBtn = submitBtnGo.AddComponent<Button>();
        subBtn.onClick.AddListener(SubmitFeedback);

        GameObject subTxtGo = new GameObject("Text");
        subTxtGo.transform.SetParent(submitBtnGo.transform, false);
        RectTransform subTxtRect = subTxtGo.AddComponent<RectTransform>();
        subTxtRect.anchorMin = Vector2.zero;
        subTxtRect.anchorMax = Vector2.one;
        subTxtRect.sizeDelta = Vector2.zero;
        TextMeshProUGUI subTxt = subTxtGo.AddComponent<TextMeshProUGUI>();
        subTxt.text = "Send Feedback 🚀";
        subTxt.alignment = TextAlignmentOptions.Center;
        subTxt.fontSize = 13;
        subTxt.color = Color.white;

        // Status Message Text
        GameObject statusGo = new GameObject("Status_Text");
        statusGo.transform.SetParent(formGo.transform, false);
        RectTransform statusRect = statusGo.AddComponent<RectTransform>();
        statusRect.anchorMin = new Vector2(0f, 1f);
        statusRect.anchorMax = new Vector2(0f, 1f);
        statusRect.pivot = new Vector2(0f, 1f);
        statusRect.anchoredPosition = new Vector2(150f, -270f);
        statusRect.sizeDelta = new Vector2(400f, 30f);

        statusText = statusGo.AddComponent<TextMeshProUGUI>();
        statusText.text = "";
        statusText.fontSize = 12;
        statusText.color = Color.white;

        mainPanelGo.SetActive(false); // Hide panel by default
    }

    private void CreateLabel(Transform parent, string labelText, Vector2 pos)
    {
        GameObject labelGo = new GameObject("Label_" + labelText);
        labelGo.transform.SetParent(parent, false);
        RectTransform r = labelGo.AddComponent<RectTransform>();
        r.anchorMin = new Vector2(0f, 1f);
        r.anchorMax = new Vector2(0f, 1f);
        r.pivot = new Vector2(0f, 1f);
        r.anchoredPosition = pos;
        r.sizeDelta = new Vector2(130f, 30f);

        TextMeshProUGUI t = labelGo.AddComponent<TextMeshProUGUI>();
        t.text = labelText;
        t.fontSize = 13;
        t.alignment = TextAlignmentOptions.Left;
        t.color = Color.white;
    }

    private TMP_InputField CreateInputField(Transform parent, string placeholder, Vector2 pos, Vector2 size)
    {
        GameObject inputGo = new GameObject("InputField");
        inputGo.transform.SetParent(parent, false);
        RectTransform rect = inputGo.AddComponent<RectTransform>();
        rect.anchorMin = new Vector2(0f, 1f);
        rect.anchorMax = new Vector2(0f, 1f);
        rect.pivot = new Vector2(0f, 1f);
        rect.anchoredPosition = pos;
        rect.sizeDelta = size;

        Image img = inputGo.AddComponent<Image>();
        img.color = new Color(0.15f, 0.15f, 0.15f, 1f);
        img.type = Image.Type.Sliced;

        TMP_InputField inputField = inputGo.AddComponent<TMP_InputField>();

        // Text Component
        GameObject textGo = new GameObject("TextArea");
        textGo.transform.SetParent(inputGo.transform, false);
        RectTransform textRect = textGo.AddComponent<RectTransform>();
        textRect.anchorMin = Vector2.zero;
        textRect.anchorMax = Vector2.one;
        textRect.sizeDelta = new Vector2(-10f, -10f); // margin
        
        RectMask2D rMask = textGo.AddComponent<RectMask2D>();

        GameObject textDisplayGo = new GameObject("Text_Display");
        textDisplayGo.transform.SetParent(textGo.transform, false);
        RectTransform dispRect = textDisplayGo.AddComponent<RectTransform>();
        dispRect.anchorMin = Vector2.zero;
        dispRect.anchorMax = Vector2.one;
        dispRect.sizeDelta = Vector2.zero;

        TextMeshProUGUI textDisplay = textDisplayGo.AddComponent<TextMeshProUGUI>();
        textDisplay.fontSize = 13;
        textDisplay.color = Color.white;

        // Placeholder Component
        GameObject placeholderGo = new GameObject("Placeholder");
        placeholderGo.transform.SetParent(textGo.transform, false);
        RectTransform placeRect = placeholderGo.AddComponent<RectTransform>();
        placeRect.anchorMin = Vector2.zero;
        placeRect.anchorMax = Vector2.one;
        placeRect.sizeDelta = Vector2.zero;

        TextMeshProUGUI placeDisplay = placeholderGo.AddComponent<TextMeshProUGUI>();
        placeDisplay.text = placeholder;
        placeDisplay.fontSize = 13;
        placeDisplay.color = new Color(0.5f, 0.5f, 0.5f, 1f);

        inputField.textComponent = textDisplay;
        inputField.placeholder = placeDisplay;
        inputField.textViewport = textRect;

        return inputField;
    }

    public void OpenPanel()
    {
        if (mainPanelGo != null)
        {
            mainPanelGo.SetActive(true);
            SwitchTab(0);
            StartCoroutine(FetchTotalStats());
        }
    }

    public void ClosePanel()
    {
        if (mainPanelGo != null)
        {
            mainPanelGo.SetActive(false);
        }
    }

    public void SwitchTab(int index)
    {
        activeTab = index;

        // Update Tab Button highlights
        Transform tabsContainer = mainPanelGo.transform.Find("Tabs_Container");
        if (tabsContainer != null)
        {
            for (int i = 0; i < 3; i++)
            {
                Transform tab = tabsContainer.Find("Tab_" + i);
                if (tab != null)
                {
                    Image img = tab.GetComponent<Image>();
                    if (img != null)
                    {
                        img.color = (i == activeTab) ? new Color(0.18f, 0.5f, 0.35f, 0.8f) : new Color(0.15f, 0.15f, 0.15f, 0.8f);
                    }
                }
            }
        }

        Transform contentArea = mainPanelGo.transform.Find("Content_Area");
        if (contentArea != null)
        {
            Transform viewer = contentArea.Find("Text_Viewer");
            Transform form = contentArea.Find("Feedback_Form");

            if (index == 0) // Update Log
            {
                contentText.text = GetFormattedChangelog();
            }
            else if (index == 1) // Asset Log
            {
                if (viewer != null) viewer.gameObject.SetActive(true);
                if (form != null) form.gameObject.SetActive(false);
                contentText.text = GetFormattedAssetDirectory();
            }
            else if (index == 2) // Feedback
            {
                if (viewer != null) viewer.gameObject.SetActive(false);
                if (form != null) form.gameObject.SetActive(true);
                if (statusText != null) statusText.text = "";
            }
        }
    }

    public void SubmitFeedback()
    {
        if (nameInputField == null || feedbackInputField == null) return;

        string pName = nameInputField.text.Trim();
        string pText = feedbackInputField.text.Trim();
        int ratingVal = Mathf.RoundToInt(ratingSlider.value);

        if (string.IsNullOrEmpty(pName))
        {
            statusText.text = "<color=red>Error: Please enter your name!</color>";
            return;
        }

        if (string.IsNullOrEmpty(pText))
        {
            statusText.text = "<color=red>Error: Feedback content cannot be empty!</color>";
            return;
        }

        FeedbackData data = new FeedbackData
        {
            playerName = pName,
            rating = ratingVal,
            feedbackText = pText,
            timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss UTC"),
            deviceId = SystemInfo.deviceUniqueIdentifier
        };

        statusText.text = "<color=yellow>Submitting feedback to database...</color>";
        StartCoroutine(SendFeedbackCoroutine(data));
    }

    private IEnumerator SendFeedbackCoroutine(FeedbackData data)
    {
        if (databaseType == DatabaseType.FirebaseREST)
        {
            string url = firebaseUrl.Trim();
            if (!url.EndsWith("/")) url += "/";
            url += "feedback.json"; // Firebase REST API endpoint

            string json = JsonUtility.ToJson(data);
            using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");

                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    statusText.text = "<color=#24D285>Success: Thank you for your feedback! 💖</color>";
                    nameInputField.text = "";
                    feedbackInputField.text = "";
                    StartCoroutine(FetchTotalStats());
                }
                else
                {
                    statusText.text = "<color=red>Error submitting: " + request.error + "</color>";
                }
            }
        }
        else // Google Form POST
        {
            WWWForm form = new WWWForm();
            form.AddField(nameEntryId, data.playerName);
            form.AddField(ratingEntryId, data.rating.ToString());
            form.AddField(feedbackEntryId, data.feedbackText);

            using (UnityWebRequest request = UnityWebRequest.Post(googleFormUrl, form))
            {
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    statusText.text = "<color=#24D285>Success: Feedback sent to Google Sheets! 💖</color>";
                    nameInputField.text = "";
                    feedbackInputField.text = "";
                }
                else
                {
                    statusText.text = "<color=red>Error submitting form: " + request.error + "</color>";
                }
            }
        }
    }

    private void CheckAndRegisterInstall()
    {
        int hasRegistered = PlayerPrefs.GetInt("HasRegisteredInstall", 0);
        if (hasRegistered == 0)
        {
            StartCoroutine(RegisterInstallCoroutine());
        }
        else
        {
            StartCoroutine(FetchTotalStats());
        }
    }

    private IEnumerator RegisterInstallCoroutine()
    {
        InstallData data = new InstallData
        {
            deviceId = SystemInfo.deviceUniqueIdentifier,
            installDate = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss UTC")
        };

        if (databaseType == DatabaseType.FirebaseREST)
        {
            // Register install in Firebase under /installs node
            string url = firebaseUrl.Trim();
            if (!url.EndsWith("/")) url += "/";
            string installUrl = url + "installs/" + data.deviceId + ".json";

            string json = JsonUtility.ToJson(data);
            using (UnityWebRequest request = new UnityWebRequest(installUrl, "PUT")) // PUT to overwrite or set once
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");

                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    PlayerPrefs.SetInt("HasRegisteredInstall", 1);
                    PlayerPrefs.Save();
                }
            }
        }
        else if (databaseType == DatabaseType.GoogleFormPOST && !string.IsNullOrEmpty(googleFormUrl))
        {
            // Google sheets install tracker via Form POST
            WWWForm form = new WWWForm();
            form.AddField(nameEntryId, "INSTALL_EVENT");
            form.AddField(ratingEntryId, "0");
            form.AddField(feedbackEntryId, "New launch registered from Device: " + data.deviceId);

            using (UnityWebRequest request = WebRequestPost(googleFormUrl, form))
            {
                yield return request.SendWebRequest();
                if (request.result == UnityWebRequest.Result.Success)
                {
                    PlayerPrefs.SetInt("HasRegisteredInstall", 1);
                    PlayerPrefs.Save();
                }
            }
        }
    }

    private UnityWebRequest WebRequestPost(string url, WWWForm form)
    {
        return UnityWebRequest.Post(url, form);
    }

    private IEnumerator FetchTotalStats()
    {
        if (databaseType == DatabaseType.FirebaseREST)
        {
            // Fetch installs node count from Firebase
            string url = firebaseUrl.Trim();
            if (!url.EndsWith("/")) url += "/";
            string queryUrl = url + "installs.json?shallow=true"; // shallow=true gets just keys (ideal to count keys)

            using (UnityWebRequest request = UnityWebRequest.Get(queryUrl))
            {
                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    string json = request.downloadHandler.text;
                    if (!string.IsNullOrEmpty(json) && json != "null")
                    {
                        // Firebase return keys like {"device_id_1":true, "device_id_2":true}
                        // We count the commas + 1 to get a simple estimation of items
                        int count = json.Split(',').Length;
                        totalInstalls = Mathf.Max(1, count);
                        if (totalInstallsText != null)
                        {
                            totalInstallsText.text = "Downloads: " + totalInstalls;
                        }
                    }
                }
            }
        }
    }

    private string GetFormattedChangelog()
    {
        StringBuilder sb = new StringBuilder();
        foreach (var v in versionHistory)
        {
            sb.AppendLine($"<b>{v.versionNumber} ({v.releaseDate})</b>");
            sb.AppendLine(v.changes);
            sb.AppendLine();
        }
        return sb.ToString();
    }

    private string GetFormattedAssetDirectory()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<b>📂 Assets Location & Credits Directory</b>");
        sb.AppendLine();
        int counter = 1;
        foreach (var asset in assetDirectory)
        {
            sb.AppendLine($"<b>{counter}. {asset.assetName}</b>");
            sb.AppendLine($"• <i>Location:</i> <color=#A3E2C9>{asset.folderLocation}</color>");
            sb.AppendLine($"• <i>Description:</i> {asset.description}");
            sb.AppendLine();
            counter++;
        }
        return sb.ToString();
    }
}

