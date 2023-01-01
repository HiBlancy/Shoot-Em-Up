using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeCollision : MonoBehaviour
{
    float randomLifeNum;
    AudioSource audioS;

    void Start()
    {
        audioS = GetComponent<AudioSource>();
    }
    void OnEnable()
    {
        Invoke("Disapear", 4f);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        audioS.Play();
        randomLifeNum = Random.Range(0.2f, 2f);

        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth.Obj.GiveHealtToPlayer(randomLifeNum);
        }
        Invoke("Disapear", 0.1f);
    }

    void Disapear()
    {
        gameObject.SetActive(false);
    }
}