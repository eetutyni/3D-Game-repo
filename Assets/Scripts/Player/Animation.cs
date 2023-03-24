using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Movement mov;
    private CharacterController characterController;

    void Start()
    {
        animator = GetComponent<Animator>();
        characterController= GetComponent<CharacterController>();
    }

    void Update()
    {
        // Set animation parameters based on movement direction
        if (mov.move.magnitude > 0.1f)
        {
            animator.SetBool("idle", false);
            if (Input.GetKeyDown(KeyCode.W) && mov.move.magnitude > 0.1f && mov.isGrounded)
            {
                animator.SetBool("forward", true);
            }
            else if (Input.GetKey(KeyCode.S) && mov.move.magnitude > 0.1f && mov.isGrounded)
            {
                animator.SetBool("backward", true);
            }
            else if (Input.GetKey(KeyCode.A) && mov.move.magnitude > 0.1f && mov.isGrounded)
            {
                animator.SetBool("left", true);
            }
            else if (Input.GetKey(KeyCode.D) && mov.move.magnitude > 0.1f && mov.isGrounded)
            {
                animator.SetBool("right", true);
            }
            /*if (Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.A) && mov.move.magnitude > 0.1f && mov.isGrounded)
            {
                animator.SetBool("Sleft", true);
            }
            if (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.D) && mov.move.magnitude > 0.1f && mov.isGrounded)
            {
                animator.SetBool("Sright", true);
            }
            */

        }

        
        else
        {
            animator.SetBool("forward", false);
            animator.SetBool("backward", false);
            animator.SetBool("right", false);
            animator.SetBool("left", false);
            animator.SetBool("Sright", false);
            animator.SetBool("Sleft", false);
            animator.SetBool("idle", true);
        }

        // Set animation parameters for jump
        if (mov.hasJumped)
        {
            animator.SetBool("jump", true);
        }
        else
        {
            animator.SetBool("jump", false);
        }
        if(Input.GetKeyDown(KeyCode.Mouse0)) 
        { 
            animator.SetBool("attack", true);
        }
        else
        {
            animator.SetBool("attack", false) ;
        }
    }
}



