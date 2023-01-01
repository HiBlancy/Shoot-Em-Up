using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    [SerializeField] Transform enemyShootPosition;

    Transform target;
    public float timeToShootAgain;
    AudioSource audioS;

    void Start()
    {
        InvokeRepeating("ShootEnemy", 0f, timeToShootAgain);
        audioS = GetComponent<AudioSource>();
    }

    void ShootEnemy()
    {
        audioS.Play();

        target = GameObject.FindGameObjectWithTag("Player").transform;

        GameObject bullet = PoolManager.Obj.BulletEnemyPool.GetElement();

        BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
        bulletBehaviour.SetUpBullet(enemyShootPosition.position);
        bulletBehaviour.ShootEnemyBullet(target.position - transform.position);
    }
    void OnDisable()
    {
        CancelInvoke();
    }
}