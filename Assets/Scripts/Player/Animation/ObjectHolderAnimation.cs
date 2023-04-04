using System;
using System.Collections;
using UnityEngine;

public class ObjectHolderAnimation : MonoBehaviour
{
    [SerializeField] private Inventory inventoryScript;

    [SerializeField] private Movement mov;
    [SerializeField] private int baseHitDamage = 15;

    private Animator animator;
    private bool isClicked = false;

    private float hitTimer;
    private int hitDamage;

    private bool running;
    private bool walking;

    private float afkTimer;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        // Object holder animator logic
        foreach (InventoryItemData item in inventoryScript.items) if (item.itemId == 0)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    isClicked = true;
                    animator.SetBool("hitClick", true);
                    hitTimer = 0;
                    mov.SetCanJump(false);
                }
                else if (Input.GetMouseButton(0))
                {
                    isClicked = true;
                    animator.SetBool("hitClick", true);
                }
                else
                {
                    if (isClicked)
                    {
                        isClicked = false;
                        animator.SetBool("hitClick", false);

                        hitDamage = baseHitDamage + Convert.ToInt32(Mathf.Clamp(hitTimer * 3, 0, 8f));
                        Staminabar.instance.UseStamina(20);
                    }
                    mov.SetCanJump(true);
                }
            }

        if (isClicked && hitTimer < 3.2f) hitTimer += Time.deltaTime;
        else ForceSwing();

        if (running)
        {
            animator.ResetTrigger("afkInspect");
            animator.SetBool("running", true);
            animator.SetBool("afk", false);
            mov.SetCanJump(true);
        }
        else
        {
            animator.SetBool("running", false);

            if (!walking)
            {
                animator.SetBool("walking", false);
                animator.SetBool("afk", true);

                if (afkTimer > 0) afkTimer += Time.deltaTime;
                else { animator.SetTrigger("afkInspect"); afkTimer = 7.5f; }
            }
            else
            {
                animator.SetBool("walking", false);
                animator.SetBool("afk", false);
                animator.ResetTrigger("afkInspect");
            }
        }
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
}
