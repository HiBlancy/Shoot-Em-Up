using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float health;

    void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health == 0)
            PoolManager.Obj.EnemyPool.ReturnElement(this.gameObject);
    }
}