using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDie2ndShoot : MonoBehaviour
{
    PlayerSecondShot player2Shoot;
    [SerializeField] Transform enemyExplotionPosition;

    void Awake()
    {
        player2Shoot = FindObjectOfType<PlayerSecondShot>();
    }
    void OnEnable()
    {
        player2Shoot.EnemiesDie += Die;
    }

    public void Die()
    {
        Debug.Log("Arrived2");

        PoolManager.Obj.EnemyPool.ReturnElement(this.gameObject);

        GameObject explosion = PoolManager.Obj.ExplotionPool.GetElement();
        ExplotionBehaviour explotionBehaviour = explosion.GetComponent<ExplotionBehaviour>();
        explotionBehaviour.SetUpExplotion(enemyExplotionPosition.position);
    }

    void OnDisable()
    {
        player2Shoot.EnemiesDie -= Die;
    }
}