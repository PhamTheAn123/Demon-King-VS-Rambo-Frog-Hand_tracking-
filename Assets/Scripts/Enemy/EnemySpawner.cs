using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// EnemySpawner - He thong spawn ke dich theo wave.
/// Dat vao Scene, gan prefab ke dich va cau hinh so wave.
/// </summary>
public class EnemySpawner : MonoBehaviour
{
    // â”€â”€ Spawn Points â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    [Header("Spawn Points")]
    public Transform[] spawnPoints;

    // â”€â”€ Enemy Prefabs â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    [Header("Enemy Prefabs")]
    public GameObject[] enemyPrefabs;

    // â”€â”€ Wave Settings â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    [Header("Wave Settings")]
    public int   totalWaves     = 5;
    public int   enemiesPerWave = 3;
    public float timeBetweenWaves = 8f;
    public float spawnInterval    = 1.2f;

    // â”€â”€ Boss Wave â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    [Header("Boss Wave")]
    public bool      hasBossWave    = true;
    public int       bossWaveIndex  = 5;
    public GameObject bossPrefab;
    public Transform  bossSpawnPoint;

    // â”€â”€ Runtime â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private int                _currentWave;
    private bool               _allWavesDone;
    private bool               _spawning;
    private List<GameObject>   _spawnedEnemies = new List<GameObject>();

    // â”€â”€ Events â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    public System.Action<int> OnWaveStart;
    public System.Action      OnAllWavesClear;

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void Start() => StartCoroutine(SpawnLoop());

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
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

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
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

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
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

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private void SpawnSingleEnemy()
    {
        if (enemyPrefabs == null || enemyPrefabs.Length == 0) return;
        if (spawnPoints  == null || spawnPoints.Length  == 0) return;

        var prefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        var point  = spawnPoints[Random.Range(0, spawnPoints.Length)];
        if (prefab == null || point == null) return;

        _spawnedEnemies.Add(Instantiate(prefab, point.position, Quaternion.identity));
    }

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
    private int CountAliveEnemies()
    {
        _spawnedEnemies.RemoveAll(e => e == null);
        return _spawnedEnemies.Count;
    }

    public int  GetCurrentWave()  => _currentWave;
    public bool IsAllWavesDone()  => _allWavesDone;
    public bool IsSpawning()      => _spawning;

    // â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€â”€
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