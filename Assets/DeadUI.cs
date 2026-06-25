using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class DeadUI : MonoBehaviour
{
    [SerializeField] private GameObject deadPanel;
    [SerializeField] private TextMeshProUGUI deathMessageText;
    
    void Start()
    {
        SetupButtonListeners();

        // Bảo đảm scale của Canvas cha/gốc là (1,1,1) và sortingOrder là 999 để tránh bị che bởi các Canvas khác
        Canvas canvas = GetComponent<Canvas>();
        if (canvas == null)
        {
            canvas = GetComponentInParent<Canvas>();
        }
        if (canvas != null)
        {
            canvas.transform.localScale = Vector3.one;
            canvas.sortingOrder = 999;
        }

        if (deathMessageText != null)
        {
            deathMessageText.raycastTarget = false; // Tắt raycast target để tránh chặn click chuột vào các nút bên dưới
        }

        if (deadPanel != null)
        {
            deadPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("DeadPanel chưa được gán trong Inspector!");
        }
    }

    private void SetupButtonListeners()
    {
        Button[] buttons = GetComponentsInChildren<Button>(true);
        foreach (Button btn in buttons)
        {
            string btnName = btn.gameObject.name.ToLower();
            if (btnName.Contains("restart") || btnName.Contains("replay"))
            {
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(Restart);
                Debug.Log("DeadUI: Đã gắn sự kiện Restart/Replay cho nút: " + btn.gameObject.name);
            }
            else if (btnName.Contains("menu") || btnName.Contains("home"))
            {
                btn.onClick.RemoveAllListeners();
                btn.onClick.AddListener(MainMenu);
                Debug.Log("DeadUI: Đã gắn sự kiện MainMenu/Home cho nút: " + btn.gameObject.name);
            }
        }
    }
    
    public void ShowDeadPanel()
    {
        // Vô hiệu hóa PlayerController để tránh di chuyển và bắn súng khi đã chết (bất kể nguyên nhân chết là gì)
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            player.enabled = false;
        }

        // CHÚ Ý: Giữ nguyên CrosshairController hoạt động để người chơi di chuyển tâm ngắm chỉ nút bấm

        if (deadPanel != null)
        {
            // Bảo đảm scale của Canvas cha/gốc là (1,1,1) và sortingOrder là 999 để tính toán Raycast click hoạt động chuẩn xác trên cùng
            Canvas parentCanvas = GetComponent<Canvas>();
            if (parentCanvas == null)
            {
                parentCanvas = GetComponentInParent<Canvas>();
            }
            if (parentCanvas != null)
            {
                parentCanvas.transform.localScale = Vector3.one;
                parentCanvas.sortingOrder = 999;
            }

            deadPanel.SetActive(true);
            Time.timeScale = 0;
            
            // Giữ ẩn trỏ chuột hệ thống cho đẹp mắt, chỉ dùng tâm ngắm ảo để ngắm click
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None; // Giải phóng chuột để di chuyển tự do
            
            if (deathMessageText != null)
            {
                deathMessageText.text = "You are Dead!";
                deathMessageText.raycastTarget = false; // Bảo đảm không chặn raycast
            }
        }
    }
    
    public void ShowDeadPanelWithMessage(string message)
    {
        // Vô hiệu hóa PlayerController để tránh di chuyển và bắn súng khi đã chết (bất kể nguyên nhân chết là gì)
        PlayerController player = FindObjectOfType<PlayerController>();
        if (player != null)
        {
            player.enabled = false;
        }

        // CHÚ Ý: Giữ nguyên CrosshairController hoạt động để người chơi di chuyển tâm ngắm chỉ nút bấm

        if (deadPanel != null)
        {
            // Bảo đảm scale của Canvas cha/gốc là (1,1,1) và sortingOrder là 999 để tính toán Raycast click hoạt động chuẩn xác trên cùng
            Canvas parentCanvas = GetComponent<Canvas>();
            if (parentCanvas == null)
            {
                parentCanvas = GetComponentInParent<Canvas>();
            }
            if (parentCanvas != null)
            {
                parentCanvas.transform.localScale = Vector3.one;
                parentCanvas.sortingOrder = 999;
            }

            deadPanel.SetActive(true);
            Time.timeScale = 0;
            
            // Giữ ẩn trỏ chuột hệ thống cho đẹp mắt, chỉ dùng tâm ngắm ảo để ngắm click
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None; // Giải phóng chuột để di chuyển tự do
            
            if (deathMessageText != null)
            {
                deathMessageText.text = message;
                deathMessageText.raycastTarget = false; // Bảo đảm không chặn raycast
            }
        }
    }
    
    public void Restart()
    {
        Debug.Log("DeadUI: Clicked RESTART button, loading Lever-1...");
        SceneManager.LoadScene("Lever-1");
        Time.timeScale = 1;
    }
    
    public void MainMenu()
    {
        Debug.Log("DeadUI: Clicked MAIN MENU button, loading MainMenu...");
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }
    
    public void QuitGame()
    {
        Debug.Log("Đang thoát trò chơi");
        Application.Quit();
    }
}
