using UnityEngine;
using UnityEngine.SceneManagement;
public class FallTrap : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool daroi = false;
    public Transform diemkhoiphuc;
    private Vector3 initialPosition; // Vị trí ban đầu làm dự phòng nếu chưa gán điểm khôi phục

    [Header("Fly Up Settings")]
    public bool flyUp = false;      // Tích chọn nếu muốn bẫy gai bay từ dưới đất lên
    public float flySpeed = 10f;    // Tốc độ bay lên của bẫy gai
    public float resetTime = 2f;    // Thời gian giữ bẫy trước khi khôi phục vị trí ban đầu

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        initialPosition = transform.position; // Lưu vị trí ban đầu
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !daroi)
        {
            daroi = true;
            if (flyUp)
            {
                rb.bodyType = RigidbodyType2D.Kinematic;
                rb.linearVelocity = Vector2.up * flySpeed;
            }
            else
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
            }
            Invoke("khoiphuc", resetTime);
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
