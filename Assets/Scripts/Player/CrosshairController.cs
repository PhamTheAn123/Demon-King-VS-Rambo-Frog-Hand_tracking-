using UnityEngine;

public class CrosshairController : MonoBehaviour
{
    void Update()
    {
        Vector3 mousePos = MouseWorldUtils.GetMouseWorldPosition();
        mousePos.z = 0;
        transform.position = mousePos;
    }

    private void Start()
    {
        Cursor.visible = false;
    }
}