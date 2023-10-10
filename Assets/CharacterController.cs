using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float movementSpeed = 10f;

    public bool inBall = false;
    public bool jumped = false;

    public LayerMask whatIsGround;
    public Transform groundCheckPoint;
    public float groundCheckRadius = 0.05f;

    private bool isGrounded = false;
    private Rigidbody2D body;
    private Animator anim;

    private int kTime = 0;


    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        isGrounded = Physics2D.OverlapBox(groundCheckPoint.position, new Vector2(0.1f, 0.2f), 0, whatIsGround);
        if (isGrounded)
        {
            inBall = false;
            kTime = 20;
        }
        else if(kTime > 0)
        {
            kTime -= 1;
        }
        // Handle movement
        body.velocity = new Vector2(horizontalInput * movementSpeed, body.velocity.y);

        // Jumping
        if ((isGrounded || kTime>0) && Input.GetButtonDown("Jump"))
        {
            inBall = true;
            isGrounded = false;
            body.velocityY = jumpForce;
            kTime = 0;
        }
        Debug.Log("Ktime: " + kTime);
        anim.SetBool("InBall", inBall) ;

        if(transform.position.y < -20)
        {
            body.velocityX = 0;
            body.velocityY = 0;
            transform.position = new Vector3(0, 0, 0);
        }
    }


}

