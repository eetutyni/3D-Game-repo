using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] CharacterController playerController;

    [SerializeField] Movement playerMovement;

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        if (playerMovement.hasJumped)   
        {
            Debug.Log("Play anim");
            animator.Play("Jump");
        }
        else if (playerMovement.velocity.magnitude > 0.1 && !playerMovement.isGrounded)
        {
            animator.Play("RunForward");
            Debug.Log("Run");
        }
        else
        {
            animator.Play("Idle");
            Debug.Log("Idle");
        }
    }
}
