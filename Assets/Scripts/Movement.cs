using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public CharacterController controller;

<<<<<<< Updated upstream
    public float speed = 12f;
    public float gravity = -9.81f;
    Vector3 velocity;
=======
    private Vector3 velocity;
    private Vector3 move;

    private float x, z;
    
>>>>>>> Stashed changes
    bool isGrounded;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
<<<<<<< Updated upstream
  
    void Update()
=======

    void FixedUpdate()
>>>>>>> Stashed changes
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");

        move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

<<<<<<< Updated upstream
        if(Input.GetButtonDown("Jump")&& isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
=======
        if(Input.GetButtonDown("Jump") && isGrounded) Jump();
>>>>>>> Stashed changes

        controller.Move(velocity * Time.deltaTime);
    }
}
