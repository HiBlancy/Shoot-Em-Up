using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSecondShot : MonoBehaviour
{
    bool ableToShoot;
    float timeToShootAgain = 20f;
    Animator animator;
    AudioSource audioSource;

    void Awake()
    {
        ableToShoot = true;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("BOOM", false);

        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        TrowBomb();
    }

    void TrowBomb()
    {
        if(Input.GetKeyDown(KeyCode.E) & ableToShoot)
        {
            ableToShoot = false;

            audioSource.Play();

            GameObject[] enemies;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            GameObject[] enemyBullets;
            enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");

            animator.SetBool("BOOM", true);

            foreach(GameObject enemy in enemies)
                enemy.SetActive(false);

            StartCoroutine(WaitToShootAgain());
        }
    }

    IEnumerator WaitToShootAgain()
    {
        yield return new WaitForSeconds(timeToShootAgain);
        ableToShoot = true;
        animator.SetBool("BOOM", false);
    }
}