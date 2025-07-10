using System.Collections;
using UnityEngine;

/// <summary>
/// Checkpoint - Diem hoi sinh.
/// Khi Player cham vao, luu vi tri hoi sinh vao CheckpointManager.
/// </summary>
public class Checkpoint : MonoBehaviour
{
    [Header("Settings")]
    public bool  isStartCheckpoint = false;
    public Color inactiveColor     = new Color(0.5f, 0.5f, 0.5f, 0.8f);
    public Color activeColor       = new Color(0f,   1f,   0.5f, 0.9f);

    [Header("FX")]
    public ParticleSystem activateFX;
    public AudioClip      activateSound;
    public SpriteRenderer flagSprite;

    private bool        _isActive;
    private AudioSource _audio;

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void Start()
    {
        if (activateSound != null)
        {
            _audio = gameObject.AddComponent<AudioSource>();
            _audio.playOnAwake = false;
        }

        if (isStartCheckpoint) Activate(silent: true);
        else if (flagSprite != null) flagSprite.color = inactiveColor;
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isActive || !other.CompareTag("Player")) return;
        Activate();
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void Activate(bool silent = false)
    {
        _isActive = true;
        CheckpointManager.Instance?.SetCheckpoint(transform.position);
        if (flagSprite != null) flagSprite.color = activeColor;

        if (!silent)
        {
            if (activateFX != null)
                Instantiate(activateFX, transform.position, Quaternion.identity);
            if (_audio != null && activateSound != null)
            {
                _audio.clip = activateSound;
                _audio.Play();
            }
            Debug.Log($"[Checkpoint] Kich hoat tai {transform.position}");
        }
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void OnDrawGizmos()
    {
        Gizmos.color = _isActive ? activeColor : inactiveColor;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}