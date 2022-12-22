using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionBehaviour : MonoBehaviour
{
    public void SetUpExplotion(Vector2 startPosition)
    {
        gameObject.SetActive(true);
        this.transform.position = startPosition;
        StartCoroutine(Desactive());
    }

    IEnumerator Desactive()
    {
        yield return new WaitForSeconds(3);
        PoolManager.Obj.ExplotionPool.ReturnElement(this.gameObject);
    }
}