using UnityEngine;

/// <summary>
/// ScoreGem - Item tang diem khi nhat.
/// </summary>
public class ScoreGem : ItemPickup
{
    [Header("Score Settings")]
    public int     scoreValue = 150;
    public GemTier tier       = GemTier.Bronze;

    public enum GemTier { Bronze = 1, Silver = 2, Gold = 5, Diamond = 10 }

    protected override void OnPickup(GameObject player)
    {
        int total = scoreValue * (int)tier;
        GameManager.Instance?.AddScore(total);
        Debug.Log($"[ScoreGem] +{total} diem! (tier: {tier})");
    }

    protected override void OnDrawGizmosSelected()
    {
        Color c = tier switch
        {
            GemTier.Silver  => new Color(0.75f, 0.75f, 0.75f, 0.8f),
            GemTier.Gold    => new Color(1f, 0.84f, 0f, 0.8f),
            GemTier.Diamond => new Color(0.4f, 0.8f, 1f, 0.8f),
            _               => new Color(0.8f, 0.4f, 0.2f, 0.8f),
        };
        Gizmos.color = c;
        Gizmos.DrawWireSphere(transform.position, 0.35f);
    }
}