using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Staminabar : MonoBehaviour
{
    public Slider staminaBar;

    private float maxStamina = 100;
    public float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;

    [SerializeField] Movement movementscript;

    public static Staminabar instance;

    private void Awake()
    {
        instance = this;
    }
    
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public void HideStamina()
    {
        if(currentStamina == maxStamina) 
        {
            
        }
    }

    public void UseStamina(float amount)
    {
         if(currentStamina - amount >= 0)
         {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if(regen != null)
                StopCoroutine(regen);

            regen =  StartCoroutine(RegenStamina());
            movementscript.sprintModifier = 1.8f;
            movementscript.jumpForce = 2.4f;
         }
        else
        {
            movementscript.sprintModifier = 1;
        }
    }
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(2);

        while(currentStamina < maxStamina)
        {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }

    
}
