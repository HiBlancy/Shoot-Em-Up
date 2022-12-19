using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyShootStraight : MonoBehaviour
{
    [SerializeField] Transform enemyShootPosition;
    [SerializeField] Transform enemyShootPosition2;
    public float timeToShootAgain;
    public float timeToShootAgain2;

    void Start()
    {
        InvokeRepeating("ShootEnemy", 0f, timeToShootAgain);
        InvokeRepeating("ShootEnemy2", 0f, timeToShootAgain2); //shot one then other NEED TO FIX
    }

    void ShootEnemy()
    {
        GameObject bullet = PoolManager.Obj.BulletEnemyPool.GetElement();

        BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
        bulletBehaviour.SetUpBullet(enemyShootPosition.position);
        bulletBehaviour.ShootBullet(Vector2.left);
    }

    public void ShootEnemy2()
    {
        GameObject bullet = PoolManager.Obj.BulletEnemyPool.GetElement();

        BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
        bulletBehaviour.SetUpBullet(enemyShootPosition2.position);
        bulletBehaviour.ShootBullet(Vector2.left);
    }
}