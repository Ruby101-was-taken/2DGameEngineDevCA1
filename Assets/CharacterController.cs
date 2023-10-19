using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public float jumpForce = 10.0f;
    public float maxSpeed = 10f;
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


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveSpeed = maxSpeed;
        homingCoolDown = 0;
    }

    void FixedUpdate()
    {
        float xVel = 0;

        if (homeTo == new Vector3(0, 0, 0)) homingCoolDown = 0;
        else if (homingCoolDown > 0) homingCoolDown -= 1;
        if (homingCoolDown == 0) homeTo = new Vector3(0, 0, 0);
        //Debug.Log("cooldown: " + homingCoolDown + " greater than 0: " + (homingCoolDown > 0));
        if (homingCoolDown > 0)
        {
            //
            //Debug.Log("Right: " + homeRight + " UP: " + homeUp);

            //Debug.Log(transform.position.x < homeTo.x);
            if (transform.position.x < homeTo.x)
            {
                if (!homeRight)
                {
                    transform.position = new Vector3(homeTo.x, transform.position.y, 0);
                }
                else
                {
                    xVel = homeSpeed;
                }
            }
            else if (transform.position.x > homeTo.x)
            {
                if (homeRight)
                {
                    transform.position = new Vector3(homeTo.x, transform.position.y, 0);
                }
                else
                {
                    xVel = -homeSpeed;
                }
            }


            if (transform.position.y < homeTo.y)
            {
                if (!homeUp)
                {
                    transform.position = new Vector3(transform.position.x, homeTo.y, 0);
                }
                else
                {
                    body.velocityY = homeSpeed;
                }
            }
            else if (transform.position.y > homeTo.y)
            {
                if (homeUp)
                {
                    transform.position = new Vector3(transform.position.x, homeTo.y, 0);
                }
                else
                {
                    body.velocityY = -homeSpeed;
                }
            }
        }


        float horizontalInput = Input.GetAxis("Horizontal") * moveSpeed;

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckRadius, whatIsGround);//Physics2D.OverlapBox(groundCheckPoint.position, new Vector2(0.1f, 0.2f), 0, whatIsGround);
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
        xVel += horizontalInput;
        if (homingCoolDown > 0)
            xVel = 0;
        Debug.Log(xVel);
        body.AddForce(new Vector2(xVel, 0));
        xVel = 0;
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
                body.velocityX = 0;
                body.velocityY = 0;
                transform.position = new Vector3(0, 0, 0);
            }
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
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Balloon")
        {
            body.velocityY = 10;
            homingCoolDown = 0;
            homeTo = new Vector3(0, 0, 0);
        }
    }
}

