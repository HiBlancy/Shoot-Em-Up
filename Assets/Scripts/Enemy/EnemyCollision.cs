using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().Damage();
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
    }

    void HittingEnemy()
    {
        health--;
        if (health == 0)
            Die();
    }
}