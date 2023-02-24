using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.UI;

public class Staminabar : MonoBehaviour
{
    public Slider staminaBar;

    public float maxStamina = 100;
    public float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.08f);
    private Coroutine regen;

    [SerializeField] private Movement movementscript;

    [SerializeField] private Animator animator;

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

        if (currentStamina == maxStamina) HideStamina();
    }

    //Show staminabar
    public void ShowStamina()
    {
        animator.Play("FadeIn");
    }


    //Hide staminabar
    public void HideStamina()
    {
        animator.Play("FadeOut");
    }

    //Use stamina (called when moving or jumping for example)
    public void UseStamina(float amount)
    {
        ShowStamina();

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

    //Stamina regeneration
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(1.2f);

        //A 100th of the max stamina is added in between a wait time of the regenTick variable until stamina reaches max
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
