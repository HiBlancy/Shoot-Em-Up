using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] _enemyPrefab;
    [SerializeField] float _spawnHeight;
    [SerializeField] float _maxSpawnWidth;

    public float spawningEnemy;

    void Start()
    {
        spawningEnemy = 5f;
        InvokeRepeating("SpawningFaster", 0f, 10f);
    }

    void SpawnNewEnemy()
    {
        GameObject enemyGO = PoolManager.Obj.EnemyPool.GetElement();
        Enemy enemy = enemyGO.GetComponent<Enemy>();
        enemy.Spawn(_maxSpawnWidth, _spawnHeight);
    }
    void SpawningFaster()
    {
        spawningEnemy += 0.25f;
        InvokeRepeating("SpawnNewEnemy", 0f, spawningEnemy);
    }
}