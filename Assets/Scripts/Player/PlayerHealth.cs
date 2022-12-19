using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth Obj { get; private set; }

    public Image healthBar;
    public int maxHealth = 5;
    public float currentHealth;

    [SerializeField] GameObject DeadPanel;

    void Awake()
    {
        if (Obj != null && Obj != this)
            Destroy(this);
        else
            Obj = this;
    }
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            DeadPanel.SetActive(true); //hacer una explocion final cuando el jugador muere y entonces poner el pausa
            Time.timeScale = 0f;
        }
    }

    public void UpdateHealthBar()
    {
        SetColor(currentHealth / maxHealth);
        healthBar.fillAmount = currentHealth / maxHealth;
    }

    void SetColor(float healthPercent)
    {
        if (healthPercent > 0.66f)
        {
            healthBar.color = Color.green;
        }
        else if (healthPercent > 0.33f)
        {
            healthBar.color = Color.yellow;
        }
        else
        {
            healthBar.color = Color.red;
        }
    }
}