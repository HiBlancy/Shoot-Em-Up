using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    int health = 3;
    public void Damage()
    {
        health--;
        if (health == 0)
            Debug.Log("i ded");
    }
}