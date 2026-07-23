using UnityEngine;

/// <summary>
/// Singleton AudioManager that persists across scenes.
/// Manages Music and SFX volume independently, saving settings via PlayerPrefs.
/// </summary>
public class AudioManager : MonoBehaviour
{
    // ─── Singleton ───────────────────────────────────────────────────────────
    public static AudioManager Instance { get; private set; }

    // ─── PlayerPrefs keys ────────────────────────────────────────────────────
    private const string MUSIC_VOLUME_KEY = "MusicVolume";
    private const string SFX_VOLUME_KEY   = "SFXVolume";

    // ─── Inspector references ─────────────────────────────────────────────────
    [Header("Audio Sources")]
    public AudioSource musicSource;
    public AudioSource vfxSource;

    [Header("Default Clips")]
    public AudioClip musicClip;

    // ─── Volume properties ────────────────────────────────────────────────────
    /// <summary>Current music volume in [0, 1]. Automatically saved to PlayerPrefs.</summary>
    public float MusicVolume
    {
        get => musicSource != null ? musicSource.volume : 0f;
        set
        {
            float v = Mathf.Clamp01(value);
            if (musicSource != null) musicSource.volume = v;
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, v);
            PlayerPrefs.Save();
        }
    }

    /// <summary>Current SFX volume in [0, 1]. Automatically saved to PlayerPrefs.</summary>
    public float SFXVolume
    {
        get => vfxSource != null ? vfxSource.volume : 0f;
        set
        {
            float v = Mathf.Clamp01(value);
            if (vfxSource != null) vfxSource.volume = v;
            PlayerPrefs.SetFloat(SFX_VOLUME_KEY, v);
            PlayerPrefs.Save();
        }
    }

    // ─── Unity lifecycle ──────────────────────────────────────────────────────
    private void Awake()
    {
        // Singleton pattern: chỉ giữ một instance duy nhất
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadVolumes();
    }

    private void Start()
    {
        if (musicSource != null && musicClip != null)
        {
            musicSource.clip = musicClip;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    // ─── Public API ───────────────────────────────────────────────────────────
    /// <summary>Set music volume (0–1). Called by UI Slider.</summary>
    public void SetMusicVolume(float value) => MusicVolume = value;

    /// <summary>Set SFX volume (0–1). Called by UI Slider.</summary>
    public void SetSFXVolume(float value) => SFXVolume = value;

    /// <summary>Play a one-shot SFX clip at current SFX volume.</summary>
    public void PlaySFX(AudioClip clip)
    {
        if (vfxSource != null && clip != null)
            vfxSource.PlayOneShot(clip, SFXVolume);
    }

    /// <summary>Reset both volumes to 1 and save.</summary>
    public void ResetVolumes()
    {
        MusicVolume = 1f;
        SFXVolume   = 1f;
    }

    // ─── Private helpers ──────────────────────────────────────────────────────
    private void LoadVolumes()
    {
        // Đọc volume đã lưu, mặc định = 1 nếu chưa có
        float music = PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY, 1f);
        float sfx   = PlayerPrefs.GetFloat(SFX_VOLUME_KEY,   1f);

        if (musicSource != null) musicSource.volume = music;
        if (vfxSource   != null) vfxSource.volume   = sfx;
    }
}
