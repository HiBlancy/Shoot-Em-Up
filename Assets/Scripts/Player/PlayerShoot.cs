using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] Transform playerShootPosition;
    [SerializeField] float defaultBulletSpeed;
    [SerializeField] float timeToShootAgain;

    bool ableToShoot;

    void Awake()
    {
        ableToShoot = true;
    }

    void FixedUpdate()
    {
        ListenShootingInputs();
    }

    void ListenShootingInputs()
    {
        if (Input.GetKeyDown(KeyCode.Space) || ableToShoot)
        {
            ableToShoot = false;

            GameObject bullet = PoolManager.Obj.BulletPool.GetElement();

            BulletBehaviour bulletBehaviour = bullet.GetComponent<BulletBehaviour>();
            bulletBehaviour.SetUpBullet(playerShootPosition.position);
            bulletBehaviour.ShootBullet(Vector2.right, defaultBulletSpeed);

            StartCoroutine(WaitToShootAgain());
        }
    }
    IEnumerator WaitToShootAgain()
    {
        yield return new WaitForSeconds(timeToShootAgain);
        ableToShoot = true;
    }
}