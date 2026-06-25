using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Start()
    {
        // Hiển thị lại con trỏ chuột hệ thống khi về màn hình chính
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void PlayGame()
    {
      SceneManager.LoadScene("Lever-1");
    }

    public void QuitGame()
    {
       Application.Quit();
    }
}
