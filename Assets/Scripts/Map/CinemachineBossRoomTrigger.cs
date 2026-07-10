using UnityEngine;

public class CinemachineBossRoomTrigger : MonoBehaviour
{
    [Header("Camera References")]
    [Tooltip("GameObject của camera Cinemachine phòng Boss (CM Boss Camera)")]
    public GameObject bossCamera;

    private bool isTriggered = false;

    private void Start()
    {
        // Đảm bảo camera phòng Boss tắt lúc bắt đầu game
        if (bossCamera != null)
        {
            bossCamera.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isTriggered) return;

        // Kiểm tra xem đối tượng va chạm có phải là Player không
        if (collision.CompareTag("Player"))
        {
            if (bossCamera != null)
            {
                bossCamera.SetActive(true);
                isTriggered = true;
                Debug.Log("[CinemachineBossRoomTrigger] Player entered Boss Room. Activating Boss Camera.");
            }
            else
            {
                Debug.LogWarning("[CinemachineBossRoomTrigger] bossCamera is not assigned in the inspector!");
            }
        }
    }

    /// <summary>
    /// Tắt camera phòng Boss để Cinemachine chuyển cảnh mượt mà quay lại Player camera.
    /// </summary>
    public void DisableBossCamera()
    {
        if (bossCamera != null)
        {
            bossCamera.SetActive(false);
            Debug.Log("[CinemachineBossRoomTrigger] Boss defeated. Deactivating Boss Camera.");
        }
    }
}
