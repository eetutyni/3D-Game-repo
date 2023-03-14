using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealthScript;
    public Slider healthbar;

    private void Start()
    {
        healthbar.value = playerHealthScript.maxHealth;
    }

    public void UpdateHealth(float fraction)
    {
        healthbar.value = fraction;
    }
}
