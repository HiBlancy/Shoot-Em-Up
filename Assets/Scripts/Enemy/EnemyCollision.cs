using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float health;
    public int giveScore;

    [SerializeField] Transform enemyExplotionPosition;

    void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health == 0)
        {
            Die();
        }
    }

    public void Die()
    {
        ScoreManager.Obj.addScore(giveScore);

        PoolManager.Obj.EnemyPool.ReturnElement(this.gameObject);

        GameObject explosion = PoolManager.Obj.ExplotionPool.GetElement();
        ExplotionBehaviour explotionBehaviour = explosion.GetComponent<ExplotionBehaviour>();
        explotionBehaviour.SetUpExplotion(enemyExplotionPosition.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PoolManager.Obj.EnemyPool.ReturnElement(this.gameObject);
    }
}