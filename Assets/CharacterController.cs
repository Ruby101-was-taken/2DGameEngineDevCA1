using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float maxGroundAngle = 45.0f;
    public float movementSpeed = 10f;


    private bool isGrounded = false;
    private Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Handle movement
        body.velocity = new Vector2(horizontalInput * movementSpeed, body.velocity.y);

        // Jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isGrounded = false;
            body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
            Debug.Log("Grounded");
        }
    }

}

