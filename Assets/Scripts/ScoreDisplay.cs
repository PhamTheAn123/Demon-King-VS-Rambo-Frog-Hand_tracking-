using UnityEngine;
using TMPro;

/// <summary>
/// ScoreDisplay - Hien thi diem so len UI.
/// Tu dong dang ky voi GameManager va cap nhat text.
/// </summary>
public class ScoreDisplay : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI highScoreText;
    [SerializeField] private string          scorePrefix     = "SCORE: ";
    [SerializeField] private string          highScorePrefix = "BEST: ";

    [Header("Smooth Count-up")]
    [SerializeField] private float lerpSpeed = 800f;

    [Header("Punch Animation")]
    [SerializeField] private bool  animateOnChange = true;
    [SerializeField] private float punchScale      = 1.3f;
    [SerializeField] private float punchDuration   = 0.15f;

    private int _displayedScore;
    private int _targetScore;

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void OnEnable()
    {
        if (GameManager.Instance == null) return;
        GameManager.Instance.OnScoreChanged += UpdateScore;
        _targetScore = _displayedScore = GameManager.Instance.score;
        RefreshText();
    }

    private void OnDisable()
    {
        if (GameManager.Instance != null)
            GameManager.Instance.OnScoreChanged -= UpdateScore;
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void Update()
    {
        if (_displayedScore == _targetScore) return;

        _displayedScore = (int)Mathf.MoveTowards(_displayedScore, _targetScore, lerpSpeed * Time.deltaTime);
        RefreshText();
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void RefreshText()
    {
        if (scoreText     != null) scoreText.text     = scorePrefix + _displayedScore.ToString("N0");
        if (highScoreText != null && GameManager.Instance != null)
            highScoreText.text = highScorePrefix + GameManager.Instance.highScore.ToString("N0");
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void UpdateScore(int newScore)
    {
        _targetScore = newScore;
        if (animateOnChange) StartCoroutine(PunchAnim());
    }

    private System.Collections.IEnumerator PunchAnim()
    {
        transform.localScale = Vector3.one * punchScale;
        float t = 0f;
        while (t < punchDuration)
        {
            transform.localScale = Vector3.Lerp(Vector3.one * punchScale, Vector3.one, t / punchDuration);
            t += Time.deltaTime;
            yield return null;
        }
        transform.localScale = Vector3.one;
    }
}