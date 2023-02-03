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

    void Update()
    {
        if (movementScript.hasJumped) animator.Play("Jump");
        else if (Input.GetKey(KeyCode.W) && movementScript.move.magnitude > 0.1f && movementScript.isGrounded) animator.Play("RunForward");
        else if (Input.GetKey(KeyCode.S) && movementScript.move.magnitude > 0.1f && movementScript.isGrounded) animator.Play("RunBackward");
        else if (Input.GetKey(KeyCode.A) && movementScript.move.magnitude > 0.1f && movementScript.isGrounded) animator.Play("StrafeLeft");
        else if (Input.GetKey(KeyCode.D) && movementScript.move.magnitude > 0.1f && movementScript.isGrounded) animator.Play("StrafeRight");
        else if (movementScript.move.magnitude < 0.1f && movementScript.isGrounded) animator.Play("Idle");
    }
}
