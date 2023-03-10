using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -9.81f;

    [SerializeField] private CharacterController controller;

    private Vector3 velocity;
    
    bool isGrounded;
    public float jumpForce = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
  
    void FixedUpdate()
    {
        isGrounded = GroundCheck();

        if(isGrounded && velocity.y < 0) velocity.y = -2f;

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

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
    }
}
