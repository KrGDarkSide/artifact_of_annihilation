using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;
    public float groundDrag;
    public float jumpForce;
    public float jumpCooldown;
    public float airMultiplayer;
    private bool canJump;

    public float playerHeight;
    public LayerMask ground;
    private bool isGrounded;

    public Transform orientation;

    private float horizontalInput;
    private float verticalInput;

    private Vector3 movementDirection;
    private Rigidbody rb;


    // ===================================================
    // ===================================================
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        canJump = true;
    }

    private void Update()
    {
        // CHECK GROUND
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.3f, ground);
        
        KeyboardInput();
        SpeedControl();

        if (isGrounded)
        { rb.linearDamping = groundDrag; }
        else
        { rb.linearDamping = 0; }
    }

    private void FixedUpdate()
    {
        MovementPlayer();
    }


    // ===================================================
    // ===================================================
    private void KeyboardInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // ACTIVATE JUMP
        if (Input.GetKey(KeyCode.Space) && canJump && isGrounded)
        {
            canJump = false;
            Jump();

            // JUMP COOLDOWN
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovementPlayer()
    {
        // MOVEMENT DIRECTION
        movementDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        if (isGrounded) // IS ON GROUND
        { rb.AddForce(movementDirection.normalized * movementSpeed * 10.0f, ForceMode.Force); }
        else if (!isGrounded) // IS IN AIR
        { rb.AddForce(movementDirection.normalized * movementSpeed * 10.0f * airMultiplayer, ForceMode.Force); }
    }

    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        if (flatVel.magnitude > movementSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * movementSpeed;
            rb.linearVelocity = new Vector3(limitedVel.x, rb.linearVelocity.y, limitedVel.z);
        }
    }

    private void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        canJump = true;
    }
}
