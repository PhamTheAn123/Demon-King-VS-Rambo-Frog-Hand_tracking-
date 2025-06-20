using System.Collections;
using UnityEngine;

/// <summary>
/// ItemPickup - Base class cho cac item nhat duoc trong game.
/// Ke thua de tao: HealthPotion, AmmoBox, ScoreGem...
/// </summary>
public abstract class ItemPickup : MonoBehaviour
{
    [Header("Pickup Settings")]
    public float lifetime     = 15f;   // 0 = vinh vien
    public float bobAmplitude = 0.15f;
    public float bobFrequency = 2f;

    [Header("FX")]
    public ParticleSystem pickupFX;
    public AudioClip      pickupSound;

    private bool        _pickedUp;
    private float       _timeAlive;
    private Vector3     _startPos;
    private AudioSource _audio;

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    protected virtual void Start()
    {
        _startPos = transform.position;

        if (pickupSound != null)
        {
            _audio = gameObject.AddComponent<AudioSource>();
            _audio.playOnAwake = false;
            _audio.clip = pickupSound;
        }

        var col = GetComponent<Collider2D>();
        if (col != null) col.isTrigger = true;
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    protected virtual void Update()
    {
        if (_pickedUp) return;

        // Bob animation
        float y = _startPos.y + Mathf.Sin(Time.time * bobFrequency) * bobAmplitude;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);

        // Lifetime
        if (lifetime > 0f)
        {
            _timeAlive += Time.deltaTime;
            if (_timeAlive >= lifetime) StartCoroutine(FadeOut());
        }
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (_pickedUp || !other.CompareTag("Player")) return;

        _pickedUp = true;
        OnPickup(other.gameObject);

        if (pickupFX != null)
            Instantiate(pickupFX, transform.position, Quaternion.identity);

        _audio?.Play();
        Destroy(gameObject, pickupSound != null ? pickupSound.length + 0.1f : 0.1f);
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    protected abstract void OnPickup(GameObject player);

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private IEnumerator FadeOut()
    {
        var sprite = GetComponent<SpriteRenderer>();
        if (sprite == null) { Destroy(gameObject); yield break; }

        float t = 0f; float dur = 1.5f;
        Color c = sprite.color;
        while (t < dur)
        {
            sprite.color = new Color(c.r, c.g, c.b, 1f - t / dur);
            t += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}