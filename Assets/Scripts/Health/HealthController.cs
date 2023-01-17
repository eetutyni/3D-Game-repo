using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public static event Action OnPlayerDeath;
    public int playerHealth;

    [SerializeField] private Image[] hearts;



    private void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {


        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < playerHealth)
            {
               

            }
            else
            {
                hearts[i].color = Color.black;
            }


        }

        if (playerHealth <= 0)
        {
            Death();
        }

    }
    public void Death()
    {
        OnPlayerDeath?.Invoke();
    }



}