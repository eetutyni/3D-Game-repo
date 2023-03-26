using UnityEngine;

public class Movement : MonoBehaviour
{
    [Header("Reference scripts")]
    [SerializeField] private Staminabar staminascript;
    [SerializeField] private CharacterController controller;

    [Header("Reference objects")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckSize = 0.3f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private EnemyStateControl enem;

    [Header("Camera stuff")]
    [SerializeField] private Camera playerCam;
    [SerializeField] private float defaultFov;
    [SerializeField] private float sprintFov;

    [Header("Player movement attributes")]
    [SerializeField] private float maxSpeed = 4f;
    [SerializeField] private float defaultAcceleration = 3f;
    [SerializeField] private float jumpAcceleration = 1.2f;
    [SerializeField] private float sprintModifier = 1.8f;
    [SerializeField] private float jumpForce = 2f;
    [SerializeField] private float gravity = -12f;

    [Header("Public variables")]
    public bool hasJumped;
    public bool isGrounded;

    // Normalized vector input direction
    private Vector3 moveDirection;
    // Current player movement velocity
    private Vector3 velocity;
    // Velocity with gravity applied
    private Vector3 finalVelocity;

    // Input variables
    private float inputX;
    private float inputZ;

    private float acceleration;

    private void Start()
    {
        acceleration = defaultAcceleration;
    }

    public void Update()
    {
        //Update input vars and calculate direction vector
        inputX = Input.GetAxisRaw("Horizontal");
        inputZ = Input.GetAxisRaw("Vertical");
        moveDirection = (transform.right * inputX + transform.forward * inputZ).normalized;

        //Modify movementspeed and use stamina if pressing LShift and moving
        if (Input.GetKey(KeyCode.LeftShift) && Staminabar.instance.currentStamina > 0)
        {
            moveDirection *= sprintModifier;
            Staminabar.instance.UseStamina(0.1f);
        }
        else playerCam.fieldOfView = defaultFov;

        //Check for jump
        if (Input.GetButtonDown("Jump") && isGrounded) Jump();
    }

    private void FixedUpdate()
    {
        isGrounded = GroundCheck();
        // Vars for animator
        if (isGrounded) hasJumped = false;

        if (!isGrounded) acceleration = jumpAcceleration;
        else acceleration = defaultAcceleration;

        // Move the current velocity towards the intended velocity in the speed of the accelerationSpeed
        velocity = Vector3.MoveTowards(velocity, moveDirection * maxSpeed, acceleration);

        // Apply gravity to the velocity
        finalVelocity = new Vector3(velocity.x, finalVelocity.y, velocity.z);
        if (!isGrounded) finalVelocity.y += gravity * Time.fixedDeltaTime;
        else if (finalVelocity.y < -2f) finalVelocity.y = -2f;

        // Apply the calculated velocity to the controller
        controller.Move(finalVelocity * Time.fixedDeltaTime);
    }

    public void DoDamage()
    {
        RaycastHit hit;
        if (Physics.CapsuleCast(playerCam.transform.position, playerCam.transform.forward * 2f, 1f, Vector3.forward, out hit, 8f))
        {
            if (hit.collider.gameObject.transform.parent != null)
            {
                hit.collider.gameObject.GetComponentInParent<EnemyStateControl>().Takedmg(20);
            }
            else
            {
                hit.collider.gameObject.GetComponent<EnemyStateControl>().Takedmg(20);
            }
        }
    }

    bool GroundCheck()
    {
        return Physics.CheckSphere(groundCheck.position, groundCheckSize, groundMask);
    }

    void Jump()
    {
        // Determine jump force based on current stamina amount and use stamina
        if (Staminabar.instance.currentStamina < 15)
        {
            Staminabar.instance.UseStamina(Staminabar.instance.currentStamina);
            jumpForce = Staminabar.instance.currentStamina / 30;
        }
        else
        {
            Staminabar.instance.UseStamina(15);
        }

        //Calculate initial jump velocity using (v_f^2 = v_i^2 + 2gh)
        finalVelocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        hasJumped = true;
    }
}
