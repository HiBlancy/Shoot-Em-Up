using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float health;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health == 0)
            gameObject.SetActive(false);
    }
}