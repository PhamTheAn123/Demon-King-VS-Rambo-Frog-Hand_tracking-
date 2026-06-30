using UnityEngine;

/// <summary>
/// Moving Platform - Nền tảng di chuyển qua lại.
/// Tạo bằng Map Builder: Tools > Map Builder > Platform Tools
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class MovingPlatform : MonoBehaviour
{
    [Header("Di chuyển")]
    public bool moveHorizontal = true;
    [Tooltip("Khoảng cách di chuyển từ vị trí ban đầu (mỗi hướng)")]
    public float moveDistance = 3f;
    public float moveSpeed = 2f;

    [Header("Tuỳ chỉnh")]
    [Tooltip("Dừng ở điểm cuối bao nhiêu giây trước khi quay lại")]
    public float pauseAtEnd = 0f;
    public bool startMovingRight = true;

    // ── Private ────────────────────────────────────────────────────
    private Rigidbody2D _rb;
    private Vector3 _startPos;
    private Vector3 _pointA;
    private Vector3 _pointB;
    private int _direction;
    private float _pauseTimer = 0f;
    private bool _isPaused = false;

    // ──────────────────────────────────────────────────────────────
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _rb.bodyType = RigidbodyType2D.Kinematic;
        _rb.useFullKinematicContacts = true;
        _rb.gravityScale = 0;
        _rb.constraints = RigidbodyConstraints2D.FreezeRotation;

        _startPos = transform.position;

        if (moveHorizontal)
        {
            _pointA = _startPos + Vector3.left * moveDistance;
            _pointB = _startPos + Vector3.right * moveDistance;
        }
        else
        {
            _pointA = _startPos + Vector3.down * moveDistance;
            _pointB = _startPos + Vector3.up * moveDistance;
        }

        _direction = startMovingRight ? 1 : -1;
    }

    // ──────────────────────────────────────────────────────────────
    private void FixedUpdate()
    {
        if (_isPaused)
        {
            _pauseTimer -= Time.fixedDeltaTime;
            if (_pauseTimer <= 0f)
                _isPaused = false;
            return;
        }

        Vector3 target = _direction > 0 ? _pointB : _pointA;
        Vector3 newPos = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.fixedDeltaTime);
        _rb.MovePosition(newPos);

        // Đảo chiều khi tới đích
        if (Vector3.Distance(transform.position, target) < 0.05f)
        {
            _direction *= -1;
            if (pauseAtEnd > 0f)
            {
                _isPaused = true;
                _pauseTimer = pauseAtEnd;
            }
        }
    }

    // ──────────────────────────────────────────────────────────────
    // Kéo Player cùng với platform (không bị trượt)
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            col.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            col.transform.SetParent(null);
    }

    // ──────────────────────────────────────────────────────────────
    // Gizmos hiển thị đường đi trong Editor
    private void OnDrawGizmos()
    {
        Vector3 origin = Application.isPlaying ? _startPos : transform.position;

        Vector3 a, b;
        if (moveHorizontal)
        {
            a = origin + Vector3.left * moveDistance;
            b = origin + Vector3.right * moveDistance;
        }
        else
        {
            a = origin + Vector3.down * moveDistance;
            b = origin + Vector3.up * moveDistance;
        }

        Gizmos.color = new Color(0.2f, 0.8f, 0.2f, 0.8f);
        Gizmos.DrawLine(a, b);

        Gizmos.color = new Color(1f, 0.5f, 0f, 0.9f);
        Gizmos.DrawWireSphere(a, 0.18f);
        Gizmos.DrawWireSphere(b, 0.18f);

        Gizmos.color = new Color(0.2f, 0.8f, 0.2f, 0.4f);
        var bounds = GetComponent<Collider2D>();
        if (bounds != null)
        {
            Gizmos.DrawWireCube(a, bounds.bounds.size);
            Gizmos.DrawWireCube(b, bounds.bounds.size);
        }
    }
}
