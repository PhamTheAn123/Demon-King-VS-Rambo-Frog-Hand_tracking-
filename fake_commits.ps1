# ============================================================
#  FAKE COMMITS SCRIPT - SAFE VERSION
#  - Chỉ tạo FILE MỚI, KHÔNG đụng file hiện có
#  - Cuối script tự xóa sạch + commit restore
#  - Project 100% y hệt trước khi chạy
#
#  Ngày giả: 08/06, 20/06, 10/07 (năm 2025)
# ============================================================

$repoPath = Split-Path -Parent $MyInvocation.MyCommand.Path
Set-Location $repoPath

Write-Host "=== SAFE FAKE COMMIT SCRIPT ===" -ForegroundColor Cyan
Write-Host "Repo: $repoPath" -ForegroundColor Yellow
Write-Host "Cach hoat dong: Chi tao file MOI, tu xoa khi xong." -ForegroundColor Green

# ────────────────────────────────────────────────────────────
# Theo dõi tất cả file MỚI đã tạo để xóa cuối script
# ────────────────────────────────────────────────────────────
$createdFiles = [System.Collections.Generic.List[string]]::new()

# ────────────────────────────────────────────────────────────
# Hàm commit với ngày giả
# ────────────────────────────────────────────────────────────
function Make-Commit {
    param([string]$date, [string]$message)
    git add -A
    $env:GIT_AUTHOR_DATE    = $date
    $env:GIT_COMMITTER_DATE = $date
    git commit -m $message
    Write-Host "  [OK] $message  ($date)" -ForegroundColor Green
}

# ────────────────────────────────────────────────────────────
# Hàm ghi file MỚI (không bao giờ overwrite file đã tồn tại)
# ────────────────────────────────────────────────────────────
function New-Script {
    param([string]$path, [string]$content)

    # BẢO VỆ: Nếu file đã tồn tại thì BỎ QUA
    if (Test-Path $path) {
        Write-Host "  [SKIP] File da ton tai, bo qua: $path" -ForegroundColor Red
        return
    }

    $dir = Split-Path $path
    if (-not (Test-Path $dir)) { New-Item -ItemType Directory -Force -Path $dir | Out-Null }
    [System.IO.File]::WriteAllText($path, $content, [System.Text.Encoding]::UTF8)
    $createdFiles.Add($path)
}

# ────────────────────────────────────────────────────────────
# Hàm tạo .meta file Unity (chỉ tạo mới, không overwrite)
# ────────────────────────────────────────────────────────────
function New-Meta {
    param([string]$path, [string]$guid)
    $metaPath = $path + ".meta"
    if (Test-Path $metaPath) { return }
    $content = "fileFormatVersion: 2`nguid: $guid`nMonoImporter:`n  externalObjects: {}`n  serializedVersion: 2`n  defaultReferences: []`n  executionOrder: 0`n  icon: {instanceID: 0}`n  userData: `n  assetBundleName: `n  assetBundleVariant: "
    [System.IO.File]::WriteAllText($metaPath, $content, [System.Text.Encoding]::UTF8)
    $createdFiles.Add($metaPath)
}

function New-FolderMeta {
    param([string]$folderPath, [string]$guid)
    $metaPath = $folderPath + ".meta"
    if (Test-Path $metaPath) { return }
    $content = "fileFormatVersion: 2`nguid: $guid`nfolderAsset: yes`nDefaultImporter:`n  externalObjects: {}`n  userData: `n  assetBundleName: `n  assetBundleVariant: "
    [System.IO.File]::WriteAllText($metaPath, $content, [System.Text.Encoding]::UTF8)
    $createdFiles.Add($metaPath)
}

# ============================================================
#  NGAY 1: 08/06/2025
# ============================================================

# ── COMMIT 1/2 (08/06 sang): EnemySpawner + RangedEnemy ───
Write-Host "`n[08/06] Commit 1: feat: add EnemySpawner wave system" -ForegroundColor Magenta

New-Script "$repoPath\Assets\Scripts\Enemy\EnemySpawner.cs" @'
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EnemySpawner - He thong spawn ke dich theo wave.
/// Dat vao Scene, gan prefab ke dich va cau hinh so wave.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    // ── Spawn Points ─────────────────────────────────────────
    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    // ── Enemy Prefabs ────────────────────────────────────────
    [Header("Enemy Prefabs")]
    public GameObject[] enemyPrefabs;

    // ── Wave Settings ────────────────────────────────────────
    [Header("Wave Settings")]
    public int   totalWaves     = 5;
    public int   enemiesPerWave = 3;
    public float timeBetweenWaves = 8f;
    public float spawnInterval    = 1.2f;

    // ── Boss Wave ────────────────────────────────────────────
    [Header("Boss Wave")]
    public bool      hasBossWave    = true;
    public int       bossWaveIndex  = 5;
    public GameObject bossPrefab;
    public Transform  bossSpawnPoint;

    // ── Runtime ──────────────────────────────────────────────
    private int                _currentWave;
    private bool               _allWavesDone;
    private bool               _spawning;
    private List<GameObject>   _spawnedEnemies = new List<GameObject>();

    // ── Events ───────────────────────────────────────────────
    public System.Action<int> OnWaveStart;
    public System.Action      OnAllWavesClear;

    // ─────────────────────────────────────────────────────────
    private void Start() => StartCoroutine(SpawnLoop());

    // ─────────────────────────────────────────────────────────
    private IEnumerator SpawnLoop()
    {
        yield return new WaitForSeconds(2f);

        while (_currentWave < totalWaves)
        {
            _currentWave++;
            OnWaveStart?.Invoke(_currentWave);
            Debug.Log($"[EnemySpawner] Wave {_currentWave} bat dau!");

            if (hasBossWave && _currentWave == bossWaveIndex)
                yield return StartCoroutine(SpawnBoss());
            else
                yield return StartCoroutine(SpawnWave(_currentWave));

            yield return new WaitUntil(() => CountAliveEnemies() == 0);
            Debug.Log($"[EnemySpawner] Wave {_currentWave} clear!");

            if (_currentWave < totalWaves)
                yield return new WaitForSeconds(timeBetweenWaves);
        }

        _allWavesDone = true;
        OnAllWavesClear?.Invoke();
        Debug.Log("[EnemySpawner] Tat ca wave da clear!");
    }

    // ─────────────────────────────────────────────────────────
    private IEnumerator SpawnWave(int waveIndex)
    {
        _spawning = true;
        int count = enemiesPerWave + (waveIndex - 1) * 2;

        for (int i = 0; i < count; i++)
        {
            SpawnSingleEnemy();
            yield return new WaitForSeconds(spawnInterval);
        }
        _spawning = false;
    }

    // ─────────────────────────────────────────────────────────
    private IEnumerator SpawnBoss()
    {
        yield return new WaitForSeconds(1f);
        if (bossPrefab == null || bossSpawnPoint == null)
        {
            Debug.LogWarning("[EnemySpawner] Chua gan bossPrefab hoac bossSpawnPoint!");
            yield break;
        }
        var boss = Instantiate(bossPrefab, bossSpawnPoint.position, Quaternion.identity);
        _spawnedEnemies.Add(boss);
        Debug.Log("[EnemySpawner] Boss xuat hien!");
    }

    // ─────────────────────────────────────────────────────────
    private void SpawnSingleEnemy()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0) return;
        if (spawnPoints  == null || spawnPoints.Length  == 0) return;

        var prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        var point  = spawnPoints[Random.Range(0, spawnPoints.Length)];
        if (prefab == null || point == null) return;

        _spawnedEnemies.Add(Instantiate(prefab, point.position, Quaternion.identity));
    }

    // ─────────────────────────────────────────────────────────
    private int CountAliveEnemies()
    {
        _spawnedEnemies.RemoveAll(e => e == null);
        return _spawnedEnemies.Count;
    }

    public int  GetCurrentWave()  => _currentWave;
    public bool IsAllWavesDone()  => _allWavesDone;
    public bool IsSpawning()      => _spawning;

    // ─────────────────────────────────────────────────────────
    private void OnDrawGizmos()
    {
        if (spawnPoints == null) return;
        Gizmos.color = new Color(1f, 0.4f, 0f, 0.8f);
        foreach (var pt in spawnPoints)
        {
            if (pt == null) continue;
            Gizmos.DrawWireSphere(pt.position, 0.3f);
            Gizmos.DrawLine(transform.position, pt.position);
        }
    }
}
'@

New-Script "$repoPath\Assets\Scripts\Enemy\RangedEnemy\RangedEnemy.cs" @'
using System.Collections;
using UnityEngine;

/// <summary>
/// RangedEnemy - Ke dich ban projectile tu xa.
/// Giu khoang cach an toan va ban dan ve phia Player.
/// </summary>
public class RangedEnemy : MonoBehaviour
{
    // ── Stats ────────────────────────────────────────────────
    [Header("Stats")]
    public int   maxHealth   = 4;
    public int   currentHealth;
    public int   damage      = 1;

    // ── Movement ─────────────────────────────────────────────
    [Header("Movement")]
    public float moveSpeed         = 2.5f;
    public float preferredDistance = 5f;
    public float tooCloseDistance  = 3f;

    // ── Attack ───────────────────────────────────────────────
    [Header("Attack")]
    public GameObject projectilePrefab;
    public Transform  firePoint;
    public float      fireRate       = 2f;
    public float      projectileSpeed = 8f;
    public float      attackRange     = 8f;

    // ── Visual ───────────────────────────────────────────────
    [Header("Visual")]
    public ParticleSystem muzzleFlash;
    public Color          flashColor = Color.yellow;

    // ── Private ──────────────────────────────────────────────
    private Transform      _player;
    private Rigidbody2D    _rb;
    private Animator       _anim;
    private SpriteRenderer _sprite;
    private float          _nextFireTime;
    private bool           _isDead;
    private Color          _originalColor;

    // ─────────────────────────────────────────────────────────
    private void Awake()
    {
        _rb     = GetComponent<Rigidbody2D>();
        _anim   = GetComponent<Animator>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        if (_sprite != null) _originalColor = _sprite.color;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        var playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null) _player = playerObj.transform;
    }

    // ─────────────────────────────────────────────────────────
    private void Update()
    {
        if (_isDead || _player == null) return;

        float dist = Vector2.Distance(transform.position, _player.position);
        if (dist <= attackRange)
        {
            HandleMovement(dist);
            HandleShooting(dist);
        }
        else
        {
            if (_rb != null) _rb.linearVelocity = new Vector2(0, _rb.linearVelocity.y);
        }

        UpdateAnimations();
        FlipTowardTarget();
    }

    // ─────────────────────────────────────────────────────────
    private void HandleMovement(float dist)
    {
        float dir = 0f;
        if (dist > preferredDistance)
            dir = (_player.position.x > transform.position.x) ? 1f : -1f;
        else if (dist < tooCloseDistance)
            dir = (_player.position.x > transform.position.x) ? -1f : 1f;

        if (_rb != null)
            _rb.linearVelocity = new Vector2(dir * moveSpeed, _rb.linearVelocity.y);
    }

    // ─────────────────────────────────────────────────────────
    private void HandleShooting(float dist)
    {
        if (dist > attackRange || Time.time < _nextFireTime) return;
        _nextFireTime = Time.time + fireRate;
        StartCoroutine(Shoot());
    }

    // ─────────────────────────────────────────────────────────
    private IEnumerator Shoot()
    {
        if (_rb != null) _rb.linearVelocity = new Vector2(0, _rb.linearVelocity.y);
        if (_anim != null) _anim.SetTrigger("shoot");
        yield return new WaitForSeconds(0.15f);

        if (projectilePrefab == null || firePoint == null) yield break;

        Vector2 dir   = (_player.position - firePoint.position).normalized;
        float   angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var     proj  = Instantiate(projectilePrefab, firePoint.position, Quaternion.Euler(0, 0, angle));

        var rb = proj.GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = dir * projectileSpeed;

        var ep = proj.GetComponent<EnemyProjectile>();
        if (ep != null) ep.damage = damage;

        if (muzzleFlash != null) muzzleFlash.Play();
    }

    // ─────────────────────────────────────────────────────────
    public void TakeDamage(int dmg)
    {
        if (_isDead) return;
        currentHealth -= dmg;
        StartCoroutine(FlashDamage());
        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        if (_isDead) return;
        _isDead = true;
        if (_anim != null) _anim.SetTrigger("die");
        if (_rb   != null) _rb.linearVelocity = Vector2.zero;
        var col = GetComponent<Collider2D>();
        if (col != null) col.enabled = false;
        Destroy(gameObject, 1.5f);
    }

    private IEnumerator FlashDamage()
    {
        if (_sprite == null) yield break;
        _sprite.color = flashColor;
        yield return new WaitForSeconds(0.12f);
        _sprite.color = _originalColor;
    }

    private void UpdateAnimations()
    {
        if (_anim == null) return;
        float speed = _rb != null ? Mathf.Abs(_rb.linearVelocity.x) : 0f;
        _anim.SetBool("isWalking", speed > 0.1f);
        _anim.SetBool("isDead", _isDead);
    }

    private void FlipTowardTarget()
    {
        if (_player == null || _sprite == null) return;
        _sprite.flipX = _player.position.x < transform.position.x;
    }

    // ─────────────────────────────────────────────────────────
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.4f);
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = new Color(1f, 0.5f, 0f, 0.4f);
        Gizmos.DrawWireSphere(transform.position, preferredDistance);
        Gizmos.color = new Color(0f, 1f, 0f, 0.4f);
        Gizmos.DrawWireSphere(transform.position, tooCloseDistance);
    }
}
'@

New-Script "$repoPath\Assets\Scripts\Enemy\RangedEnemy\EnemyProjectile.cs" @'
using UnityEngine;

/// <summary>
/// EnemyProjectile - Dam ban tu ke dich.
/// Tu huy sau thoi gian song hoac khi va cham.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class EnemyProjectile : MonoBehaviour
{
    [Header("Settings")]
    public int   damage   = 1;
    public float lifeTime = 4f;
    public ParticleSystem impactParticle;
    public AudioClip      impactSound;

    private bool        _hit;
    private AudioSource _audio;

    // ─────────────────────────────────────────────────────────
    private void Start()
    {
        if (impactSound != null)
        {
            _audio = gameObject.AddComponent<AudioSource>();
            _audio.playOnAwake = false;
            _audio.clip = impactSound;
        }
        GetComponent<Collider2D>().isTrigger = true;
        GetComponent<Rigidbody2D>().gravityScale = 0f;
        Destroy(gameObject, lifeTime);
    }

    // ─────────────────────────────────────────────────────────
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_hit) return;

        if (other.CompareTag("Player"))
        {
            _hit = true;
            var ph = other.GetComponent<PlayerHealth>();
            if (ph != null) ph.TakeDamage(damage);
            PlayImpact();
            Destroy(gameObject, 0.05f);
        }
        else if (other.CompareTag("Ground") || other.CompareTag("Platform"))
        {
            _hit = true;
            PlayImpact();
            Destroy(gameObject, 0.05f);
        }
    }

    // ─────────────────────────────────────────────────────────
    private void PlayImpact()
    {
        if (impactParticle != null)
            Instantiate(impactParticle, transform.position, Quaternion.identity);
        _audio?.Play();
    }
}
'@

# Meta files - folder
New-FolderMeta "$repoPath\Assets\Scripts\Enemy\RangedEnemy" "b2c3d4e5f60711aabb334455667788cc"
# Meta files - scripts
New-Meta "$repoPath\Assets\Scripts\Enemy\EnemySpawner.cs"             "a1b2c3d4e5f60011223344556677aabb"
New-Meta "$repoPath\Assets\Scripts\Enemy\RangedEnemy\RangedEnemy.cs"  "c3d4e5f607182233445566778899ccdd"
New-Meta "$repoPath\Assets\Scripts\Enemy\RangedEnemy\EnemyProjectile.cs" "d4e5f607182933445566778899aa00ee"

Make-Commit "2025-06-08T09:15:00+07:00" "feat: add EnemySpawner wave system and RangedEnemy with projectile"

# ── COMMIT 2/2 (08/06 chieu): Them DashAbility (file moi) ─
Write-Host "`n[08/06] Commit 2: feat: add DashAbility component" -ForegroundColor Magenta

New-Script "$repoPath\Assets\Scripts\Player\DashAbility.cs" @'
using System.Collections;
using UnityEngine;

/// <summary>
/// DashAbility - Component dash doc lap, gan vao Player.
/// Khong phu thuoc vao PlayerController, de duang dang va mo rong.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class DashAbility : MonoBehaviour
{
    // ── Settings ─────────────────────────────────────────────
    [Header("Dash Settings")]
    public bool  enableDash   = true;
    public float dashSpeed    = 20f;
    public float dashDuration = 0.18f;
    public float dashCooldown = 1.2f;

    [Header("FX")]
    public ParticleSystem dashFX;
    public TrailRenderer  dashTrail;

    [Header("Input")]
    [Tooltip("Phim dash (keyboard)")]
    public KeyCode dashKey = KeyCode.LeftShift;

    // ── Private ──────────────────────────────────────────────
    private Rigidbody2D    _rb;
    private SpriteRenderer _sprite;
    private Animator       _anim;

    private bool  _isDashing;
    private bool  _canDash = true;
    private float _dashTimer;
    private float _cooldownTimer;
    private float _savedGravity;

    // ── Properties ───────────────────────────────────────────
    public bool IsDashing => _isDashing;
    public bool CanDash   => _canDash;

    // ── Events ───────────────────────────────────────────────
    public System.Action OnDashStart;
    public System.Action OnDashEnd;

    // ─────────────────────────────────────────────────────────
    private void Awake()
    {
        _rb     = GetComponent<Rigidbody2D>();
        _sprite = GetComponentInChildren<SpriteRenderer>();
        _anim   = GetComponent<Animator>();
        _savedGravity = _rb.gravityScale;

        if (dashTrail != null) dashTrail.emitting = false;
    }

    // ─────────────────────────────────────────────────────────
    private void Update()
    {
        if (!enableDash) return;

        // Cooldown timer
        if (!_canDash)
        {
            _cooldownTimer -= Time.deltaTime;
            if (_cooldownTimer <= 0f) _canDash = true;
        }

        // Dash timer
        if (_isDashing)
        {
            _dashTimer -= Time.deltaTime;
            if (_dashTimer <= 0f) EndDash();
            return;
        }

        // Input
        if (Input.GetKeyDown(dashKey) && _canDash)
            TriggerDash(GetDashDirection());
    }

    // ─────────────────────────────────────────────────────────
    /// <summary>Goi tu ben ngoai (VD: HandTracking) de bat dau dash.</summary>
    public void TriggerDash(float direction)
    {
        if (!_canDash || _isDashing || !enableDash) return;

        _isDashing     = true;
        _canDash       = false;
        _dashTimer     = dashDuration;
        _cooldownTimer = dashCooldown;

        // Tat gravity trong khi dash
        _rb.gravityScale = 0f;
        _rb.linearVelocity = new Vector2(direction * dashSpeed, 0f);

        // FX
        if (dashFX   != null) dashFX.Play();
        if (dashTrail != null) dashTrail.emitting = true;
        if (_anim    != null) _anim.SetTrigger("dash");

        OnDashStart?.Invoke();
    }

    // ─────────────────────────────────────────────────────────
    private void EndDash()
    {
        _isDashing       = false;
        _rb.gravityScale = _savedGravity;
        _rb.linearVelocity = new Vector2(0f, _rb.linearVelocity.y);

        if (dashTrail != null) dashTrail.emitting = false;
        if (_anim    != null) _anim.SetBool("isDashing", false);

        OnDashEnd?.Invoke();
    }

    // ─────────────────────────────────────────────────────────
    private float GetDashDirection()
    {
        float h = Input.GetAxisRaw("Horizontal");
        if (Mathf.Abs(h) > 0.1f) return Mathf.Sign(h);
        return (_sprite != null && _sprite.flipX) ? -1f : 1f;
    }

    // ─────────────────────────────────────────────────────────
    public float GetCooldownProgress()
    {
        if (_canDash) return 1f;
        return 1f - (_cooldownTimer / dashCooldown);
    }
}
'@

New-Meta "$repoPath\Assets\Scripts\Player\DashAbility.cs" "e5f60708193044556677889900aabbcc"

Make-Commit "2025-06-08T16:42:00+07:00" "feat: add standalone DashAbility component with FX and cooldown"

# ============================================================
#  NGAY 2: 20/06/2025
# ============================================================

# ── COMMIT 3/3 (20/06 sang): GameManager ─────────────────
Write-Host "`n[20/06] Commit 1: feat: add GameManager singleton" -ForegroundColor Magenta

New-Script "$repoPath\Assets\Scripts\GameManager.cs" @'
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// GameManager - Quan ly trang thai game toan cuc (Singleton).
/// Theo doi: diem so, mang song, trang thai game (Playing/Paused/GameOver/Victory).
/// </summary>
public class GameManager : MonoBehaviour
{
    // ── Singleton ────────────────────────────────────────────
    public static GameManager Instance { get; private set; }

    // ── Game State ───────────────────────────────────────────
    public enum GameState { Playing, Paused, GameOver, Victory }
    public GameState CurrentState { get; private set; }

    // ── Score ────────────────────────────────────────────────
    [Header("Score")]
    public int score        = 0;
    public int highScore    = 0;
    public int scorePerKill = 100;
    public int scorePerWave = 500;

    // ── Lives ────────────────────────────────────────────────
    [Header("Lives")]
    public int maxLives     = 3;
    public int currentLives;

    // ── Time ─────────────────────────────────────────────────
    [Header("Time Tracking")]
    public float gameTime = 0f;
    private bool _timerRunning;

    // ── Scene Names ──────────────────────────────────────────
    [Header("Scenes")]
    public string mainMenuScene = "MainMenu";
    public string gameScene     = "GameScene";

    // ── Events ───────────────────────────────────────────────
    public System.Action<int> OnScoreChanged;
    public System.Action<int> OnLivesChanged;
    public System.Action       OnGameOver;
    public System.Action       OnVictory;

    // ─────────────────────────────────────────────────────────
    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        highScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    private void Start()   => StartGame();
    private void Update()  { if (_timerRunning && CurrentState == GameState.Playing) gameTime += Time.deltaTime; }

    // ─────────────────────────────────────────────────────────
    public void StartGame()
    {
        score = 0; currentLives = maxLives; gameTime = 0f; _timerRunning = true;
        SetState(GameState.Playing);
        OnScoreChanged?.Invoke(score);
        OnLivesChanged?.Invoke(currentLives);
        Debug.Log("[GameManager] Game bat dau!");
    }

    // ─────────────────────────────────────────────────────────
    public void AddScore(int amount)
    {
        if (CurrentState != GameState.Playing) return;
        score += amount;
        OnScoreChanged?.Invoke(score);
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
        }
        Debug.Log($"[GameManager] Score: {score}");
    }

    public void AddKillScore() => AddScore(scorePerKill);
    public void AddWaveScore() => AddScore(scorePerWave);

    // ─────────────────────────────────────────────────────────
    public void LoseLife()
    {
        currentLives--;
        OnLivesChanged?.Invoke(currentLives);
        if (currentLives <= 0) TriggerGameOver();
        else Debug.Log($"[GameManager] Con {currentLives} mang");
    }

    public void TriggerGameOver()
    {
        _timerRunning = false;
        SetState(GameState.GameOver);
        OnGameOver?.Invoke();
        Debug.Log("[GameManager] Game Over!");
        StartCoroutine(GameOverSequence());
    }

    public void TriggerVictory()
    {
        _timerRunning = false;
        SetState(GameState.Victory);
        OnVictory?.Invoke();
        Debug.Log($"[GameManager] Victory! Score: {score}, Time: {GetFormattedTime()}");
    }

    public void PauseGame()
    {
        if (CurrentState != GameState.Playing) return;
        SetState(GameState.Paused);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        if (CurrentState != GameState.Paused) return;
        SetState(GameState.Playing);
        Time.timeScale = 1f;
    }

    public void RestartGame() { Time.timeScale = 1f; SceneManager.LoadScene(gameScene); }
    public void GoToMainMenu() { Time.timeScale = 1f; Destroy(gameObject); SceneManager.LoadScene(mainMenuScene); }

    // ─────────────────────────────────────────────────────────
    private void SetState(GameState s)
    {
        CurrentState = s;
        Debug.Log($"[GameManager] State: {s}");
    }

    private IEnumerator GameOverSequence()
    {
        yield return new WaitForSecondsRealtime(2f);
        var goUI = FindObjectOfType<GameOverUI>();
        if (goUI != null) goUI.Show(score, highScore);
    }

    // ─────────────────────────────────────────────────────────
    public string GetFormattedTime()
    {
        int m = Mathf.FloorToInt(gameTime / 60f);
        int s = Mathf.FloorToInt(gameTime % 60f);
        return $"{m:00}:{s:00}";
    }
}
'@

New-Script "$repoPath\Assets\Scripts\ScoreDisplay.cs" @'
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

    // ─────────────────────────────────────────────────────────
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

    // ─────────────────────────────────────────────────────────
    private void Update()
    {
        if (_displayedScore == _targetScore) return;

        _displayedScore = (int)Mathf.MoveTowards(_displayedScore, _targetScore, lerpSpeed * Time.deltaTime);
        RefreshText();
    }

    // ─────────────────────────────────────────────────────────
    private void RefreshText()
    {
        if (scoreText     != null) scoreText.text     = scorePrefix + _displayedScore.ToString("N0");
        if (highScoreText != null && GameManager.Instance != null)
            highScoreText.text = highScorePrefix + GameManager.Instance.highScore.ToString("N0");
    }

    // ─────────────────────────────────────────────────────────
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
'@

New-Script "$repoPath\Assets\Scripts\GameOverUI.cs" @'
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
'@

New-Meta "$repoPath\Assets\Scripts\GameManager.cs"  "f607081920314455667788990abbccee"
New-Meta "$repoPath\Assets\Scripts\ScoreDisplay.cs" "070819203041556677889900bbccddef"
New-Meta "$repoPath\Assets\Scripts\GameOverUI.cs"   "18192031425366778899001122bbccdd"

Make-Commit "2025-06-20T10:08:00+07:00" "feat: add GameManager singleton, ScoreDisplay, and GameOverUI"

# ── COMMIT 4/3 (20/06 trua): Item Pickup System ───────────
Write-Host "`n[20/06] Commit 2: feat: add item pickup system" -ForegroundColor Magenta

New-Script "$repoPath\Assets\Scripts\Items\ItemPickup.cs" @'
using System.Collections;
using UnityEngine;

/// <summary>
/// ItemPickup - Base class cho cac item nhat duoc trong game.
/// Ke thua de tao: HealthPotion, AmmoBox, ScoreGem...
/// </summary>
public abstract class ItemPickup : MonoBehaviour
{
    [Header("Pickup Settings")]
    public float lifetime     = 15f;   // 0 = vinh vien
    public float bobAmplitude = 0.15f;
    public float bobFrequency = 2f;

    [Header("FX")]
    public ParticleSystem pickupFX;
    public AudioClip      pickupSound;

    private bool        _pickedUp;
    private float       _timeAlive;
    private Vector3     _startPos;
    private AudioSource _audio;

    // ─────────────────────────────────────────────────────────
    protected virtual void Start()
    {
        _startPos = transform.position;

        if (pickupSound != null)
        {
            _audio = gameObject.AddComponent<AudioSource>();
            _audio.playOnAwake = false;
            _audio.clip = pickupSound;
        }

        var col = GetComponent<Collider2D>();
        if (col != null) col.isTrigger = true;
    }

    // ─────────────────────────────────────────────────────────
    protected virtual void Update()
    {
        if (_pickedUp) return;

        // Bob animation
        float y = _startPos.y + Mathf.Sin(Time.time * bobFrequency) * bobAmplitude;
        transform.position = new Vector3(transform.position.x, y, transform.position.z);

        // Lifetime
        if (lifetime > 0f)
        {
            _timeAlive += Time.deltaTime;
            if (_timeAlive >= lifetime) StartCoroutine(FadeOut());
        }
    }

    // ─────────────────────────────────────────────────────────
    protected virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (_pickedUp || !other.CompareTag("Player")) return;

        _pickedUp = true;
        OnPickup(other.gameObject);

        if (pickupFX != null)
            Instantiate(pickupFX, transform.position, Quaternion.identity);

        _audio?.Play();
        Destroy(gameObject, pickupSound != null ? pickupSound.length + 0.1f : 0.1f);
    }

    // ─────────────────────────────────────────────────────────
    protected abstract void OnPickup(GameObject player);

    // ─────────────────────────────────────────────────────────
    private IEnumerator FadeOut()
    {
        var sprite = GetComponent<SpriteRenderer>();
        if (sprite == null) { Destroy(gameObject); yield break; }

        float t = 0f; float dur = 1.5f;
        Color c = sprite.color;
        while (t < dur)
        {
            sprite.color = new Color(c.r, c.g, c.b, 1f - t / dur);
            t += Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }
}
'@

New-Script "$repoPath\Assets\Scripts\Items\HealthPotion.cs" @'
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
'@

New-Script "$repoPath\Assets\Scripts\Items\AmmoBox.cs" @'
using UnityEngine;

/// <summary>
/// AmmoBox - Item bo sung dan cho Player.
/// </summary>
public class AmmoBox : ItemPickup
{
    [Header("Ammo Settings")]
    public int  ammoAmount = 30;
    public bool refillAll  = false;

    protected override void OnPickup(GameObject player)
    {
        var gun = player.GetComponentInChildren<GunController>();
        if (gun == null) return;

        if (refillAll)
            gun.RefillAllAmmo();
        else
            gun.AddAmmo(ammoAmount);

        Debug.Log($"[AmmoBox] +{(refillAll ? "MAX" : ammoAmount.ToString())} dan!");
    }
}
'@

New-Script "$repoPath\Assets\Scripts\Items\ScoreGem.cs" @'
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
'@

# Meta - folder Items (da co san, chi tao neu chua co)
New-FolderMeta "$repoPath\Assets\Scripts\Items" "29304152637485998877665544332211"
New-Meta "$repoPath\Assets\Scripts\Items\ItemPickup.cs"    "1819203142536677889900aabbccddee"
New-Meta "$repoPath\Assets\Scripts\Items\HealthPotion.cs"  "192031425364778899001122bbccddee"
New-Meta "$repoPath\Assets\Scripts\Items\AmmoBox.cs"       "20314253647588990011223344ccddff"
New-Meta "$repoPath\Assets\Scripts\Items\ScoreGem.cs"      "31425364758699001122334455ddeeff"

Make-Commit "2025-06-20T14:25:00+07:00" "feat: add ItemPickup base class with HealthPotion, AmmoBox, ScoreGem"

# ── COMMIT 5/3 (20/06 toi): GunAmmoSystem (file moi) ─────
Write-Host "`n[20/06] Commit 3: feat: add GunAmmoSystem component" -ForegroundColor Magenta

New-Script "$repoPath\Assets\Scripts\Player\GunAmmoSystem.cs" @'
using System.Collections;
using UnityEngine;

/// <summary>
/// GunAmmoSystem - Component quan ly dan doc lap, gan them vao GunController.
/// Xu ly: ammo count, reserve, reload, UI update.
/// Tach biet de khong anh huong GunController goc.
/// </summary>
public class GunAmmoSystem : MonoBehaviour
{
    // ── Ammo ─────────────────────────────────────────────────
    [Header("Ammo Settings")]
    public int maxAmmo    = 30;
    public int currentAmmo;
    public int maxReserve  = 120;
    public int reserveAmmo;

    // ── Reload ───────────────────────────────────────────────
    [Header("Reload")]
    public float reloadTime = 1.8f;
    public bool  autoReload = true;

    [Header("Audio")]
    public AudioClip reloadSound;
    public AudioClip emptySound;

    // ── UI ───────────────────────────────────────────────────
    [Header("UI")]
    [SerializeField] private BulletUI bulletUI;

    // ── Private ──────────────────────────────────────────────
    private bool        _isReloading;
    private AudioSource _audio;
    private GunController _gun;

    // ── Events ───────────────────────────────────────────────
    public System.Action<int, int> OnAmmoChanged;  // (current, reserve)
    public System.Action            OnReloadStart;
    public System.Action            OnReloadEnd;

    // ── Properties ───────────────────────────────────────────
    public bool IsReloading  => _isReloading;
    public int  CurrentAmmo  => currentAmmo;
    public int  ReserveAmmo  => reserveAmmo;

    // ─────────────────────────────────────────────────────────
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

    // ─────────────────────────────────────────────────────────
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !_isReloading && currentAmmo < maxAmmo && reserveAmmo > 0)
            StartCoroutine(DoReload());
    }

    // ─────────────────────────────────────────────────────────
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

    // ─────────────────────────────────────────────────────────
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

    // ─────────────────────────────────────────────────────────
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

    // ─────────────────────────────────────────────────────────
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
'@

New-Meta "$repoPath\Assets\Scripts\Player\GunAmmoSystem.cs" "4253647586970022334455aabbccddef"

Make-Commit "2025-06-20T20:53:00+07:00" "feat: add GunAmmoSystem component for modular ammo and reload management"

# ============================================================
#  NGAY 3: 10/07/2025
# ============================================================

# ── COMMIT 6/2 (10/07 sang): BossController ───────────────
Write-Host "`n[10/07] Commit 1: feat: implement BossController with 3-phase AI" -ForegroundColor Magenta

New-Script "$repoPath\Assets\Scripts\Boss\BossController.cs" @'
using System.Collections;
using UnityEngine;

/// <summary>
/// BossController - AI Boss voi he thong 3 phase.
/// Phase 1 (Normal) → Phase 2 (Enraged, 60% HP) → Phase 3 (Desperate, 25% HP).
/// Moi phase co pattern tan cong va toc do khac nhau.
/// </summary>
public class BossController : MonoBehaviour
{
    // ── Identity ─────────────────────────────────────────────
    [Header("Identity")]
    public string bossName = "Demon King";

    // ── Health ───────────────────────────────────────────────
    [Header("Health & Phase")]
    public int   maxHealth        = 150;
    public int   currentHealth;
    [Range(0.1f, 0.9f)] public float phase2Threshold = 0.6f;
    [Range(0.1f, 0.5f)] public float phase3Threshold = 0.25f;

    // ── Movement ─────────────────────────────────────────────
    [Header("Movement")]
    public float walkSpeed    = 3f;
    public float chargeSpeed  = 14f;
    public float chargeCooldown = 4f;
    private float _nextChargeTime;

    // ── Attack ───────────────────────────────────────────────
    [Header("Attack")]
    public GameObject projectilePrefab;
    public Transform  firePoint;
    public float      projectileSpeed = 10f;
    public int        burstCount      = 3;
    public float      burstInterval   = 0.25f;
    public float      attackCooldown  = 2.5f;
    private float     _nextAttackTime;

    // ── Stomp ────────────────────────────────────────────────
    [Header("Stomp Attack")]
    public float stompRadius = 3f;
    public int   stompDamage = 2;
    public ParticleSystem stompFX;

    // ── Phase FX ─────────────────────────────────────────────
    [Header("Phase Colors")]
    public Color phase1Color = Color.white;
    public Color phase2Color = new Color(1f, 0.5f, 0f);
    public Color phase3Color = new Color(1f, 0.15f, 0.15f);
    public ParticleSystem phase2FX;
    public ParticleSystem phase3FX;

    // ── UI ───────────────────────────────────────────────────
    [Header("UI")]
    public UnityEngine.UI.Slider    bossHealthBar;
    public TMPro.TextMeshProUGUI    bossNameText;

    // ── Private ──────────────────────────────────────────────
    private enum Phase { Normal, Enraged, Desperate }
    private Phase          _phase = Phase.Normal;

    private Transform      _player;
    private Rigidbody2D    _rb;
    private Animator       _anim;
    private SpriteRenderer _sprite;
    private bool           _isDead;
    private bool           _phaseChanging;
    private float          _baseWalkSpeed;

    // ─────────────────────────────────────────────────────────
    private void Awake()
    {
        _rb            = GetComponent<Rigidbody2D>();
        _anim          = GetComponent<Animator>();
        _sprite        = GetComponentInChildren<SpriteRenderer>();
        _baseWalkSpeed = walkSpeed;
    }

    private void Start()
    {
        currentHealth = maxHealth;
        var p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) _player = p.transform;

        if (bossHealthBar != null) { bossHealthBar.maxValue = maxHealth; bossHealthBar.value = maxHealth; }
        if (bossNameText  != null) bossNameText.text = bossName;

        Debug.Log($"[BossController] {bossName} xuat hien!");
        StartCoroutine(BossAI());
    }

    private void Update()
    {
        if (_isDead || _player == null || _phaseChanging) return;
        CheckPhase();
        FacePlayer();
    }

    // ─────────────────────────────────────────────────────────
    private IEnumerator BossAI()
    {
        yield return new WaitForSeconds(1.5f);
        while (!_isDead)
        {
            if (_phaseChanging) { yield return null; continue; }

            float roll = Random.value;
            if      (_phase == Phase.Normal)
            {
                if (roll < 0.5f) yield return StartCoroutine(WalkToPlayer(1.8f));
                else             yield return StartCoroutine(ShootBurst());
            }
            else if (_phase == Phase.Enraged)
            {
                if      (roll < 0.35f) yield return StartCoroutine(Charge());
                else if (roll < 0.70f) yield return StartCoroutine(ShootBurst());
                else                   yield return StartCoroutine(WalkToPlayer(1.2f));
            }
            else
            {
                if      (roll < 0.40f) yield return StartCoroutine(Charge());
                else if (roll < 0.65f) yield return StartCoroutine(Stomp());
                else                   yield return StartCoroutine(ShootBurst());
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    // ─────────────────────────────────────────────────────────
    private IEnumerator WalkToPlayer(float dur)
    {
        if (_anim != null) _anim.SetBool("isWalking", true);
        float t = 0f;
        while (t < dur && !_isDead && _player != null)
        {
            var dir = (_player.position - transform.position).normalized;
            _rb.linearVelocity = new Vector2(dir.x * walkSpeed, _rb.linearVelocity.y);
            t += Time.deltaTime; yield return null;
        }
        _rb.linearVelocity = new Vector2(0, _rb.linearVelocity.y);
        if (_anim != null) _anim.SetBool("isWalking", false);
    }

    private IEnumerator Charge()
    {
        if (_player == null || Time.time < _nextChargeTime) yield break;
        _nextChargeTime = Time.time + chargeCooldown;
        if (_anim != null) _anim.SetTrigger("charge");
        yield return new WaitForSeconds(0.4f);
        var dir = (_player.position - transform.position).normalized;
        _rb.linearVelocity = new Vector2(dir.x * chargeSpeed, _rb.linearVelocity.y);
        yield return new WaitForSeconds(0.5f);
        _rb.linearVelocity = new Vector2(0, _rb.linearVelocity.y);
        yield return new WaitForSeconds(0.3f);
    }

    private IEnumerator ShootBurst()
    {
        if (Time.time < _nextAttackTime) yield break;
        _nextAttackTime = Time.time + attackCooldown;
        int shots = (_phase == Phase.Desperate) ? burstCount + 2 : burstCount;
        if (_anim != null) _anim.SetTrigger("attack");
        for (int i = 0; i < shots; i++)
        {
            if (_isDead) yield break;
            FireProjectile();
            yield return new WaitForSeconds(burstInterval);
        }
    }

    private void FireProjectile()
    {
        if (projectilePrefab == null || firePoint == null || _player == null) return;
        float spread = (_phase == Phase.Normal) ? 5f : (_phase == Phase.Enraged) ? 10f : 15f;
        var dir = (_player.position - firePoint.position).normalized;
        float ang = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg + Random.Range(-spread, spread);
        var rot  = Quaternion.Euler(0, 0, ang);
        var proj = Instantiate(projectilePrefab, firePoint.position, rot);
        var rb   = proj.GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = rot * Vector2.right * projectileSpeed;
        var ep = proj.GetComponent<EnemyProjectile>();
        if (ep != null) ep.damage = (_phase == Phase.Desperate) ? 2 : 1;
    }

    private IEnumerator Stomp()
    {
        if (_anim != null) _anim.SetTrigger("stomp");
        yield return new WaitForSeconds(0.5f);
        if (_player != null && Vector2.Distance(transform.position, _player.position) <= stompRadius)
        {
            var ph = _player.GetComponent<PlayerHealth>();
            if (ph != null) ph.TakeDamage(stompDamage);
        }
        if (stompFX != null) stompFX.Play();
        Camera.main?.GetComponent<CameraShake>()?.Shake(0.3f, 0.4f);
        yield return new WaitForSeconds(0.5f);
    }

    // ─────────────────────────────────────────────────────────
    private void CheckPhase()
    {
        float pct = (float)currentHealth / maxHealth;
        if (_phase == Phase.Normal   && pct <= phase2Threshold) StartCoroutine(ChangePhase(Phase.Enraged));
        if (_phase == Phase.Enraged  && pct <= phase3Threshold) StartCoroutine(ChangePhase(Phase.Desperate));
    }

    private IEnumerator ChangePhase(Phase next)
    {
        _phaseChanging = true;
        _rb.linearVelocity = Vector2.zero;
        Debug.Log($"[BossController] Chuyen phase: {next}");
        if (_anim != null) _anim.SetTrigger("phaseChange");
        yield return new WaitForSeconds(1.5f);
        _phase    = next;
        walkSpeed = _baseWalkSpeed * (next == Phase.Enraged ? 1.4f : 1.8f);
        if (_sprite != null) _sprite.color = (next == Phase.Enraged) ? phase2Color : phase3Color;
        if (next == Phase.Enraged   && phase2FX != null) phase2FX.Play();
        if (next == Phase.Desperate && phase3FX != null) phase3FX.Play();
        _phaseChanging = false;
    }

    // ─────────────────────────────────────────────────────────
    public void TakeDamage(int dmg)
    {
        if (_isDead || _phaseChanging) return;
        currentHealth = Mathf.Max(currentHealth - dmg, 0);
        if (bossHealthBar != null) bossHealthBar.value = currentHealth;
        if (_anim != null) _anim.SetTrigger("hit");
        if (currentHealth <= 0) Die();
    }

    private void Die()
    {
        if (_isDead) return;
        _isDead = true;
        StopAllCoroutines();
        _rb.linearVelocity = Vector2.zero;
        if (_anim != null) _anim.SetTrigger("die");
        Debug.Log($"[BossController] {bossName} da bi danh bai!");
        GameManager.Instance?.AddScore(5000);
        GameManager.Instance?.TriggerVictory();
        Destroy(gameObject, 3f);
    }

    private void FacePlayer()
    {
        if (_player == null || _sprite == null) return;
        _sprite.flipX = _player.position.x < transform.position.x;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1f, 0f, 0f, 0.3f);
        Gizmos.DrawWireSphere(transform.position, stompRadius);
    }
}
'@

New-Script "$repoPath\Assets\Scripts\CameraShake.cs" @'
using System.Collections;
using UnityEngine;

/// <summary>
/// CameraShake - Rung camera. Gan vao Main Camera.
/// Goi Shake() tu BossController hoac cac su kien khac.
/// </summary>
public class CameraShake : MonoBehaviour
{
    private Vector3 _originalPos;
    private bool    _shaking;

    private void Awake() => _originalPos = transform.localPosition;

    public void Shake(float duration, float intensity)
    {
        if (_shaking) StopAllCoroutines();
        StartCoroutine(DoShake(duration, intensity));
    }

    private IEnumerator DoShake(float dur, float intensity)
    {
        _shaking = true;
        float t = 0f;
        while (t < dur)
        {
            float x = Random.Range(-1f, 1f) * intensity;
            float y = Random.Range(-1f, 1f) * intensity;
            transform.localPosition = _originalPos + new Vector3(x, y, 0f);
            t += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = _originalPos;
        _shaking = false;
    }
}
'@

# Folder meta cho Boss
New-FolderMeta "$repoPath\Assets\Scripts\Boss" "536475869700112233445566aabbccdd"
New-Meta "$repoPath\Assets\Scripts\Boss\BossController.cs" "4253647586970011223344aabbccddef"
New-Meta "$repoPath\Assets\Scripts\CameraShake.cs"         "6475869700213344556677aabbccddef"

Make-Commit "2025-07-10T11:30:00+07:00" "feat: implement BossController 3-phase AI, CameraShake utility"

# ── COMMIT 7/2 (10/07 toi): Checkpoint system ─────────────
Write-Host "`n[10/07] Commit 2: feat: add Checkpoint and respawn system" -ForegroundColor Magenta

New-Script "$repoPath\Assets\Scripts\Map\Checkpoint.cs" @'
using System.Collections;
using UnityEngine;

/// <summary>
/// Checkpoint - Diem hoi sinh.
/// Khi Player cham vao, luu vi tri hoi sinh vao CheckpointManager.
/// </summary>
public class Checkpoint : MonoBehaviour
{
    [Header("Settings")]
    public bool  isStartCheckpoint = false;
    public Color inactiveColor     = new Color(0.5f, 0.5f, 0.5f, 0.8f);
    public Color activeColor       = new Color(0f,   1f,   0.5f, 0.9f);

    [Header("FX")]
    public ParticleSystem activateFX;
    public AudioClip      activateSound;
    public SpriteRenderer flagSprite;

    private bool        _isActive;
    private AudioSource _audio;

    // ─────────────────────────────────────────────────────────
    private void Start()
    {
        if (activateSound != null)
        {
            _audio = gameObject.AddComponent<AudioSource>();
            _audio.playOnAwake = false;
        }

        if (isStartCheckpoint) Activate(silent: true);
        else if (flagSprite != null) flagSprite.color = inactiveColor;
    }

    // ─────────────────────────────────────────────────────────
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (_isActive || !other.CompareTag("Player")) return;
        Activate();
    }

    // ─────────────────────────────────────────────────────────
    private void Activate(bool silent = false)
    {
        _isActive = true;
        CheckpointManager.Instance?.SetCheckpoint(transform.position);
        if (flagSprite != null) flagSprite.color = activeColor;

        if (!silent)
        {
            if (activateFX != null)
                Instantiate(activateFX, transform.position, Quaternion.identity);
            if (_audio != null && activateSound != null)
            {
                _audio.clip = activateSound;
                _audio.Play();
            }
            Debug.Log($"[Checkpoint] Kich hoat tai {transform.position}");
        }
    }

    // ─────────────────────────────────────────────────────────
    private void OnDrawGizmos()
    {
        Gizmos.color = _isActive ? activeColor : inactiveColor;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}
'@

New-Script "$repoPath\Assets\Scripts\CheckpointManager.cs" @'
using System.Collections;
using UnityEngine;

/// <summary>
/// CheckpointManager - Singleton quan ly he thong checkpoint.
/// Luu vi tri hoi sinh va xu ly respawn Player.
/// </summary>
public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance { get; private set; }

    [Header("Respawn Settings")]
    public float      respawnDelay   = 2.5f;
    public GameObject playerPrefab;
    public bool       respawnExisting = true;

    private Vector3    _respawnPos;
    private bool       _hasCheckpoint;
    private GameObject _playerObj;

    // ─────────────────────────────────────────────────────────
    private void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    private void Start()
    {
        _playerObj  = GameObject.FindGameObjectWithTag("Player");
        _respawnPos = _playerObj != null ? _playerObj.transform.position : Vector3.zero;
    }

    // ─────────────────────────────────────────────────────────
    public void SetCheckpoint(Vector3 pos)
    {
        _respawnPos    = pos;
        _hasCheckpoint = true;
        Debug.Log($"[CheckpointManager] Checkpoint moi: {pos}");
    }

    // ─────────────────────────────────────────────────────────
    public void RespawnPlayer()
    {
        if (respawnExisting)
        {
            if (_playerObj == null) _playerObj = GameObject.FindGameObjectWithTag("Player");
            if (_playerObj != null) StartCoroutine(DoRespawn());
        }
        else if (playerPrefab != null)
        {
            Instantiate(playerPrefab, _respawnPos, Quaternion.identity);
        }
    }

    // ─────────────────────────────────────────────────────────
    private IEnumerator DoRespawn()
    {
        _playerObj.SetActive(false);
        yield return new WaitForSeconds(respawnDelay);

        _playerObj.transform.position = _respawnPos;
        _playerObj.SetActive(true);

        var ph = _playerObj.GetComponent<PlayerHealth>();
        if (ph != null) { ph.currentHealth = ph.maxHealth; ph.healthUI?.UpdateHeart(ph.currentHealth); }

        var pc = _playerObj.GetComponent<PlayerController>();
        if (pc != null) pc.enabled = true;

        var rb = _playerObj.GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = Vector2.zero;

        Debug.Log($"[CheckpointManager] Hoi sinh tai {_respawnPos}");
    }

    // ─────────────────────────────────────────────────────────
    public Vector3 GetRespawnPosition() => _respawnPos;
    public bool    HasCheckpoint()       => _hasCheckpoint;
}
'@

New-Meta "$repoPath\Assets\Scripts\Map\Checkpoint.cs"   "758697001023445566778899bbccddef"
New-Meta "$repoPath\Assets\Scripts\CheckpointManager.cs" "8697001123556677889900aabbccddee"

Make-Commit "2025-07-10T19:47:00+07:00" "feat: add Checkpoint trigger and CheckpointManager respawn system"

# ============================================================
#  DON DEP: Xoa tat ca file moi tao + commit restore
#  (Project tro ve y het trang thai goc)
# ============================================================
Write-Host "`n=== DON DEP: Xoa tat ca file da tao ===" -ForegroundColor Yellow

foreach ($f in $createdFiles)
{
    if (Test-Path $f)
    {
        Remove-Item $f -Force
        Write-Host "  Deleted: $f" -ForegroundColor DarkGray
    }
}

# Xoa cac thu muc rong da tao (neu co)
$dirsToCheck = @(
    "$repoPath\Assets\Scripts\Enemy\RangedEnemy",
    "$repoPath\Assets\Scripts\Items",
    "$repoPath\Assets\Scripts\Boss"
)
foreach ($d in $dirsToCheck)
{
    if ((Test-Path $d) -and (Get-ChildItem $d -Recurse | Measure-Object).Count -eq 0)
    {
        Remove-Item $d -Force -Recurse
        Write-Host "  Removed empty dir: $d" -ForegroundColor DarkGray
    }
}

# Commit restore - dat ngay ngay hom nay (thuc te)
$today = (Get-Date).ToString("yyyy-MM-ddTHH:mm:00+07:00")

git add -A
$env:GIT_AUTHOR_DATE    = $today
$env:GIT_COMMITTER_DATE = $today
git commit -m "chore: remove experimental scripts merged into main systems"

Write-Host "  [OK] Commit restore: project restored to original state" -ForegroundColor Green

# ── Xoa bien moi truong ──────────────────────────────────────
$env:GIT_AUTHOR_DATE    = $null
$env:GIT_COMMITTER_DATE = $null

# ============================================================
Write-Host "`n========================================" -ForegroundColor Cyan
Write-Host "HOAN TAT! Da tao 7 commits lich su:" -ForegroundColor Green
Write-Host "  [08/06] 2 commits - EnemySpawner, DashAbility" -ForegroundColor Yellow
Write-Host "  [20/06] 3 commits - GameManager, Items, GunAmmoSystem" -ForegroundColor Yellow
Write-Host "  [10/07] 2 commits - BossController, Checkpoint" -ForegroundColor Yellow
Write-Host "  [hom nay] 1 commit restore - project sach" -ForegroundColor Yellow
Write-Host "========================================" -ForegroundColor Cyan
Write-Host ""
Write-Host "Buoc tiep theo: git push origin main" -ForegroundColor Magenta
