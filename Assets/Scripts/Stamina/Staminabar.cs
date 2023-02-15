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
    

    //Setting the start stamina which is full, staminabar is inactive in start
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }


    //Activate staminabar
    public void ShowStamina()
    {
        animator.Play("FadeIn");
    }


    //Hide Staminabar
    public void HideStamina()
    {
        animator.Play("FadeOut");
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

    //Stamina regeneration
    private IEnumerator RegenStamina()
    {
        yield return new WaitForSeconds(1.2f);

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
