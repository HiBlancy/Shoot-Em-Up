using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCollision : MonoBehaviour
{
    float randomLifeNum;

    void OnEnable()
    {
        Invoke("Disapear", 4f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        randomLifeNum = Random.Range(0.2f, 2f);

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Obj.GiveHealtToPlayer(randomLifeNum);
        }
        gameObject.SetActive(false);
    }

    void Disapear()
    {
        gameObject.SetActive(false);
    }
}