using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] GameObject poolElementPrefab;
    Stack<GameObject> _pool;

    public GameObject GetElement()
    {
        _pool.Push(Instantiate(poolElementPrefab, transform));
        return _pool.Pop();
    }

    public void ReturnElement(GameObject elementToReturn)
    {
        elementToReturn.SetActive(false);
        _pool.Push(elementToReturn);
    }
}