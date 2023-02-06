using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Movement : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -10.4f;

    [SerializeField] private Staminabar staminascript;

    [SerializeField] private CharacterController controller;

    public Vector3 velocity;


    public bool hasJumped = false;
    public bool isGrounded;
    public float jumpForce = 2.4f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Vector3 move;

    public float sprintModifier = 1.8f;


    //sprint button, groundcheck, movement
    void FixedUpdate()
    {
        isGrounded = GroundCheck();
        if (isGrounded) hasJumped = false;

        if (isGrounded && velocity.y < 0) velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            move *= sprintModifier;
            if (move.magnitude > 0.1)
            {
                SprintStamina();
                staminascript.ShowStamina();
            }
            
        }

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        if (Input.GetButtonDown("Jump") && isGrounded) Jump();


        controller.Move(velocity * Time.deltaTime);
    }

    //groundcheck
    bool GroundCheck()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }


    //jump
    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        hasJumped = true;
        if (staminascript.currentStamina < 15)
        {
            staminascript.currentStamina = 0;
            jumpForce = 0.5f;
        }
        else
        {
            Staminabar.instance.UseStamina(15);
        }
        staminascript.ShowStamina();
    }
    public void SprintStamina()
    {
        Staminabar.instance.UseStamina(0.2f);
    }
}