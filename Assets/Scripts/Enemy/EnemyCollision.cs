using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float health;
    public int giveScore;

    void OnCollisionEnter2D(Collision2D collision)
    {
        ScoreManager.Obj.addScore(giveScore);

        health--;
        if (health == 0)
            PoolManager.Obj.EnemyPool.ReturnElement(this.gameObject); //enemigo da puntos aunque colisione al final
    }
}