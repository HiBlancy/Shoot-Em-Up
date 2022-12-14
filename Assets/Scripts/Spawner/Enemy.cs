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
        PoolManager.Obj.EnemyPool.ReturnElement(this.gameObject);
    }
}