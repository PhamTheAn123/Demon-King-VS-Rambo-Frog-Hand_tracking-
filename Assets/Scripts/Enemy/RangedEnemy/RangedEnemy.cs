using System.Collections;
using UnityEngine;

/// <summary>
/// RangedEnemy - Ke dich ban projectile tu xa.
/// Giu khoang cach an toan va ban dan ve phia Player.
/// </summary>
public class RangedEnemy : MonoBehaviour
{
    // â”€â”€ Stats â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    [Header("Stats")]
    public int   maxHealth   = 4;
    public int   currentHealth;
    public int   damage      = 1;

    // â”€â”€ Movement â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    [Header("Movement")]
    public float moveSpeed         = 2.5f;
    public float preferredDistance = 5f;
    public float tooCloseDistance  = 3f;

    // â”€â”€ Attack â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    [Header("Attack")]
    public GameObject projectilePrefab;
    public Transform  firePoint;
    public float      fireRate       = 2f;
    public float      projectileSpeed = 8f;
    public float      attackRange     = 8f;

    // â”€â”€ Visual â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    [Header("Visual")]
    public ParticleSystem muzzleFlash;
    public Color          flashColor = Color.yellow;

    // â”€â”€ Private â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private Transform      _player;
    private Rigidbody2D    _rb;
    private Animator       _anim;
    private SpriteRenderer _sprite;
    private float          _nextFireTime;
    private bool           _isDead;
    private Color          _originalColor;

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void Awake()
    {
        _rb     = GetComponent<Rigidbody2D>();
        _anim   = GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        if (_sprite != null) _originalColor = _sprite.color;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        var playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) _player = playerObj.transform;
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void Update()
    {
        if (_isDead || _player == null) return;

        float dist = Vector2.Distance(transform.position, _player.position);
        if (dist <= attackRange)
        {
            HandleMovement(dist);
            HandleShooting(dist);
        }
        else
        {
            if (_rb != null) _rb.linearVelocity = new Vector2(0, _rb.linearVelocity.y);
        }

        UpdateAnimations();
        FlipTowardTarget();
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void HandleMovement(float dist)
    {
        float dir = 0f;
        if (dist > preferredDistance)
            dir = (_player.position.x > transform.position.x) ? 1f : -1f;
        else if (dist < tooCloseDistance)
            dir = (_player.position.x > transform.position.x) ? -1f : 1f;

        if (_rb != null)
            _rb.linearVelocity = new Vector2(dir * moveSpeed, _rb.linearVelocity.y);
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void HandleShooting(float dist)
    {
        if (dist > attackRange || Time.time < _nextFireTime) return;
        _nextFireTime = Time.time + fireRate;
        StartCoroutine(Shoot());
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private IEnumerator Shoot()
    {
        if (_rb != null) _rb.linearVelocity = new Vector2(0, _rb.linearVelocity.y);
        if (_anim != null) _anim.SetTrigger("shoot");
        yield return new WaitForSeconds(0.15f);

        if (projectilePrefab == null || firePoint == null) yield break;

        Vector2 dir   = (_player.position - firePoint.position).normalized;
        float   angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var     proj  = Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0, 0, angle));

        var rb = proj.GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = dir * projectileSpeed;

        var ep = proj.GetComponent<EnemyProjectile>();
        if (ep != null) ep.damage = damage;

        if (muzzleFlash != null) muzzleFlash.Play();
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public void TakeDamage(int dmg)
    {
        if (_isDead) return;
        currentHealth -= dmg;
        StartCoroutine(FlashDamage());
        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        if (_isDead) return;
        _isDead = true;
        if (_anim != null) _anim.SetTrigger("die");
        if (_rb   != null) _rb.linearVelocity = Vector2.zero;
        var col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;
        Destroy(gameObject, 1.5f);
    }

    private IEnumerator FlashDamage()
    {
        if (_sprite == null) yield break;
        _sprite.color = flashColor;
        yield return new WaitForSeconds(0.12f);
        _sprite.color = _originalColor;
    }

    private void UpdateAnimations()
    {
        if (_anim == null) return;
        float speed = _rb != null ? Mathf.Abs(_rb.linearVelocity.x) : 0f;
        _anim.SetBool("isWalking", speed > 0.1f);
        _anim.SetBool("isDead", _isDead);
    }

    private void FlipTowardTarget()
    {
        if (_player == null || _sprite == null) return;
        _sprite.flipX = _player.position.x < transform.position.x;
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.4f);
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = new Color(1f, 0.5f, 0f, 0.4f);
        Gizmos.DrawWireSphere(transform.position, preferredDistance);
        Gizmos.color = new Color(0f, 1f, 0f, 0.4f);
        Gizmos.DrawWireSphere(transform.position, tooCloseDistance);
    }
}