using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDamage : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("Disapear", 6f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Obj.TakeDamage(0.5f);
        }
    }
    void Disapear()
    {
        gameObject.SetActive(false);
    }
}