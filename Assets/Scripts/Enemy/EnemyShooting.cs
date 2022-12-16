using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] Transform enemyShootPosition;

    Transform target;

    void Start()
    {
        InvokeRepeating("ShootEnemy", 0f, 1.5f);
    }

    public void ShootEnemy()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;

        GameObject bullet = PoolManager.Obj.BulletEnemyPool.GetElement();

        BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
        bulletBehaviour.SetUpBullet(enemyShootPosition.position);
        bulletBehaviour.ShootEnemyBullet(target.position - transform.position);

    }
}