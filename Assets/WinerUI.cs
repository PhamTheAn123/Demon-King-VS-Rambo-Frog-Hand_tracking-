using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinerUI : MonoBehaviour
{
    [SerializeField] private GameObject winnerPanel;
    [SerializeField] private Button backToMainMenuButton;
    private BossHealth bossHealth;
    
    void Start()
    {
        if (winnerPanel != null)
        {
            winnerPanel.SetActive(false);
        }
        else
        {
            Debug.LogError("WinnerPanel has not been assigned in Inspector!");
        }
        
        bossHealth = FindObjectOfType<BossHealth>();
        if (bossHealth == null)
        {
            Debug.LogWarning("BossHealth component not found in scene!");
        }

        if (backToMainMenuButton != null)
        {
            backToMainMenuButton.onClick.AddListener(BackToMainMenu);
        }
    }

    void Update()
    {
        if (bossHealth != null && bossHealth.currentHealth <= 0)
        {
            ShowWinnerPanel();
        }
    }
    
    public void ShowWinnerPanel()
    {
        if (winnerPanel != null)
        {
            winnerPanel.SetActive(true);
            Time.timeScale = 0;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;

            PlayerController player = FindObjectOfType<PlayerController>();
            if (player != null)
            {
                player.enabled = false;
            }
        }
    }

    public void BackToMainMenu()
    {
        Time.timeScale = 1;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("MainMenu");
    }
}

