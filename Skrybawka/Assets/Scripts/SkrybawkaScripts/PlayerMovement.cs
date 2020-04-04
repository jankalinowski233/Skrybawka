using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float playerSpeed;
    
    [Header("Jump")]
    [Space(15f)]
    public float jumpForce;
    bool isOnGround;
    public Transform groundDetection;
    public float detectionRadius;
    public LayerMask groundMask;

    public int maxJumps;
    private int jumpCount = 0;
    
    Animator anim;
    SpriteRenderer spRenderer;

    private void Awake() // Runs first
    {
        // Grab components references
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        float xAxis = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(xAxis * playerSpeed, rb2d.velocity.y);

        anim.SetFloat("Speed", Mathf.Abs(xAxis)); // Tell animator to start (or stop) running

        if(xAxis < 0) // Flip our sprite on Y axis
        {
            spRenderer.flipX = true;
        }
        else
        {
            spRenderer.flipX = false;
        }
    }

    public void Jump()
    {
        isOnGround = Physics2D.OverlapCircle(groundDetection.position, detectionRadius, groundMask);
        anim.SetBool("IsGrounded", isOnGround); // Tell animator to jump

        if(Input.GetKeyDown(KeyCode.Space))
        {
            jumpCount++;

            if(jumpCount < maxJumps)
            {
                rb2d.AddForce(new Vector2(0.0f, jumpForce));
            }            
        }

        if(isOnGround == true)
        {
            jumpCount = 0;
        }
    }
}


