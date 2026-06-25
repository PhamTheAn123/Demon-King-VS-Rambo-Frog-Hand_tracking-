using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    [SerializeField] private bool useHandTracking = true;
    [SerializeField] private HandInputProvider handInput;

    void Update()
    {
        Vector3 targetPosition;

        if (useHandTracking && handInput != null && handInput.HasHand)
        {
            var camera = Camera.main;
            if (camera != null)
            {
                targetPosition = camera.ScreenToWorldPoint(new Vector3(handInput.AimScreenPos.x, handInput.AimScreenPos.y, 0f - camera.transform.position.z));

                // Đồng bộ hóa vị trí con trỏ chuột hệ thống với vị trí Aim của Hand Tracking 
                // để Unity Event System có thể phát hiện chính xác vị trí hover/click trên nút UI.
                #if ENABLE_INPUT_SYSTEM
                if (UnityEngine.InputSystem.Mouse.current != null)
                {
                    UnityEngine.InputSystem.Mouse.current.WarpCursorPosition(handInput.AimScreenPos);
                }
                #endif
            }
            else
            {
                targetPosition = Vector3.zero;
            }
        }
        else
        {
            targetPosition = MouseWorldUtils.GetMouseWorldPosition();
        }

        targetPosition.z = 0;
        transform.position = targetPosition;
    }

    private void Start()
    {
        Cursor.visible = false;
    }
}