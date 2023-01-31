using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class Movement : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -10.4f;

    [SerializeField] private CharacterController controller;

    public Vector3 velocity;

    public bool hasJumped = false;
    public bool isGrounded;
    public float jumpForce = 2.4f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    public Vector3 move;


    void FixedUpdate()
    {
        isGrounded = GroundCheck();
        if (isGrounded) hasJumped = false;

        if(isGrounded && velocity.y < 0) velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        if(Input.GetButtonDown("Jump")&& isGrounded) Jump();

        controller.Move(velocity * Time.deltaTime);
    }

    bool GroundCheck()
    {
        return Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
    }

    void Jump()
    {
        velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        hasJumped = true;
    }
}
