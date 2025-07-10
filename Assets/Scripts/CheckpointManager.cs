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

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
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

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public void SetCheckpoint(Vector3 pos)
    {
        _respawnPos    = pos;
        _hasCheckpoint = true;
        Debug.Log($"[CheckpointManager] Checkpoint moi: {pos}");
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
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

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
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

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public Vector3 GetRespawnPosition() => _respawnPos;
    public bool    HasCheckpoint()       => _hasCheckpoint;
}