using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Obj { get; private set; }

    public Pool BulletPool => _bulletPool;
    public Pool BulletEnemyPool => _bulletEnemyPool;
    public Pool EnemyPool => _enemyPool;

    [SerializeField] Pool _bulletPool;
    [SerializeField] Pool _bulletEnemyPool;
    [SerializeField] Pool _enemyPool;

    void Awake()
    {
        if (Obj != null && Obj != this)
            Destroy(this);
        else
            Obj = this;
    }
}