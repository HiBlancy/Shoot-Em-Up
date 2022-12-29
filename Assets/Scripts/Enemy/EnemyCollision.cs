using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float health;
    public int giveScore;

    int posibilityForUpgrade;
    public GameObject myPrefabUpgrade;

    [SerializeField] Transform enemyExplotionPosition;

    void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health <= 0)
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

        posibilityForUpgrade = Random.Range(0, 2);

        if (posibilityForUpgrade == 0)
        {
            Instantiate(myPrefabUpgrade, transform.localPosition, Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PoolManager.Obj.EnemyPool.ReturnElement(this.gameObject);
    }
}