using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class HealthFlashPanel : MonoBehaviour
{
    public bool isFlashing;
    public bool leaveFlash;

    public int flashStrength;

    [SerializeField] private PlayerHealth healthScript;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        switch (healthScript.curHealth)
        {
            case <= 30:
                flashStrength = 1;
                break;

            case < 50:
                flashStrength = 2;
                break;

            default:
                flashStrength = 1;
                break;
        }

        if (healthScript.curHealth < 50 && !isFlashing) StartFlash();
        else EndFlash();
    }

    public void FlashUpdate()
    {
        if (leaveFlash) { anim.Play("FadeOut"); leaveFlash = false; return; }
        
        if (isFlashing) switch (flashStrength) { case 1: { anim.Play("Flash1"); break; } case 2: { anim.Play("Flash2"); break; } }
    }

    public void StartFlash()
    {
        isFlashing = true;
        anim.Play("FadeIn");
    }

    public void EndFlash()
    {
        leaveFlash = true;
    }
}
