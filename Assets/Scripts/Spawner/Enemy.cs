using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Spawn(float maxSpawnWidth, float spawnHeight)
    {
        transform.position = new Vector2((maxSpawnWidth), Random.Range (-spawnHeight, spawnHeight));
        this.gameObject.SetActive(true);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 4)
            PoolManager.Obj.EnemyPool.ReturnElement(this.gameObject);

        if (collision.gameObject.CompareTag("Player"))
        {
            PoolManager.Obj.EnemyPool.ReturnElement(this.gameObject);
            PlayerHealth.Obj.TakeDamage(1f);
        }
    }
}