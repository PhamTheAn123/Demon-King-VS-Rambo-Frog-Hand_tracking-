using System.Collections;
using UnityEngine;

/// <summary>
/// GunAmmoSystem - Component quan ly dan doc lap, gan them vao GunController.
/// Xu ly: ammo count, reserve, reload, UI update.
/// Tach biet de khong anh huong GunController goc.
/// </summary>
public class GunAmmoSystem : MonoBehaviour
{
    // â”€â”€ Ammo â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    [Header("Ammo Settings")]
    public int maxAmmo    = 30;
    public int currentAmmo;
    public int maxReserve  = 120;
    public int reserveAmmo;

    // â”€â”€ Reload â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    [Header("Reload")]
    public float reloadTime = 1.8f;
    public bool  autoReload = true;

    [Header("Audio")]
    public AudioClip reloadSound;
    public AudioClip emptySound;

    // â”€â”€ UI â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    [Header("UI")]
    [SerializeField] private BulletUI bulletUI;

    // â”€â”€ Private â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private bool        _isReloading;
    private AudioSource _audio;
    private GunController _gun;

    // â”€â”€ Events â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public System.Action<int, int> OnAmmoChanged;  // (current, reserve)
    public System.Action            OnReloadStart;
    public System.Action            OnReloadEnd;

    // â”€â”€ Properties â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public bool IsReloading  => _isReloading;
    public int  CurrentAmmo  => currentAmmo;
    public int  ReserveAmmo  => reserveAmmo;

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void Awake()
    {
        _gun  = GetComponent<GunController>();
        _audio = GetComponent<AudioSource>();
        if (_audio == null) _audio = gameObject.AddComponent<AudioSource>();
    }

    private void Start()
    {
        currentAmmo = maxAmmo;
        reserveAmmo = maxReserve;
        RefreshUI();
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !_isReloading && currentAmmo < maxAmmo && reserveAmmo > 0)
            StartCoroutine(DoReload());
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    /// <summary>Goi khi ban dan. Returns false neu khong du dan.</summary>
    public bool ConsumeAmmo(int amount = 1)
    {
        if (_isReloading) return false;

        if (currentAmmo < amount)
        {
            PlaySound(emptySound);
            if (autoReload && reserveAmmo > 0 && !_isReloading)
                StartCoroutine(DoReload());
            return false;
        }

        currentAmmo -= amount;
        RefreshUI();
        OnAmmoChanged?.Invoke(currentAmmo, reserveAmmo);

        if (currentAmmo <= 0 && autoReload && reserveAmmo > 0)
            StartCoroutine(DoReload());

        return true;
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public void AddAmmo(int amount)
    {
        reserveAmmo = Mathf.Min(reserveAmmo + amount, maxReserve);
        RefreshUI();
        OnAmmoChanged?.Invoke(currentAmmo, reserveAmmo);
    }

    public void RefillAllAmmo()
    {
        currentAmmo = maxAmmo;
        reserveAmmo = maxReserve;
        RefreshUI();
        OnAmmoChanged?.Invoke(currentAmmo, reserveAmmo);
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private IEnumerator DoReload()
    {
        _isReloading = true;
        OnReloadStart?.Invoke();
        PlaySound(reloadSound);
        Debug.Log($"[GunAmmoSystem] Dang reload... ({reloadTime}s)");

        yield return new WaitForSeconds(reloadTime);

        int needed  = maxAmmo - currentAmmo;
        int take    = Mathf.Min(needed, reserveAmmo);
        currentAmmo += take;
        reserveAmmo -= take;

        _isReloading = false;
        OnReloadEnd?.Invoke();
        RefreshUI();
        OnAmmoChanged?.Invoke(currentAmmo, reserveAmmo);
        Debug.Log($"[GunAmmoSystem] Reload xong! {currentAmmo}/{reserveAmmo}");
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void RefreshUI()
    {
        if (bulletUI != null) bulletUI.UpdateBullets(currentAmmo);
    }

    private void PlaySound(AudioClip clip)
    {
        if (_audio == null || clip == null) return;
        _audio.PlayOneShot(clip);
    }
}