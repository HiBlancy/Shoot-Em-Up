using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehaviour : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _bulletRigidbody;
    private int _bulletDamage;

    public void SetUpBullet(Vector2 startPosition, int bulletDamage = 1)
    {
        this.transform.position = startPosition;
        _bulletDamage = bulletDamage;
    }

    public void ShootBullet(Vector2 direction, float speed = 30)
    {
        gameObject.SetActive(true);
        _bulletRigidbody.velocity = new Vector2(direction.x, direction.y * speed);
    }

    public int GetBulletDamage()
    {
        return _bulletDamage;
    }

 /*   private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            PoolManager.Instance.BulletPool.ReturnElement(this.gameObject);
        }

        if (other.CompareTag("Player"))
        {
            PoolManager.Instance.BulletPool.ReturnElement(this.gameObject);
            other.GetComponent<PlayerHealth>().TakeDamage();
        }
    }*/
}