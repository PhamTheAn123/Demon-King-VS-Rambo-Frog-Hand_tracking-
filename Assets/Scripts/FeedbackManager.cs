using System;
using System.Collections;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class FeedbackManager : MonoBehaviour
{
    public enum DatabaseType
    {
        FirebaseREST,
        GoogleFormPOST,
        Supabase
    }

    [Header("Database Configuration")]
    [Tooltip("Choose which database to send player feedback and installs to.")]
    public DatabaseType databaseType = DatabaseType.Supabase;

    [Tooltip("Firebase Database URL. Example: https://mygame-db.firebaseio.com/")]
    public string firebaseUrl = "https://swd-6c4c4-default-rtdb.firebaseio.com/";

    [Tooltip("Google Form POST URL. Example: https://docs.google.com/forms/d/e/1FAIpQLSf.../formResponse")]
    public string googleFormUrl = "";

    [Header("Supabase Configuration")]
    [Tooltip("Supabase Project URL (Auto-loaded from StreamingAssets/supabase_config.json at runtime).")]
    public string supabaseUrl = "LOADED_FROM_CONFIG";
    [Tooltip("Supabase Anon / Publishable Key (Auto-loaded from StreamingAssets/supabase_config.json at runtime).")]
    public string supabaseAnonKey = "LOADED_FROM_CONFIG";

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
    [Header("UI Physical References")]
    [Tooltip("Reference to the scene button that opens the panel.")]
    public Button feedbackButton;
    public GameObject mainPanelGo;
    public TextMeshProUGUI totalInstallsText;
    public TMP_InputField nameInputField;
    public TMP_InputField feedbackInputField;
    public Slider ratingSlider; // kept for backward compat, hidden in favour of buttons
    public TextMeshProUGUI statusText;
    public TextMeshProUGUI contentText;

    private int activeTab = 0; // 0: Update Log, 1: Asset Directory, 2: Feedback
    private int totalInstalls = 1;
    private int currentRating = 5; // star rating 1-5, synced from StarRatingController

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

    [Serializable]
    private class SupabaseFeedbackData
    {
        public string player_name;
        public int rating;
        public string feedback_text;
        public string device_id;
    }

    [Serializable]
    private class SupabaseInstallData
    {
        public string device_id;
    }

    [Serializable]
    private class SupabaseCountWrapper
    {
        public int count;
    }


    [Serializable]
    private class SupabaseConfig
    {
        public string supabaseUrl;
        public string supabaseAnonKey;
    }

    private IEnumerator LoadSupabaseConfig()
    {
        string path = System.IO.Path.Combine(Application.streamingAssetsPath, "supabase_config.json");
        string jsonText = "";

        if (path.Contains("://") || path.Contains(":///"))
        {
            using (UnityWebRequest webRequest = UnityWebRequest.Get(path))
            {
                yield return webRequest.SendWebRequest();
                if (webRequest.result == UnityWebRequest.Result.Success)
                {
                    jsonText = webRequest.downloadHandler.text;
                }
            }
        }
        else
        {
            if (System.IO.File.Exists(path))
            {
                jsonText = System.IO.File.ReadAllText(path);
            }
        }

        if (!string.IsNullOrEmpty(jsonText))
        {
            try
            {
                SupabaseConfig config = JsonUtility.FromJson<SupabaseConfig>(jsonText);
                if (config != null)
                {
                    supabaseUrl = config.supabaseUrl;
                    supabaseAnonKey = config.supabaseAnonKey;
                }
            }
            catch (Exception ex)
            {
                Debug.LogError("Error parsing supabase_config.json: " + ex.Message);
            }
        }
        else
        {
            Debug.LogWarning("Supabase configuration file not found at: " + path);
        }
    }

    IEnumerator Start()
    {
        FindOrCreateCanvas();
        yield return StartCoroutine(LoadSupabaseConfig());
        CheckAndRegisterInstall();
    }

    void Update()
    {
        // Handle TMP link clicks on contentText (Asset Directory folder paths, tab index 1)
        if (contentText != null && activeTab == 1 && Input.GetMouseButtonDown(0))
        {
            // For ScreenSpaceOverlay canvas, camera must be null
            Camera cam = (contentText.canvas != null && contentText.canvas.renderMode == RenderMode.ScreenSpaceCamera)
                ? contentText.canvas.worldCamera
                : null;

            int linkIndex = TMP_TextUtilities.FindIntersectingLink(contentText, Input.mousePosition, cam);
            if (linkIndex != -1)
            {
                TMP_LinkInfo linkInfo = contentText.textInfo.linkInfo[linkIndex];
                string linkId = linkInfo.GetLinkID();
                OpenAssetPath(linkId);
            }
        }
    }

    private void OpenAssetPath(string assetPath)
    {
        Debug.Log("[FeedbackManager] Link clicked: " + assetPath);
        try
        {
            #if UNITY_EDITOR
            // Ping/select the asset in the Unity Project window
            UnityEngine.Object obj = UnityEditor.AssetDatabase.LoadAssetAtPath<UnityEngine.Object>(assetPath);
            if (obj != null)
            {
                UnityEditor.Selection.activeObject = obj;
                UnityEditor.EditorGUIUtility.PingObject(obj);
                Debug.Log("Pinged asset: " + assetPath);
            }
            else
            {
                // Fallback: open folder in File Explorer
                string fullPath = System.IO.Path.GetFullPath(
                    System.IO.Path.Combine(Application.dataPath, "..", assetPath.Replace('/', System.IO.Path.DirectorySeparatorChar))
                );
                if (System.IO.Directory.Exists(fullPath) || System.IO.File.Exists(fullPath))
                {
                    System.Diagnostics.Process.Start("explorer.exe", fullPath);
                }
            }
            #else
            // In Standalone build, open folder in Windows Explorer
            string fullPath = System.IO.Path.GetFullPath(
                System.IO.Path.Combine(Application.dataPath, "..", assetPath.Replace('/', System.IO.Path.DirectorySeparatorChar))
            );
            if (System.IO.Directory.Exists(fullPath))
            {
                System.Diagnostics.Process.Start("explorer.exe", fullPath);
            }
            else if (System.IO.File.Exists(fullPath))
            {
                System.Diagnostics.Process.Start("explorer.exe", "/select," + fullPath);
            }
            #endif
        }
        catch (Exception e)
        {
            Debug.LogError("[FeedbackManager] Failed to open asset path: " + e.Message);
        }
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
                if (viewer != null) viewer.gameObject.SetActive(true);
                if (form != null) form.gameObject.SetActive(false);
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

                // Hide legacy slider and auto-generated button row
                if (form != null)
                {
                    Transform oldSlider = form.Find("Rating_Slider");
                    if (oldSlider != null) oldSlider.gameObject.SetActive(false);

                    Transform oldButtonRow = form.Find("Rating_ButtonRow");
                    if (oldButtonRow != null) oldButtonRow.gameObject.SetActive(false);

                    // Update label text
                    Transform oldLabel = form.Find("Label_Rating (1 - 5 \u2B50)");
                    if (oldLabel == null) oldLabel = form.Find("Label_Rating");
                    if (oldLabel != null)
                    {
                        var lTmp = oldLabel.GetComponent<TextMeshProUGUI>();
                        if (lTmp != null) lTmp.text = "Rating:";
                        oldLabel.name = "Label_Rating";
                    }
                }
            }
        }
    }

    /// <summary>Called by StarRatingController when a star is clicked.</summary>
    public void SetStarRating(int stars)
    {
        currentRating = Mathf.Clamp(stars, 1, 5);
    }

    public void SubmitFeedback()
    {
        if (nameInputField == null || feedbackInputField == null) return;

        string pName = nameInputField.text.Trim();
        string pText = feedbackInputField.text.Trim();
        int ratingVal = currentRating;

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
                    statusText.text = "<color=#24D285>Success: Thank you for your feedback!</color>";
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
        else if (databaseType == DatabaseType.Supabase)
        {
            string url = supabaseUrl.Trim();
            if (!url.EndsWith("/")) url += "/";
            url += "rest/v1/feedback";

            SupabaseFeedbackData dbData = new SupabaseFeedbackData
            {
                player_name = data.playerName,
                rating = data.rating,
                feedback_text = data.feedbackText,
                device_id = data.deviceId
            };

            string json = JsonUtility.ToJson(dbData);
            using (UnityWebRequest request = new UnityWebRequest(url, "POST"))
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                request.SetRequestHeader("apikey", supabaseAnonKey);
                request.SetRequestHeader("Authorization", "Bearer " + supabaseAnonKey);

                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    statusText.text = "<color=#24D285>Success: Thank you for your feedback!</color>";
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
        string prefKey = "HasRegisteredInstall_" + databaseType.ToString();
        int hasRegistered = PlayerPrefs.GetInt(prefKey, 0);

        // Migration for backward compatibility
        if (hasRegistered == 0 && databaseType == DatabaseType.FirebaseREST)
        {
            if (PlayerPrefs.GetInt("HasRegisteredInstall", 0) == 1)
            {
                PlayerPrefs.SetInt(prefKey, 1);
                PlayerPrefs.Save();
                hasRegistered = 1;
            }
        }

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

        string prefKey = "HasRegisteredInstall_" + databaseType.ToString();

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
                    PlayerPrefs.SetInt(prefKey, 1);
                    PlayerPrefs.Save();
                }
            }
        }
        else if (databaseType == DatabaseType.Supabase)
        {
            string url = supabaseUrl.Trim();
            if (!url.EndsWith("/")) url += "/";
            string installUrl = url + "rest/v1/installs";

            SupabaseInstallData dbData = new SupabaseInstallData
            {
                device_id = data.deviceId
            };

            string json = JsonUtility.ToJson(dbData);
            using (UnityWebRequest request = new UnityWebRequest(installUrl, "POST"))
            {
                byte[] bodyRaw = Encoding.UTF8.GetBytes(json);
                request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                request.downloadHandler = new DownloadHandlerBuffer();
                request.SetRequestHeader("Content-Type", "application/json");
                request.SetRequestHeader("apikey", supabaseAnonKey);
                request.SetRequestHeader("Authorization", "Bearer " + supabaseAnonKey);
                // UPSERT in Supabase via Postgrest
                request.SetRequestHeader("Prefer", "resolution=merge-duplicates");

                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    PlayerPrefs.SetInt(prefKey, 1);
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
                    PlayerPrefs.SetInt(prefKey, 1);
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
        else if (databaseType == DatabaseType.Supabase)
        {
            string url = supabaseUrl.Trim();
            if (!url.EndsWith("/")) url += "/";
            // Get count of rows in installs table
            string queryUrl = url + "rest/v1/installs?select=count";

            using (UnityWebRequest request = UnityWebRequest.Get(queryUrl))
            {
                request.SetRequestHeader("apikey", supabaseAnonKey);
                request.SetRequestHeader("Authorization", "Bearer " + supabaseAnonKey);

                yield return request.SendWebRequest();

                if (request.result == UnityWebRequest.Result.Success)
                {
                    string json = request.downloadHandler.text;
                    if (!string.IsNullOrEmpty(json) && json != "null" && json.Length > 2)
                    {
                        // Supabase REST returns e.g. [{"count":12}]
                        // We clean up brackets to make it a parseable object {"count":12}
                        string clean = json.Replace("[", "").Replace("]", "");
                        try
                        {
                            SupabaseCountWrapper wrapper = JsonUtility.FromJson<SupabaseCountWrapper>(clean);
                            totalInstalls = Mathf.Max(1, wrapper.count);
                            if (totalInstallsText != null)
                            {
                                totalInstallsText.text = "Downloads: " + totalInstalls;
                            }
                        }
                        catch (Exception ex)
                        {
                            Debug.LogError("Error parsing Supabase count response: " + ex.Message + " Raw: " + json);
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
        sb.AppendLine("<b>[Assets] Location & Credits Directory</b>");
        sb.AppendLine();
        int counter = 1;
        foreach (var asset in assetDirectory)
        {
            sb.AppendLine($"<b>{counter}. {asset.assetName}</b>");
            sb.AppendLine($"• <i>Location:</i> <link=\"{asset.folderLocation}\"><color=#A3E2C9><u>{asset.folderLocation}</u></color></link>");
            sb.AppendLine($"• <i>Description:</i> {asset.description}");
            sb.AppendLine();
            counter++;
        }
        return sb.ToString();
    }
}

