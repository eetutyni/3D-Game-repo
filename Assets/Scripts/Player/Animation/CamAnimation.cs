using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CamAnimation : MonoBehaviour
{
    [SerializeField] Animator holderAnim;
    [SerializeField] private Movement mov;

    private Animator animator;

    private bool running;
    private bool walking;

    private void Start()
    {
        animator = GetComponent<Animator>();
        animator.Play("Wakeup");
    }

    private void FixedUpdate()
    {
        if (running)
        {
            animator.SetBool("running", true);
            animator.SetBool("afk", false);
            animator.ResetTrigger("jump");
            mov.SetCanJump(true);
        }
        else
        {
            animator.SetBool("running", false);
            animator.ResetTrigger("jump");

            if (!walking)
            {
                animator.SetBool("walking", false);
                animator.SetBool("afk", true);
            }
            else
            {
                animator.SetBool("walking", false);
                animator.SetBool("afk", false);
            }
        }
       

    }

    public void SetRunning(bool isTrue)
    {
        running = isTrue;
        animator.SetBool("running", isTrue);
    }

    public void SetWalking(bool isTrue)
    {
        walking = isTrue;
        animator.SetBool("walking", isTrue);
    }

    public void OnJump()
    {
        animator.SetTrigger("jump");
    }
}
