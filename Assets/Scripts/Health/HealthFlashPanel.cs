using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HealthFlashPanel : MonoBehaviour
{
    [SerializeField] private PlayerHealth healthScript;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        anim.SetFloat("playerHp", healthScript.curHealth);

        if (anim.GetBool("isFlashing") && healthScript.curHealth >= 25) SetFlashing(false);
        if (!anim.GetBool("isFlashing") && healthScript.curHealth < 25) SetFlashing(true);
        if (!anim.GetBool("isFlashing") && healthScript.curHealth >= 25) SetFlashing(false);
    }

    public void SetFlashing(bool value)
    {
        anim.SetBool("isFlashing", value);
    }

    public void HitFlash()
    {
        anim.Play("Flash1");
    }
}
