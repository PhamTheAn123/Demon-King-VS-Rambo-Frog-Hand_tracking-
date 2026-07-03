using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class BossHealth : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer spriteRenderer;

    private Rigidbody2D rb;
    [Header("Boss health settings")]
    public int maxHealth;
    public int currentHealth;
    private Color ogColor;
    private bool isDead = false;
    public Slider healthBar;
    private bool isInvulnerable = false;

    public event Action<float> OnHealthPercentChanged;
    public event Action OnDied;
    public bool IsDead => isDead;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        ogColor = spriteRenderer.color;
        anim = GetComponent<Animator>();
        if (anim == null)
        {
            anim = GetComponentInChildren<Animator>();
        }
        rb = GetComponent<Rigidbody2D>();
        if (healthBar != null) healthBar.maxValue = maxHealth;
        OnHealthPercentChanged?.Invoke(GetHealthPercent());
    }

    void Update()
    {
        healthBar.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isDead) return;
        if (isInvulnerable) return;

        currentHealth -= damage;
        StartCoroutine(Flash());
        if (currentHealth <= 0)
        {
            Die();
        }
        OnHealthPercentChanged?.Invoke(GetHealthPercent());
    }
    private void Die()
    {
        if (isDead) return;
        isDead = true;
        OnDied?.Invoke();
        if (anim != null)
        {
            anim.SetTrigger("die");
        }
        else
        {
            DieAnimation();
        }
    }
    public void DieAnimation()
    {
        Collider2D col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;

        if (rb != null)
        {
            rb.simulated = false;
        }
    }
    private IEnumerator Flash()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.color = ogColor;
            yield return new WaitForSeconds(0.1f);

            spriteRenderer.color = Color.red;
            yield return new WaitForSeconds(0.15f);
            spriteRenderer.color = ogColor;
        }
    }

    public void SetInvulnerable(bool inv)
    {
        isInvulnerable = inv;
        if (spriteRenderer != null)
        {
            spriteRenderer.color = inv ? Color.gray : ogColor;
        }
    }

    public float GetHealthPercent()
    {
        if (maxHealth <= 0) return 0f;
        return (float)currentHealth / (float)maxHealth * 100f;
    }
}
