using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using DG.Tweening; // Import DOTween namespace

public class PlayerHealthUI : MonoBehaviour
{
    [Header("UI References")]
    public Image heartImage;
    public Sprite fullHeartSprite;
    public Sprite emptyHeartSprite;

    [Header("Color Settings")]
    public Color fullHeartColor = Color.red;
    public Color emptyHeartColor = new Color(0.2f, 0.2f, 0.2f, 0.6f); // Xám tối bán trong suốt cho giao diện hiện đại

    [Header("Animation Settings - Damage")]
    public float damagePunchDuration = 0.35f;
    public float damagePunchStrength = 0.4f;
    public int damageVibrato = 10;

    [Header("Animation Settings - Heal")]
    public float healScaleDuration = 0.4f;
    public float healScaleStrength = 0.3f;

    [Header("Animation Settings - Low Health Pulse")]
    public float pulseDuration = 0.3f;
    public float pulseScaleAmount = 1.2f;

    private List<Image> hearts = new List<Image>();
    private int lastHealth = -1;
    private bool isPulsing = false; // Theo dõi xem trái tim cuối cùng có đang đập nhịp tim không

    public void SetMaxHealth(int maxHealth)
    {
        // Dọn dẹp các tween cũ trên các object sắp bị hủy
        foreach (var heart in hearts)
        {
            if (heart != null)
            {
                heart.transform.DOKill();
                Destroy(heart.gameObject);
            }
        }
        hearts.Clear();
        isPulsing = false;

        for (int i = 0; i < maxHealth; i++)
        {
            Image newHeart = Instantiate(heartImage, transform);
            newHeart.sprite = fullHeartSprite;
            newHeart.color = fullHeartColor;
            newHeart.transform.localScale = Vector3.one;
            hearts.Add(newHeart);
        }

        lastHealth = maxHealth;
        UpdateHeartbeatPulse(maxHealth);
    }

    public void UpdateHeart(int currentHealth)
    {
        // Chạy qua danh sách tim và cập nhật trạng thái kèm animation
        for (int i = 0; i < hearts.Count; i++)
        {
            Image heart = hearts[i];
            if (heart == null) continue;

            bool isFull = i < currentHealth;

            if (isFull)
            {
                // Nếu trước đó tim này đang rỗng và giờ được hồi lại
                if (lastHealth != -1 && i >= lastHealth)
                {
                    heart.transform.DOKill();
                    heart.sprite = fullHeartSprite;
                    heart.color = fullHeartColor;
                    heart.transform.localScale = Vector3.zero;
                    
                    // Chỉ dùng DOScale với Ease.OutBack để tim nảy to ra và dừng lại ở kích thước 1.0 chuẩn (không bị đè bởi PunchScale khác)
                    heart.transform.DOScale(Vector3.one, healScaleDuration)
                        .SetEase(Ease.OutBack)
                        .SetUpdate(true);
                }
                else
                {
                    // Trạng thái bình thường không có transition (chỉ reset nếu không đang đập nhịp tim ở tim đầu tiên)
                    if (i != 0 || !isPulsing)
                    {
                        heart.sprite = fullHeartSprite;
                        heart.color = fullHeartColor;
                        heart.transform.localScale = Vector3.one;
                    }
                }
            }
            else
            {
                // Nếu trước đó tim này đang đầy và giờ bị mất (Damage)
                if (lastHealth != -1 && i < lastHealth)
                {
                    heart.transform.DOKill();
                    
                    // Đổi sang sprite rỗng và màu tối ngay lập tức để có phản hồi hình ảnh tức thì
                    heart.sprite = emptyHeartSprite;
                    heart.color = emptyHeartColor;
                    heart.transform.localScale = Vector3.one;

                    // Chạy hiệu ứng giật nảy tim rỗng (Bỏ qua timeScale để chạy mượt)
                    heart.transform.DOPunchScale(Vector3.one * damagePunchStrength, damagePunchDuration, damageVibrato, 1f)
                        .SetUpdate(true);
                }
                else
                {
                    // Trạng thái rỗng bình thường không có transition
                    heart.sprite = emptyHeartSprite;
                    heart.color = emptyHeartColor;
                    heart.transform.localScale = Vector3.one;
                }
            }
        }

        UpdateHeartbeatPulse(currentHealth);
        lastHealth = currentHealth;
    }

    /// <summary>
    /// Cập nhật nhịp tim đập liên tục khi người chơi chỉ còn 1 máu duy nhất
    /// </summary>
    private void UpdateHeartbeatPulse(int currentHealth)
    {
        // Chỉ đập tim khi còn đúng 1 máu
        if (currentHealth == 1 && hearts.Count > 0 && hearts[0] != null)
        {
            if (!isPulsing)
            {
                isPulsing = true;
                // Chạy hiệu ứng đập liên tục (nhịp tim) cho trái tim đầu tiên (Bỏ qua timeScale)
                hearts[0].transform.DOKill();
                hearts[0].transform.DOScale(Vector3.one * pulseScaleAmount, pulseDuration)
                    .SetEase(Ease.InOutSine)
                    .SetLoops(-1, LoopType.Yoyo)
                    .SetUpdate(true);
            }
        }
        else
        {
            // Nếu thoát khỏi trạng thái nguy kịch (hoặc chết), dừng đập nhịp tim ở tim đầu tiên
            if (isPulsing)
            {
                isPulsing = false;
                if (hearts.Count > 0 && hearts[0] != null)
                {
                    hearts[0].transform.DOKill();
                    hearts[0].transform.localScale = Vector3.one;
                }
            }
        }
    }

    private void OnDestroy()
    {
        // Dọn dẹp tất cả tweens để tránh memory leak
        foreach (var heart in hearts)
        {
            if (heart != null)
            {
                heart.transform.DOKill();
            }
        }
    }
}
