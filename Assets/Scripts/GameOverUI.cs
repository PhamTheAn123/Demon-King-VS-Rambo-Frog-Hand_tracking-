using UnityEngine;
using TMPro;
using UnityEngine.UI;

/// <summary>
/// GameOverUI - Man hinh Game Over.
/// </summary>
public class GameOverUI : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject       panel;
    [SerializeField] private TextMeshProUGUI  scoreText;
    [SerializeField] private TextMeshProUGUI  highScoreText;
    [SerializeField] private Button           retryButton;
    [SerializeField] private Button           menuButton;

    private void Start()
    {
        if (panel != null) panel.SetActive(false);
        retryButton?.onClick.AddListener(() => GameManager.Instance?.RestartGame());
        menuButton?.onClick.AddListener(()  => GameManager.Instance?.GoToMainMenu());
    }

    public void Show(int score, int highScore)
    {
        if (panel != null) panel.SetActive(true);
        if (scoreText     != null) scoreText.text     = "Score: " + score.ToString("N0");
        if (highScoreText != null) highScoreText.text = "Best:  " + highScore.ToString("N0");
        Time.timeScale = 0f;
    }
}