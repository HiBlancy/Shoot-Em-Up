using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] Transform enemyExplotionPosition;
    public void Spawn(float maxSpawnWidth, float spawnHeight)
    {
        transform.position = new Vector2((maxSpawnWidth), Random.Range (-spawnHeight, spawnHeight));
        this.gameObject.SetActive(true);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Obj.TakeDamage(1f);

            PoolManager.Obj.EnemyPool.ReturnElement(this.gameObject);

            GameObject explosion = PoolManager.Obj.ExplotionPool.GetElement();
            ExplotionBehaviour explotionBehaviour = explosion.GetComponent<ExplotionBehaviour>();
            explotionBehaviour.SetUpExplotion(enemyExplotionPosition.position);
        }
    }
}