using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _enemyPrefab;
    [SerializeField] float _spawnHeight;
    [SerializeField] float _maxSpawnWidth;

    void Start()
    {
        StartCoroutine(SpawningEnemies());
    }

    IEnumerator SpawningEnemies()
    {
        SpawnNewEnemy();
        yield return new WaitForSeconds(1.5f);
    }
    void SpawnNewEnemy()
    {
        GameObject enemyGO = PoolManager.Obj.EnemyPool.GetElement();
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        enemy.Spawn(_maxSpawnWidth, _spawnHeight);
    }
}