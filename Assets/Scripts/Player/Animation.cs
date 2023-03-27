using System;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private Movement mov;
    [SerializeField] private int baseHitDamage = 15;

    private Animator animator;
    private bool isClicked = false;
    private float hitTimer;
    private int hitDamage;

    private bool running;

    private float afkTimer;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!running)
        {
            animator.SetBool("running", false);

            if (Input.GetMouseButtonDown(0))
            {
                isClicked = true;
                animator.SetBool("hitClick", true);
                hitTimer = 0;
                mov.SetCanJump(false);
            }
            else if (Input.GetMouseButtonUp(0))
            {
                if (isClicked)
                {
                    isClicked = false;
                    animator.SetBool("hitClick", false);

                    hitDamage = baseHitDamage + Convert.ToInt32(hitTimer);
                }
            }
            else if (afkTimer > 0) afkTimer += Time.deltaTime;
            else { animator.SetTrigger("afkInspect"); afkTimer = 0; }

            if (isClicked) hitTimer += Time.deltaTime;
        }
        else animator.SetBool("running", true);
    }

    public void ForceSwing()
    {
        if (isClicked)
        {
            animator.SetBool("hitClick", false);
            isClicked = false;
        }
    }

    public void HitDamage()
    {
        RaycastHit hit;
        if (Physics.Raycast(mov.transform.position, mov.transform.forward, out hit, 2.2f, 10))
        {
            GameObject hitObj = hit.collider.gameObject;
            EnemyStateControl enemyScript;
            if (hitObj.TryGetComponent(out enemyScript))
            {
                enemyScript.Takedmg(hitDamage);
            }
        }

        mov.SetCanJump(false);
    }

    public void SetRunning(bool isTrue)
    {
        running = isTrue;
        animator.SetBool("running", isTrue);
    }

    public void OnJump()
    {
        animator.SetTrigger("jump");
    }

    public void ResetInspectTrigger()
    {
        animator.ResetTrigger("afkInspect");
    }
}
