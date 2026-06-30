using UnityEngine;

/// <summary>
/// Hazard Zone – Vùng nguy hiểm giết Player ngay lập tức.
/// Tạo bằng Map Builder: Tools > Map Builder Pro > Prefabs > Tạo nhanh.
/// </summary>
[RequireComponent(typeof(Collider2D))]
public class HazardZone : MonoBehaviour
{
    [Header("Cài đặt")]
    [Tooltip("Thông báo hiển thị khi Player chết")]
    public string deathMessage = "Bạn đã chết vì bẫy!";

    [Tooltip("Trễ trước khi xử lý chết (giây)")]
    public float deathDelay = 0f;

    [Header("Hiệu ứng (tùy chọn)")]
    public ParticleSystem deathParticle;
    public AudioClip      deathSound;

    [Header("Editor Gizmo")]
    public Color gizmoColor = new Color(1f, 0.1f, 0.1f, 0.35f);

    // ── Private ────────────────────────────────────────────────────
    private Collider2D  _col;
    private AudioSource _audio;
    private bool        _triggered;

    // ──────────────────────────────────────────────────────────────
    private void Awake()
    {
        _col           = GetComponent<Collider2D>();
        _col.isTrigger = true;

        if (deathSound != null)
        {
            _audio          = gameObject.AddComponent<AudioSource>();
            _audio.clip     = deathSound;
            _audio.playOnAwake = false;
        }
    }

    // ──────────────────────────────────────────────────────────────
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_triggered || !other.CompareTag("Player")) return;
        _triggered = true;

        if (deathParticle != null)
            Instantiate(deathParticle, other.transform.position, Quaternion.identity);

        _audio?.Play();

        if (deathDelay > 0f) Invoke(nameof(TriggerDeath), deathDelay);
        else TriggerDeath();
    }

    // ──────────────────────────────────────────────────────────────
    private void TriggerDeath()
    {
        _triggered = false;

        var deadUI = FindObjectOfType<DeadUI>();
        if (deadUI != null) { deadUI.ShowDeadPanelWithMessage(deathMessage); return; }

        // Fallback: reload scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    // ──────────────────────────────────────────────────────────────
    // Gizmos – chỉ chạy trong Editor (không dùng UnityEditor namespace)
    private void OnDrawGizmos()
    {
        var col = GetComponent<Collider2D>();
        if (col == null) return;

        Gizmos.color = gizmoColor;
        Gizmos.DrawCube(col.bounds.center, col.bounds.size);

        Gizmos.color = new Color(gizmoColor.r, gizmoColor.g, gizmoColor.b, 1f);
        Gizmos.DrawWireCube(col.bounds.center, col.bounds.size);
    }

    private void OnDrawGizmosSelected()
    {
        var col = GetComponent<Collider2D>();
        if (col == null) return;
        // Highlight khi được chọn
        Gizmos.color = new Color(1f, 0.9f, 0f, 0.6f);
        Gizmos.DrawWireCube(col.bounds.center, col.bounds.size * 1.05f);
    }
}
