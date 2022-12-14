using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] Transform enemyShootPosition;

    Transform target;

    bool ableToShoot;

    void Awake()
    {
        ableToShoot = true;
    }

    void FixedUpdate()
    {
        StartCoroutine("ListenShootingInputsEnemy");
    }

    IEnumerator ListenShootingInputsEnemy()
    {
        ShootEnemy();
        yield return new WaitForSeconds(3.0f);
    }

    public void ShootEnemy()
    {
        if (ableToShoot)
        {
            ableToShoot = false;

            target = GameObject.FindGameObjectWithTag("Player").transform;

            GameObject bullet = PoolManager.Obj.BulletEnemyPool.GetElement();

            BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
            bulletBehaviour.SetUpBullet(enemyShootPosition.position);
            bulletBehaviour.ShootEnemyBullet(target.position - transform.position);

            StartCoroutine(WaitToShootAgain());
        }
    }

    IEnumerator WaitToShootAgain()
    {
        yield return new WaitForSeconds(1);
        ableToShoot = true;
    }
}