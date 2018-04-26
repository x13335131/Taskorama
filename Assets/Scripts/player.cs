using UnityEngine;
using System.Collections;
using UnityEngine.UI;


//Player movement code: inScopeStudios youtube tutorials
//CLIMBING CODE: Code from 'GamesplusJames' tutorial on youtube

public class player : MonoBehaviour
{
    

    private Rigidbody2D myRigidBody;
    public Text countText;                                      //displaying the count
    public int count;                                           //counting the pickups
    public Text WinText;                                        //displaying the text when everything is collected

    private Animator myAnimator;
    [SerializeField]
    private float movementSpeed;
    private bool attack;
    private bool slide;
    private bool facingRight;

    [SerializeField]
    private Transform[] groundPoints;
    [SerializeField]
    private float groundRadius;
    [SerializeField]
    private LayerMask whatIsGround;
    private bool isGrounded;
    private bool jump;
    private bool jumpAttack;
    [SerializeField]
    private bool airControl;
    [SerializeField]
    private float jumpForce;

    public float attackTime;
    private float attackTimeCounter;
    [SerializeField]
    private EdgeCollider2D SwordCollider;
    //*****CLIMBING CODE*****

    //CLIMBING CODE VARIABLE: Code from 'GamesplusJames' tutorial on youtube

    // true or false if our player is on the ladder
    public bool onLadder;
    public float climbSpeed;
    private float climbVelocity = 5f;
    private float gravityStore;//set to 0 so the gravity is removed allowing the player to move up the ladder


    //*****END OF CLIMBING CODE***** 

    // Use this for initialization
    void Start()
    {
       
        facingRight = true;
        myRigidBody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        //set to default
        count = 0;                                      //set count to 0
        WinText.text = "";                              //SetCountText text to blank
        SetCountText();                                 //call SetCountText method

        //*****CLIMBING CODE*****

        gravityStore = myRigidBody.gravityScale; //Get the gravity scale and store in this variable

        //*****END OF CLIMBING CODE***** 
    }
    void Update()
    {
        HandleInput();                                   //call handleInput method
        /*if (count>4)
        {
            GameObject.FindGameObjectsWithTag("endAnimate")[0].GetComponent<Animation>().Play();
        }*/
        if (Input.GetKeyDown(KeyCode.P))                        //if user hits space bar
        {
            GameObject.FindGameObjectsWithTag("endAnimate")[0].GetComponent<Animator>().Stop();
        }
        if (Input.GetKeyDown(KeyCode.I))                        //if user hits space bar
        {
            GameObject.FindGameObjectsWithTag("endAnimate")[0].GetComponent<Animator>().Play("plant");
        }
    }

    // Update is called once per frame
    void FixedUpdate()                                  //calling methods
    {
        float horizontal = Input.GetAxis("Horizontal");
        isGrounded = IsGrounded();
        HandleMovement(horizontal);
        Flip(horizontal);
        HandleAttacks();
        HandleLayers();
        ResetValues();

    }
    //*****ATACKING ENEMY CODE*****

    //ATTACKING ENEMY CODE from 'GamesplusJames' and 'InScope Studios' tutorial on youtube
    public void MeleeAttack()
    {
        SwordCollider.enabled = !SwordCollider.enabled;
    }

    //*****END OF ENEMY ATTACK**********
    //entering trigger zone
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("ladder"))             //objects tagged pickups
        {
            onLadder = true;
        }
        if (other.gameObject.CompareTag("pickups"))             //objects tagged pickups
        {
            
            other.gameObject.SetActive(false);                  //any other object set to false
            count = count + 1;                                  //number +1
            SetCountText();//calling method
            
            
        }
        if (other.gameObject.CompareTag("Trig"))                //objects tagged Trig
        {
            other.gameObject.SetActive(false);                  //any other object set to false
            SetCountText();                                     //calling method
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag.Equals("ladder"))             //objects tagged pickups
        {
            onLadder = false;
        }
    }


    //setting count method
    public void SetCountText()
    {
        countText.text = "Count: " + count.ToString();                      //set count to string
        if (count >= 5)                                                      //if count is greater than or equal to 5
        {
            WinText.text = "Run to the sign! \n" + "you collected all items!";    //display this
        }
        else if (count < 5)                                                 //if count is less than 5
        {
            WinText.text = "";                                              //set to blank
        }
    }

    private void HandleMovement(float horizontal)                   //handling movement
    {
        //FYI: if myRigidBody.velocity = Vector2.left; //x = -1, y= 0 : makes character move left
        if (myRigidBody.velocity.y < 0)                                 //y is less than 0, player is landed
        {
            myAnimator.SetBool("land", true);                           //land is  = true ( ie player is landed)
        }

        if (!myAnimator.GetBool("slide") && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack") && (isGrounded || airControl))
        {
            myRigidBody.velocity = new Vector2(horizontal * movementSpeed, myRigidBody.velocity.y);
        }
        if (isGrounded && jump)
        {
            isGrounded = false;
            myRigidBody.AddForce(new Vector2(0, jumpForce));
            myAnimator.SetTrigger("jump");
        }

        if (slide && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
        {
            myAnimator.SetBool("slide", true);
        }
        else if (!this.myAnimator.GetCurrentAnimatorStateInfo(0).IsName("Slide"))
        {
            myAnimator.SetBool("slide", false);
        }
        myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
        myAnimator.SetBool("onLadder", onLadder);
    }
    private void HandleAttacks()                        //handling player attacks
    {
        if (attack && isGrounded && !this.myAnimator.GetCurrentAnimatorStateInfo(0).IsTag("Attack"))
        {
            myAnimator.SetTrigger("attack");
            myRigidBody.velocity = Vector2.zero;
        }
        if (jumpAttack && !isGrounded && !this.myAnimator.GetCurrentAnimatorStateInfo(1).IsName("jumpAttack"))
        {
            myAnimator.SetBool("jumpAttack", true);
        }
        if (!jumpAttack && !this.myAnimator.GetCurrentAnimatorStateInfo(1).IsName("jumpAttack"))
        {
            myAnimator.SetBool("jumpAttack", false);
        }
    }
    private void HandleInput()                                      //handing input from user
    {
        if (Input.GetKeyDown(KeyCode.Space))                        //if user hits space bar
        {
            jump = true;                                            //jump is true
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))                    //if user hits left shift
        {
            attack = true;                                          //attack is true
            jumpAttack = true;                                      //jump attack is true
            myAnimator.SetBool("attack", true);
        }

        if (Input.GetKeyDown(KeyCode.LeftControl))               //if left key is pressed on keyboard   
        {
            slide = true;                                        //set slide to true
        }
    }
    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;

            Vector3 theScale = transform.localScale;

            theScale.x *= -1;

            transform.localScale = theScale;
        }
    }
    private void ResetValues()                          //resetting player values to false
    {
        attack = false;
        slide = false;
        jump = false;
        jumpAttack = false;
    }

    private bool IsGrounded()                           //if player is grounded
    {
        if (myRigidBody.velocity.y <= 0)                //and if velocity is less or equal to 0
        {
            foreach (Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);
                for (int i = 0; i < colliders.Length; i++)
                {
                    if (colliders[i].gameObject != gameObject)
                    {
                        myAnimator.ResetTrigger("jump");
                        myAnimator.SetBool("land", false);
                        return true;
                    }
                }
            }
        }
        return false;
    }
    private void HandleLayers()                 //handling layers
    {
        if (!isGrounded)                        //if players not grounded
        {
            myAnimator.SetLayerWeight(1, 1);
        }
        else
        {
            myAnimator.SetLayerWeight(1, 0);
        }
        //*****CLIMBING CODE*****

        if (Input.GetKeyDown(KeyCode.UpArrow) && onLadder) // if up arrow is pressed on keyboard and players on ladder
        {
            if (Input.GetAxisRaw("Vertical") > 0) //if greater than 0 on the y axis- set the following:
            {
                myRigidBody.gravityScale = 0;
                climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
                Vector2 vel = new Vector2(myRigidBody.velocity.x, climbVelocity);
                myRigidBody.velocity = vel;
            }
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow) && onLadder) //if down arrow is pressed on keyboard and players on the ladder
        {
            if (Input.GetAxisRaw("Vertical") < 0) //if less than 0 on y axis, set the following:
            {
                myRigidBody.gravityScale = 0;
                climbVelocity = climbSpeed * Input.GetAxisRaw("Vertical");
                Vector2 vel = new Vector2(myRigidBody.velocity.x, climbVelocity);
                myRigidBody.velocity = vel;
            }
        }
        if (!onLadder)      //if not on ladder
        {
            myRigidBody.gravityScale = gravityStore;
        }
        //*****END OF CLIMBING CODE***** 
    }
  
}