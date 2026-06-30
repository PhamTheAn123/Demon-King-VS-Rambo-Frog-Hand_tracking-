using UnityEngine;
using UnityEngine.SceneManagement;
public class FallTrap : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool daroi = false;
    public Transform diemkhoiphuc;
    private Vector3 initialPosition; // Vị trí ban đầu làm dự phòng nếu chưa gán điểm khôi phục

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position; // Lưu vị trí ban đầu
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !daroi)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            daroi = true;
            Invoke("khoiphuc", 2f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            DeadUI deadUI = FindObjectOfType<DeadUI>();
            if (deadUI != null)
            {
                deadUI.ShowDeadPanelWithMessage("Bị nghiền nát bởi bẫy !");
            }
            else
            {
                // Reload lại scene hiện tại thay vì hardcode Lever-1
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    private void khoiphuc()
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0;

        if (diemkhoiphuc != null)
        {
            transform.position = diemkhoiphuc.position;
        }
        else
        {
            transform.position = initialPosition; // Trở về vị trí ban đầu nếu chưa gán điểm khôi phục
        }

        daroi = false;
    }
}
