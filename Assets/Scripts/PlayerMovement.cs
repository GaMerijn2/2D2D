using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float jumpForce;
    private Vector2 movementDirection;
    private Rigidbody2D rb;

    [SerializeField] private float coyoteTime = 0.1f;
    private float coyoteTimeCounter;
    
    [SerializeField] private float jumpBufferTime = 0.1f;
    private float jumpBufferCounter;
    
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundCheckRadius;
    [SerializeField] private LayerMask groundLayer;
    
    [SerializeField] AudioManager jumpAudioManager;
    [SerializeField] AudioManager airJumpAudioManager;

    private bool wasGroundedPreviously;
    [SerializeField] private Object particleEffectPrefab;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpAudioManager = GameObject.Find("Jump").GetComponent<AudioManager>();
        airJumpAudioManager = GameObject.Find("AirJump").GetComponent<AudioManager>();
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }
    
    private void Update()
    {
        movementDirection = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, 0f);
        
        if (IsGrounded())
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferTime;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }

        if (Input.GetButtonDown("Jump") && IsGrounded() && coyoteTimeCounter > 0)
        {
            Debug.Log("Jump Ounds?");
            Debug.Log(coyoteTimeCounter);
            Debug.Log(jumpBufferCounter);

            jumpAudioManager.PlayRandomAudio();
        }

        if (Input.GetButtonDown("Jump") && !IsGrounded() && coyoteTimeCounter > 0)
        {
            Debug.Log("Air Jump Ounds?");
            Debug.Log(coyoteTimeCounter);
            Debug.Log(jumpBufferCounter);
            airJumpAudioManager.PlayRandomAudio();

        }
        
        if (IsGrounded() && !wasGroundedPreviously)
        {
            PlayParticleEffect();
        }

        // Update the previous grounded state
        wasGroundedPreviously = IsGrounded();

    
        if (coyoteTimeCounter > 0f && jumpBufferCounter > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);

            jumpBufferCounter = 0f;
        }

        if (Input.GetButtonUp("Jump") && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
            coyoteTimeCounter = 0f;
        }
    }
    private void PlayParticleEffect()
    {
        // Instantiate the particle effect at the player's position with some offset if needed
        Instantiate(particleEffectPrefab, transform.position, Quaternion.identity);
    }
    
    void FixedUpdate()
    {
        rb.velocity = new Vector2(movementDirection.x, rb.velocity.y);
    }

}
