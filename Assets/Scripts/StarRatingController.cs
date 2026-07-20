using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

/// <summary>
/// Gắn script này vào một GameObject bất kỳ trong scene.
/// Kéo 5 Image ngôi sao vào mảng StarImages trong Inspector (theo thứ tự sao 1 → sao 5).
/// - Hover vào sao: preview sáng lên đến sao đó
/// - Rời chuột: về lại rating đã chọn
/// - Click: chốt rating
/// </summary>
public class StarRatingController : MonoBehaviour
{
    [Header("Kéo 5 Image ngôi sao vào đây theo thứ tự (sao 1 → sao 5)")]
    public Image[] starImages;

    [Header("Màu sắc")]
    public Color colorOn      = new Color(1f,    0.80f, 0.10f, 1f); // vàng — đã chọn
    public Color colorHover   = new Color(1f,    0.95f, 0.50f, 1f); // vàng nhạt — hover preview
    public Color colorOff     = new Color(0.35f, 0.35f, 0.35f, 1f); // xám — chưa chọn

    [Header("Rating hiện tại")]
    [Range(1, 5)]
    public int currentRating = 5;

    private FeedbackManager _feedbackManager;

    void Start()
    {
        _feedbackManager = FindAnyObjectByType<FeedbackManager>();

        for (int i = 0; i < starImages.Length; i++)
        {
            if (starImages[i] == null) continue;

            starImages[i].raycastTarget = true;

            // Xóa handler cũ nếu có
            StarClickHandler old = starImages[i].GetComponent<StarClickHandler>();
            if (old != null) Destroy(old);

            StarClickHandler handler = starImages[i].gameObject.AddComponent<StarClickHandler>();
            handler.Init(i + 1, this);
        }

        Refresh(currentRating, colorOn);
    }

    /// <summary>Preview hover — gọi bởi StarClickHandler khi chuột vào</summary>
    public void OnHoverEnter(int starIndex)
    {
        // Sao từ 1..starIndex: màu hover (vàng nhạt)
        // Sao từ starIndex+1..5: màu xám
        for (int i = 0; i < starImages.Length; i++)
        {
            if (starImages[i] == null) continue;
            starImages[i].color = (i < starIndex) ? colorHover : colorOff;
        }
    }

    /// <summary>Khôi phục về rating đã chọn — gọi khi chuột rời</summary>
    public void OnHoverExit()
    {
        Refresh(currentRating, colorOn);
    }

    /// <summary>Chốt rating khi click — gọi bởi StarClickHandler</summary>
    public void SetRating(int rating)
    {
        currentRating = Mathf.Clamp(rating, 1, 5);
        Refresh(currentRating, colorOn);

        if (_feedbackManager != null)
            _feedbackManager.SetStarRating(currentRating);
    }

    private void Refresh(int rating, Color onColor)
    {
        if (starImages == null) return;
        for (int i = 0; i < starImages.Length; i++)
        {
            if (starImages[i] == null) continue;
            starImages[i].color = (i < rating) ? onColor : colorOff;
        }
    }

    public int GetRating() => currentRating;
}

/// <summary>
/// Component gắn lên từng ngôi sao.
/// Xử lý hover preview và click để chốt rating.
/// </summary>
public class StarClickHandler : MonoBehaviour,
    IPointerClickHandler,
    IPointerEnterHandler,
    IPointerExitHandler
{
    private int _starIndex;
    private StarRatingController _controller;

    public void Init(int starIndex, StarRatingController controller)
    {
        _starIndex  = starIndex;
        _controller = controller;
    }

    /// <summary>Chuột hover vào → preview sáng</summary>
    public void OnPointerEnter(PointerEventData eventData)
    {
        _controller?.OnHoverEnter(_starIndex);
    }

    /// <summary>Chuột rời ra → về lại rating đã chọn</summary>
    public void OnPointerExit(PointerEventData eventData)
    {
        _controller?.OnHoverExit();
    }

    /// <summary>Click → chốt rating</summary>
    public void OnPointerClick(PointerEventData eventData)
    {
        _controller?.SetRating(_starIndex);
    }
}
