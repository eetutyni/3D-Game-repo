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
        if (movementScript.hasJumped) animator.SetTrigger("Jump");
        if (movementScript.move.x > 0.1 && movementScript.move.magnitude > 0.1f && movementScript.isGrounded)
        {
            
        }
        if (movementScript.move.x < 0.1 && movementScript.move.magnitude > 0.1f && movementScript.isGrounded)
        {
           
        }
        if (movementScript.move.y < 0.1 && movementScript.move.magnitude > 0.1f && movementScript.isGrounded)
        {
            
        }
        if (movementScript.move.y > 0.1 && movementScript.move.magnitude > 0.1f && movementScript.isGrounded)
        {
            
        }
        if (movementScript.move.magnitude < 0.1f && movementScript.isGrounded)
        {
   
        }
        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetTrigger("attack");
        }
    }
}
