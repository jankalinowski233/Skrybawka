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

    private void Awake() // Runs first
    {
        // Grab components references
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        float x = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(x * playerSpeed, rb2d.velocity.y);

        anim.SetFloat("Speed", x); // Tell animator to start (or stop) running

        // TODO flipping character sprite
    }

    public void Jump()
    {
        // TODO jump animation

        isOnGround = Physics2D.OverlapCircle(groundDetection.position, detectionRadius, groundMask);

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
