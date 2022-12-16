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
        InvokeRepeating("SpawnNewEnemy", 0f, 0.5f);
    }

    void SpawnNewEnemy()
    {
        GameObject enemyGO = PoolManager.Obj.EnemyPool.GetElement();
        Enemy enemy = enemyGO.GetComponent<Enemy>(); // why it is not working :(
        enemy.Spawn(_maxSpawnWidth, _spawnHeight);
    }
}