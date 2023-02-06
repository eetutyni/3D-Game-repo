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
    

    //setting the start stamina which is full, staminabar is inactive in start
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
        gameObject.SetActive(false);
    }


    //activate staminabar
    public void ShowStamina()
    {
       
        gameObject.SetActive(true);
        
    }


    //Hide Staminabar
    public void HideStamina()
    {
        gameObject.SetActive(false);
    }

    //Use stamina, jumping takes stamina for example
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

    //stamina regeneration
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
        HideStamina();
    }
}