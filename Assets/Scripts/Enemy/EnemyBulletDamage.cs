using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletDamage : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Obj.TakeDamage(0.5f);
        }
    }
}