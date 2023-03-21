using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.Animations;

public class Movement : MonoBehaviour
{
    public float speed = 1f;
    public float gravity = -15.5f;

    [SerializeField] private Staminabar staminascript;
    [SerializeField] private CharacterController controller;

    public Vector3 velocity;

    public bool hasJumped = false;
    public bool isGrounded;
    public float jumpForce = 2f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Vector3 move;

    public float sprintModifier = 1.8f;

    private float x;
    private float z;

    public void FixedUpdate()
    {
        //Update vars for animation
        isGrounded = GroundCheck();
        if (isGrounded) hasJumped = false;

        if (isGrounded && velocity.y < 0) velocity.y = -2f;

        //Update movement vars
        x = Input.GetAxisRaw("Horizontal");
        z = Input.GetAxisRaw("Vertical");

        move = transform.right * x + transform.forward * z;

        //Modify movementspeed and use stamina if pressing LShift
        if (Input.GetKey(KeyCode.LeftShift))
        {
            move *= sprintModifier;
            if (isGrounded && move.magnitude > 0.1)
            {
                Staminabar.instance.UseStamina(0.2f); 
            }
        }

        //Move player
        controller.Move(move * speed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;

        //Check for jump
        if (Input.GetButtonDown("Jump") && isGrounded) Jump();

        controller.Move(velocity * Time.deltaTime);
    }

    bool GroundCheck()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    void Jump()
    {
        //Add vertical force
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        hasJumped = true;

        //Use stamina on jump
        if (staminascript.currentStamina < 15)
        {
            staminascript.currentStamina = 0;
            jumpForce = 0.5f;
        }
        else
        {
            Staminabar.instance.UseStamina(15);
        }
    }
}