using UnityEngine;

/// <summary>
/// HealthPotion - Item hoi mau cho Player.
/// </summary>
public class HealthPotion : ItemPickup
{
    [Header("Heal Settings")]
    public int  healAmount = 1;
    public bool fullHeal   = false;

    protected override void OnPickup(GameObject player)
    {
        var health = player.GetComponent<PlayerHealth>();
        if (health == null) return;

        if (fullHeal)
            health.Heal(health.maxHealth);
        else
            health.Heal(healAmount);

        if (GameManager.Instance != null) GameManager.Instance.AddScore(50);
        Debug.Log($"[HealthPotion] Hoi {(fullHeal ? "full" : healAmount.ToString())} mau!");
    }
}