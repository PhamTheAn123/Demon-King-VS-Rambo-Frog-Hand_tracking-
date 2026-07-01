using UnityEngine;
using UnityEngine.SceneManagement;

public class Deadzone : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

   
    void Update()
    {

    }    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
          
            DeadUI deadUI = FindObjectOfType<DeadUI>();
            if (deadUI != null)
            {
                deadUI.ShowDeadPanelWithMessage("You have fallen into a hole!");
            }
            else
            {
                
                SceneManager.LoadScene("Lever-1");
                Debug.Log("Player has fallen into a hole. Reloading Lever 1.");
            }
        }
    }
}

  