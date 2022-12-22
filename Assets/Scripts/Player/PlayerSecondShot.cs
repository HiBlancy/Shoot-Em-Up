using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSecondShot : MonoBehaviour
{
    bool ableToShoot;
    float timeToShootAgain = 20f;
    Animator animator;

    void Awake()
    {
        ableToShoot = true;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("BOOM", false);
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
            GameObject[] enemies;
            enemies = GameObject.FindGameObjectsWithTag("Enemy");

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
