using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu;

    public void PauseGame()
    {
        // Set sorting order of the canvas to 999 to be on top of all other Canvases
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

        pauseMenu.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = false; // Giữ ẩn con trỏ chuột hệ thống
        Cursor.lockState = CursorLockMode.None; // Giải phóng chuột để di chuyển tự do
    }
    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
    }
    public void Exit()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
        Cursor.visible = false;
    }
    public void Restart()
    {
        SceneManager.LoadScene("Lever-1");
        Time.timeScale = 1;
    }
}
