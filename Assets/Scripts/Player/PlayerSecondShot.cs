using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSecondShot : MonoBehaviour
{
    public delegate void Explotion();
    public event Explotion EnemiesDie;

    bool ableToShoot = true;
    float timeToShootAgain = 20f;
    Animator animator;
    AudioSource audioSource;

    public static PlayerSecondShot Obj { get; private set; }
    void Awake()
    {
        if (Obj != null && Obj != this)
            Destroy(this);
        else
            Obj = this;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("BOOM", false);

        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) & ableToShoot)
        {
            EnemiesDie();

            Debug.Log("Arrived1");

            ableToShoot = false;

            ExplotionAndDie();

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