using System.Collections;
using UnityEngine;

/// <summary>
/// DashAbility - Component dash doc lap, gan vao Player.
/// Khong phu thuoc vao PlayerController, de duang dang va mo rong.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class DashAbility : MonoBehaviour
{
    // â”€â”€ Settings â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    [Header("Dash Settings")]
    public bool  enableDash   = true;
    public float dashSpeed    = 20f;
    public float dashDuration = 0.18f;
    public float dashCooldown = 1.2f;

    [Header("FX")]
    public ParticleSystem dashFX;
    public TrailRenderer  dashTrail;

    [Header("Input")]
    [Tooltip("Phim dash (keyboard)")]
    public KeyCode dashKey = KeyCode.LeftShift;

    // â”€â”€ Private â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private Rigidbody2D    _rb;
    private SpriteRenderer _sprite;
    private Animator       _anim;

    private bool  _isDashing;
    private bool  _canDash = true;
    private float _dashTimer;
    private float _cooldownTimer;
    private float _savedGravity;

    // â”€â”€ Properties â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public bool IsDashing => _isDashing;
    public bool CanDash   => _canDash;

    // â”€â”€ Events â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public System.Action OnDashStart;
    public System.Action OnDashEnd;

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void Awake()
    {
        _rb     = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _anim   = GetComponent<Animator>();
        _savedGravity = _rb.gravityScale;

        if (dashTrail != null) dashTrail.emitting = false;
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void Update()
    {
        if (!enableDash) return;

        // Cooldown timer
        if (!_canDash)
        {
            _cooldownTimer -= Time.deltaTime;
            if (_cooldownTimer <= 0f) _canDash = true;
        }

        // Dash timer
        if (_isDashing)
        {
            _dashTimer -= Time.deltaTime;
            if (_dashTimer <= 0f) EndDash();
            return;
        }

        // Input
        if (Input.GetKeyDown(dashKey) && _canDash)
            TriggerDash(GetDashDirection());
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    /// <summary>Goi tu ben ngoai (VD: HandTracking) de bat dau dash.</summary>
    public void TriggerDash(float direction)
    {
        if (!_canDash || _isDashing || !enableDash) return;

        _isDashing     = true;
        _canDash       = false;
        _dashTimer     = dashDuration;
        _cooldownTimer = dashCooldown;

        // Tat gravity trong khi dash
        _rb.gravityScale = 0f;
        _rb.linearVelocity = new Vector2(direction * dashSpeed, 0f);

        // FX
        if (dashFX   != null) dashFX.Play();
        if (dashTrail != null) dashTrail.emitting = true;
        if (_anim    != null) _anim.SetTrigger("dash");

        OnDashStart?.Invoke();
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void EndDash()
    {
        _isDashing       = false;
        _rb.gravityScale = _savedGravity;
        _rb.linearVelocity = new Vector2(0f, _rb.linearVelocity.y);

        if (dashTrail != null) dashTrail.emitting = false;
        if (_anim    != null) _anim.SetBool("isDashing", false);

        OnDashEnd?.Invoke();
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private float GetDashDirection()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(h) > 0.1f) return Mathf.Sign(h);
        return (_sprite != null && _sprite.flipX) ? -1f : 1f;
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public float GetCooldownProgress()
    {
        if (_canDash) return 1f;
        return 1f - (_cooldownTimer / dashCooldown);
    }
}