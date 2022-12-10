using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager Obj { get; private set; }

    public Pool BulletPool => _bulletPool;

    [SerializeField] Pool _bulletPool;

    void Awake()
    {
        if (Obj != null && Obj != this)
            Destroy(this);
        else
            Obj = this;
    }
}