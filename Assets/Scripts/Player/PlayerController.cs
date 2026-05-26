using UnityEngine;


public class PlayerController : MonoBehaviour
{


    private bool isFacingRight = true;

    [Header("Movement")]
    public float runSpeed = 8f;
    public float acceleration = 50f;
    public float deceleration = 50f;
    private float currentSpeed;

    [Header("Jump")]
    public float jumpForce = 16f;
    public float variableJumpTime = 0.2f;
    private float jumpTimeCounter;
    private bool isJumping;

    [Header("Double Jump")]
    public bool enableDoubleJump = true;
    private bool canDoubleJump;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.1f;
    public LayerMask groundLayer;
    private bool isGrounded;


    [Header("Gravity")]
    [SerializeField] private float baseGravity = 3f;
    [SerializeField] private float maxFallGravity = 18f;
    [SerializeField] private float fallSpeedMultiplier = 2f;


    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer sprite;
    public GunController gunController;
    [SerializeField] private ParticleSystem smokeFX;
    public Transform gunRightPos;
    public Transform gunLeftPos;

    [Header("Hand Tracking")]
    [SerializeField] private bool useHandTracking = true;
    [SerializeField] private HandInputProvider handInput;

    private float inputMoveX;
    private bool inputJumpDown;
    private bool inputJumpHeld;
    private bool inputJumpUp;
    private bool inputShootDown;
    private bool inputReloadDown;
    private Vector3 inputAimWorld;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        UpdateInputs();
        CheckEnvironment();
        HandleMovementInput();
        HandleJumpInput();
        UpdateAnimations();

        if (inputShootDown && gunController != null)
        {
            gunController.Shoot();
        }
        if (inputReloadDown && gunController != null)
        {
            gunController.Reload();
        }

        if (inputAimWorld.x < transform.position.x)
            sprite.flipX = true;
        else
            sprite.flipX = false;

        if (gunController != null)
        {
            Transform gunHolder = gunController.transform.parent;

            if (sprite.flipX)
            {
                gunHolder.position = gunLeftPos.position;
                gunController.transform.localScale = new Vector3(1, -1, 1);
            }
            else
            {
                gunHolder.position = gunRightPos.position;
                gunController.transform.localScale = new Vector3(1, 1, 1);
            }

            Vector2 direction = (inputAimWorld - gunHolder.position).normalized;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            gunHolder.rotation = Quaternion.Euler(0, 0, angle);

        }
    }

    private void GravityControl()
    {
        if (rb.linearVelocity.y < 0)
        {
            rb.gravityScale = baseGravity * fallSpeedMultiplier;
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Max(rb.linearVelocity.y, -maxFallGravity));
        }
        else
        {
            rb.gravityScale = baseGravity;
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement();
    }

    void CheckEnvironment()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded)
            canDoubleJump = enableDoubleJump;
    }

    void HandleMovementInput()
    {
        float targetSpeed = inputMoveX * runSpeed;
        if (Mathf.Abs(targetSpeed) > 0.01f)
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, acceleration * Time.deltaTime);
        else
            currentSpeed = Mathf.MoveTowards(currentSpeed, 0, deceleration * Time.deltaTime);
    }

    void ApplyMovement()
    {
        rb.linearVelocity = new Vector2(currentSpeed, rb.linearVelocity.y);

        if (Mathf.Abs(currentSpeed) > 0.1f)
        {
            sprite.flipX = currentSpeed < 0;

            if (isGrounded && !smokeFX.isPlaying)
            {
                smokeFX.Play();
            }
        }
        else
        {
            if (smokeFX.isPlaying)
            {
                smokeFX.Stop();
            }
        }
    }

    void HandleJumpInput()
    {
        if (inputJumpDown)
        {
            if (isGrounded)
            {
                isJumping = true;
                jumpTimeCounter = variableJumpTime;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            }
            else if (!isGrounded && canDoubleJump)
            {
                isJumping = true;
                jumpTimeCounter = variableJumpTime;
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                canDoubleJump = false;

                if (smokeFX != null)
                {
                    smokeFX.Play();
                }
            }
        }

        if (inputJumpHeld && isJumping)
        {
            if (jumpTimeCounter > 0)
            {
                rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (inputJumpUp)
            isJumping = false;
    }

    private void UpdateInputs()
    {
        if (useHandTracking && handInput != null && handInput.HasHand)
        {
            inputMoveX = handInput.MoveX;
            inputJumpDown = handInput.JumpDown;
            inputJumpHeld = handInput.JumpHeld;
            inputJumpUp = handInput.JumpUp;
            inputShootDown = handInput.ShootDown;
            inputReloadDown = handInput.ReloadDown;

            var screenPos = new Vector3(handInput.AimScreenPos.x, handInput.AimScreenPos.y, 0f);
            inputAimWorld = Camera.main.ScreenToWorldPoint(screenPos);
        }
        else
        {
            inputMoveX = Input.GetAxisRaw("Horizontal");
            inputJumpDown = Input.GetButtonDown("Jump");
            inputJumpHeld = Input.GetButton("Jump");
            inputJumpUp = Input.GetButtonUp("Jump");
            inputShootDown = Input.GetMouseButtonDown(0);
            inputReloadDown = Input.GetKeyDown(KeyCode.R);
            inputAimWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        inputAimWorld.z = 0f;
    }

    void UpdateAnimations()
    {
        bool isJumping = !isGrounded;
        animator.SetBool("isJumping", isJumping);
        animator.SetBool("isRunning", Mathf.Abs(currentSpeed) > 0.1f && isGrounded);
        animator.SetBool("isGrounded", isGrounded);
        animator.SetFloat("verticalSpeed", rb.linearVelocity.y);
    }

    private void OnDrawGizmosSelected()
    {
        if (groundCheck)
            Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
