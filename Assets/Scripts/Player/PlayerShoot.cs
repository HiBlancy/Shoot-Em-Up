using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform playerShootPosition;
    [SerializeField] float timeToShootAgain;

    AudioSource audioSource;

    bool ableToShoot;

    void Awake()
    {
        ableToShoot = true;
    }

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void FixedUpdate()
    {
        ListenShootingInputs();
    }

    void ListenShootingInputs()
    {
        if (Input.GetKey(KeyCode.Space) & ableToShoot)
        {
            TakeBulletForShoot();
            ableToShoot = false;

            audioSource.Play();

            StartCoroutine(WaitToShootAgain());
        }
    }
    void TakeBulletForShoot()
    {
        GameObject bullet = PoolManager.Obj.BulletPool.GetElement();

        BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
        bulletBehaviour.SetUpBullet(playerShootPosition.position);
        bulletBehaviour.ShootBullet(Vector2.right);
    }

    IEnumerator WaitToShootAgain()
    {
        yield return new WaitForSeconds(timeToShootAgain);
        ableToShoot = true;
    }
}