using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnimation : MonoBehaviour
{
    [SerializeField] Animator holderAnim;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (holderAnim.GetBool("afk"))
        {
            animator.SetBool("afk", true);

            animator.SetBool("running", false);
            animator.SetBool("walking", false);
        }
        if (holderAnim.GetBool("running"))
        {
            animator.SetBool("running", true);

            animator.SetBool("afk", false);
            animator.SetBool("walking", false);
        }
        if (holderAnim.GetBool("walking"))
        {
            animator.SetBool("walking", true);
            Debug.Log("walkin");
            animator.SetBool("afk", false);
            animator.SetBool("running", false);
        }
    }

    public void Jump()
    {
        animator.SetBool("jumping", true);

        animator.SetBool("afk", false);
        animator.SetBool("running", false);
        animator.SetBool("walking", false);
    }

    public void ResetJump()
    {
        if (!animator.GetBool("jumping")) animator.SetBool("jumping", false);
    }
}
