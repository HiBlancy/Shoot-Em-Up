using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSecondShot : MonoBehaviour
{
    public static PlayerSecondShot Obj { get; private set; }

    bool ableToShoot;
    float timeToShootAgain = 20f;
    Animator animator;
    AudioSource audioSource;

    void Awake()
    {
        if (Obj != null && Obj != this)
            Destroy(this);
        else
            Obj = this;

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

            ExplotionAndDie();

            GameObject[] enemies;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

            GameObject[] enemyBullets;
            enemyBullets = GameObject.FindGameObjectsWithTag("EnemyBullet");

            foreach(GameObject enemy in enemies)
                enemy.SetActive(false);

            StartCoroutine(WaitToShootAgain());
        }
    }

    public void ExplotionAndDie()
    {
        audioSource.Play();

        animator.SetBool("BOOM", true);
    }

    IEnumerator WaitToShootAgain()
    {
        yield return new WaitForSeconds(timeToShootAgain);
        ableToShoot = true;
        animator.SetBool("BOOM", false);
    }
}