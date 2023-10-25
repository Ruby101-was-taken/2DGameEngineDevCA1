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
    [HideInInspector]public Animator anim;

    private bool homeRight = false, homeUp = false;

    //I thought coyote started with a k so that's what the k in ktime is for whoops
    private int kTime = 0;

    private Vector3 homeTo = new Vector3(0,0,0);
    private int homingCoolDown = 0;

    public BoxCollider2D coll;

    public SpriteRenderer sprite;

    public GameManager gameManager;

    private bool canMove = true;

    [SerializeField] private Sprite die;


    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        moveSpeed = normalSpeed;
        anim.speed = 0.3f; //slows the player animation so speed increase is better :D
    }

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal") * moveSpeed;
        float verticalInput = Input.GetAxis("Vertical") * moveSpeed;

        anim.SetBool("Running", (horizontalInput != 0 || verticalInput != 0));

        if (canMove)
        {
            if (horizontalInput < 0)
                sprite.flipX = true;
            else if (horizontalInput > 0)
                sprite.flipX = false;

            body.velocity = new Vector2(horizontalInput, verticalInput);
        }
            //reset player if they fall down too fawr :( - was used when was platformer, and was then used when testing top down so level could be reset, keeping it cuz it's been here so long I could not get rid of it :(
            //if (transform.position.y < -20)
            //{
            //kill();
            //}

    }

    private void Update()
    {
        // pressing R resets, probs shouldn't be in the player script now that I'm thinking about it, meh it's fine
        if (Input.GetKeyDown(KeyCode.R))
            gameManager.resetGame(true);
    }
        

    //returns 1 if number is positive, -1 if negative, 0 if 0, wait am I even gonna use this, like I thought I needed it but now idk, ah well, i'll keep it just incase. - nvm I used it - nvm again I never ended up using it, pretty cool tho - I USED IT YEAAAAAAAAAAAAAAAAA - False alarm..., it continues to go unused
    public float posOrNeg(float num)
    {
        if (num == 0) return 0;
        else return Mathf.Abs(num) / num;
    }


    public void kill()
    {
        gameManager.resetGame(true);
    }

    void OnCollisionEnter2D(Collision2D collider)
    {if (collider.gameObject.tag == "Spike")
        {
            gameManager.collectCoin(-10);
            sprite.sprite = die;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "RemoveCoin")
        {
            gameManager.removeCoins();
        }
        if (collider.gameObject.tag == "Goal")
        {
            canMove = false;
            gameManager.finishLevel();
        }
    }
}