using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Điều khiển UI panel cài đặt âm thanh.
/// Gắn script này vào GameObject chứa panel cài đặt.
/// Cần assign: musicSlider, sfxSlider qua Inspector.
/// </summary>
public class AudioSettingsPanel : MonoBehaviour
{
    [Header("Volume Sliders")]
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider sfxSlider;

    // ─── Unity lifecycle ──────────────────────────────────────────────────────
    private void OnEnable()
    {
        // Mỗi lần panel được mở, đồng bộ slider với giá trị hiện tại
        RefreshSliders();
    }

    private void Start()
    {
        // Đăng ký callback khi slider thay đổi
        if (musicSlider != null)
            musicSlider.onValueChanged.AddListener(OnMusicSliderChanged);

        if (sfxSlider != null)
            sfxSlider.onValueChanged.AddListener(OnSFXSliderChanged);

        RefreshSliders();
    }

    private void OnDestroy()
    {
        // Hủy đăng ký callback để tránh memory leak
        if (musicSlider != null)
            musicSlider.onValueChanged.RemoveListener(OnMusicSliderChanged);

        if (sfxSlider != null)
            sfxSlider.onValueChanged.RemoveListener(OnSFXSliderChanged);
    }

    // ─── Slider callbacks ─────────────────────────────────────────────────────
    private void OnMusicSliderChanged(float value)
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.SetMusicVolume(value);
    }

    private void OnSFXSliderChanged(float value)
    {
        if (AudioManager.Instance != null)
            AudioManager.Instance.SetSFXVolume(value);
    }

    // ─── Public methods (dùng cho Buttons) ───────────────────────────────────
    /// <summary>Nút "Reset về mặc định" — đặt cả 2 slider về 1.</summary>
    public void ResetToDefault()
    {
        if (AudioManager.Instance != null)
        {
            AudioManager.Instance.ResetVolumes();
            RefreshSliders();
        }
    }

    /// <summary>Đóng panel cài đặt.</summary>
    public void ClosePanel()
    {
        gameObject.SetActive(false);
    }

    // ─── Private helpers ──────────────────────────────────────────────────────
    /// <summary>Đồng bộ giá trị slider với AudioManager hiện tại.</summary>
    private void RefreshSliders()
    {
        if (AudioManager.Instance == null) return;

        if (musicSlider != null)
            musicSlider.SetValueWithoutNotify(AudioManager.Instance.MusicVolume);

        if (sfxSlider != null)
            sfxSlider.SetValueWithoutNotify(AudioManager.Instance.SFXVolume);
    }
}
