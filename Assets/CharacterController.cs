using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float normalSpeed = 10f;
    public float moveSpeed;
    public float decelRate = 0.2f;
    public int boostLeft = 5;
    public float homeSpeed = 5;

    public bool inBall = false;
    public bool jumped = false;

    public LayerMask whatIsGround;
    public Transform groundCheckPoint;
    public float groundCheckRadius = 0.05f;

    public LayerMask whatIsBalloon;
    public float balloonCheckRadius = 0.05f;

    [HideInInspector] public bool isGrounded = false;
    private Rigidbody2D body;
    private Animator anim;

    private bool homeRight = false, homeUp = false;

    //I thought coyote started with a k so that's what the k in ktime is for whoops
    private int kTime = 0;

    private Vector3 homeTo = new Vector3(0,0,0);
    private int homingCoolDown = 0;

    public BoxCollider2D coll;

    public SpriteRenderer sprite;

    public GameManager gameManager;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveSpeed = normalSpeed;
        homingCoolDown = 0;
    }

    void FixedUpdate()
    {
        float xVel = 0;
        

        float horizontalInput = Input.GetAxis("Horizontal") * moveSpeed;
        float verticalInput = Input.GetAxis("Vertical") * moveSpeed;
        if (horizontalInput < 0)
            sprite.flipX = true;
        else if (horizontalInput > 0)
            sprite.flipX = false;

        body.velocity = new Vector2(horizontalInput, verticalInput);
        //if(!isGrounded)
        //    body.AddForce(new Vector2(0, body.gravityScale));

        // Jumping
        if ((isGrounded || kTime>0) && Input.GetButton("Jump"))
        {
            inBall = true;
            isGrounded = false;
            body.velocityY = jumpForce;
            kTime = 0;
        }

        //if (Physics2D.OverlapCircle(transform.position, balloonCheckRadius, whatIsBalloon))


            //reset player if they fall down too fawr :(
            if (transform.position.y < -20)
            {
            kill();
            }
    }

    private void Update()
    {
        
    }

    //returns 1 if number is positive, -1 if negative, 0 if 0, wait am I even gonna use this, like I thought I needed it but now idk, ah well, i'll keep it just incase. nvm I used it
    float posOrNeg(float num)
    {
        if (num == 0) return 0;
        else return Mathf.Abs(num) / num;
    }

    public void startHoming(Vector3 balloonPos)
    {
        Debug.Log(balloonPos);
        if(homingCoolDown == 0)
        {
            homeTo = balloonPos;
            homingCoolDown = 20 ;
            if (transform.position.x < homeTo.x) homeRight = true;
            else homeRight = false;
            if (transform.position.y < homeTo.y) homeUp = true;
            else homeUp = false;
        }
    }

    public void kill()
    {
        body.velocityX = 0;
        body.velocityY = 0;
        transform.position = new Vector3(0, 0, 0);
        gameManager.resetGame(true);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Balloon")
        {
            body.velocityY = 10;
            homingCoolDown = 0;
            homeTo = new Vector3(0, 0, 0);
        }
        else if (collider.gameObject.tag == "Spike")
        {
            kill();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "RemoveCoin")
        {
            gameManager.removeCoins();
        }
    }
}