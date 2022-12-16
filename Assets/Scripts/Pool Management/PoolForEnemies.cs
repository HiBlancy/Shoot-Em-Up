using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolForEnemies : MonoBehaviour
{
    [SerializeField] GameObject poolElementPrefab, poolElementPrefab2;
    List<GameObject> _pool = new List<GameObject>();

    public int amountToPool = 30;

    void Awake()
    {
        for (int i = 0; i < amountToPool; i++)
        {
            GameObject prefabFromPool = Instantiate(poolElementPrefab);
            GameObject prefabFromPool2 = Instantiate(poolElementPrefab2);
            prefabFromPool.SetActive(false);
            prefabFromPool2.SetActive(false);
            _pool.Add(prefabFromPool);
            _pool.Add(prefabFromPool2);
        }
    }

    public GameObject GetElement()
    {
        for (int j = 0; j < _pool.Count; j++)
        {
            if (!_pool[j].activeInHierarchy)
            {
                return _pool[Random.Range(j, _pool.Count)];
            }
        }
        return null;
    }
    public void ReturnElement(GameObject elementToReturn)
    {
        elementToReturn.SetActive(false);
    }
}