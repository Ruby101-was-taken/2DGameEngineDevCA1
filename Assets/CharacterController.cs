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

    //I thought coyote started with a k so that's what the k in ktime is for whoops
    private int kTime = 0;

    public float boostSpeed = 10;
    private float boostBonus;
    private bool boostHeld = false;

    private Vector3 homeTo = new Vector3(0,0,0);
    private int homingCoolDown = 0;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveSpeed = maxSpeed;
        boostBonus = 0;
        boostHeld = false;
    }

    void FixedUpdate()
    {

        if (homeTo == new Vector3(0, 0, 0)) homingCoolDown = 0;
        else if (homingCoolDown > 0) homingCoolDown -= 1;
        if (homingCoolDown == 0) homeTo = new Vector3(0, 0, 0);


        float horizontalInput = Input.GetAxis("Horizontal") * moveSpeed;

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
        body.velocityX = horizontalInput;
        if (body.velocityX != 0) body.velocityX += boostBonus * posOrNeg(body.velocityX);
        else body.velocityX += boostBonus;

        if (boostBonus > 0) boostBonus -= decelRate; //reduce the bonus added by boosting 
        if (boostBonus < 0) boostBonus = 0; // I feel like it might just be dumb sometimes so I'm adding this, i'm not paranoided you are

        // Jumping
        if ((isGrounded || kTime>0) && Input.GetButton("Jump"))
        {
            inBall = true;
            isGrounded = false;
            body.velocityY = jumpForce;
            kTime = 0;
        }

        if(Physics2D.OverlapCircle(transform.position, balloonCheckRadius, whatIsBalloon))

        //debug dbeug dbeug bduegd bdugedb dbugeb debuvbu debug dbuegd bdugeb dbuegb dbuebd debuby
        //Debug.Log("Boost Left: " + boostLeft);
        //Debug.Log("Boost Bonus: " + boostBonus);
        //Debug.Log("PressShift: " + Input.GetKey(KeyCode.LeftShift));

        if (boostHeld) boostHeld = Input.GetKey(KeyCode.LeftShift);

        if (Input.GetKey(KeyCode.LeftShift) && boostLeft>0 && boostBonus==0 && !boostHeld)
        {
            boostBonus = boostSpeed;
            boostLeft -= 1;
            boostHeld = true;
        }

        //reset player if they fall down too fawr :(
        if(transform.position.y < -20)
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
        homeTo = balloonPos;
        homingCoolDown = 100;
    }
}

