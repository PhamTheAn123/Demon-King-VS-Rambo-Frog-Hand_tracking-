using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Header("UI Panels")]
    [SerializeField] private GameObject instructionsPanel;

    private void Start()
    {
        // Hiển thị lại con trỏ chuột hệ thống khi về màn hình chính
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(false);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Lever-1");
    }

    public void OpenInstructions()
    {
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(true);
        }
    }

    public void CloseInstructions()
    {
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(false);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

