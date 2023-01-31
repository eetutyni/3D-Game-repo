using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] CharacterController playerController;
    [SerializeField] Movement movementScript;

    public float magnitude;

    void Update()
    {
        if (movementScript.hasJumped && !movementScript.isGrounded) animator.Play("Jump");
        else if (movementScript.move.magnitude > 0.1f && movementScript.isGrounded) animator.Play("RunForward");
        else if (movementScript.move.magnitude < 0.1f && movementScript.isGrounded) animator.Play("Idle");

        magnitude = movementScript.move.magnitude;
    }
}
