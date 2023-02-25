using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public HealthBar healthbar;

    [SerializeField] GameObject gameOverPanel;
    [SerializeField] GameObject pausemenu;

    public int maxHealth;
    public int curHealth;

    public bool Alive;
   
    void Start()
    {
        curHealth = maxHealth;
        Alive = true;
    }

    public void TakeDamage(int amount)
    {
        curHealth -= amount;
        if (curHealth <= 0)
        {
            Die();
        }

        healthbar.UpdateHealth((float)curHealth / (float)maxHealth);
    }

    public void AddHealth(int amountt)
    {
        curHealth += amountt;
        healthbar.UpdateHealth((float)curHealth / (float)maxHealth);

        if (curHealth > maxHealth)
        {
            curHealth = maxHealth;
        }
    }

    public void Die()
    {
        Destroy(pausemenu);
        Alive = false;
        gameOverPanel.gameObject.SetActive(true);
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}