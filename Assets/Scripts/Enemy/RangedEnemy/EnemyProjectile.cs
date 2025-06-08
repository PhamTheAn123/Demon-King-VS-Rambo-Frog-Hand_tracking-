using UnityEngine;

/// <summary>
/// EnemyProjectile - Dam ban tu ke dich.
/// Tu huy sau thoi gian song hoac khi va cham.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class EnemyProjectile : MonoBehaviour
{
    [Header("Settings")]
    public int   damage   = 1;
    public float lifeTime = 4f;
    public ParticleSystem impactParticle;
    public AudioClip      impactSound;

    private bool        _hit;
    private AudioSource _audio;

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void Start()
    {
        if (impactSound != null)
        {
            _audio = gameObject.AddComponent<AudioSource>();
            _audio.playOnAwake = false;
            _audio.clip = impactSound;
        }
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        Destroy(gameObject, lifeTime);
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_hit) return;

        if (other.CompareTag("Player"))
        {
            _hit = true;
            var ph = other.GetComponent<PlayerHealth>();
            if (ph != null) ph.TakeDamage(damage);
            PlayImpact();
            Destroy(gameObject, 0.05f);
        }
        else if (other.CompareTag("Ground") || other.CompareTag("Platform"))
        {
            _hit = true;
            PlayImpact();
            Destroy(gameObject, 0.05f);
        }
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void PlayImpact()
    {
        if (impactParticle != null)
            Instantiate(impactParticle, transform.position, Quaternion.identity);
        _audio?.Play();
    }
}