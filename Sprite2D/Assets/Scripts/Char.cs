using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    public float moveSpeed; //Speed variable
    public Rigidbody2D myRigidBody; //Character rigidbody
    public float direction = 0f; //What direction are we going in?
    public float jumpSpeed;
    // Start is called before the first frame update
    public Transform playerPoint; //Everything has a transform (position) component
    public float groundRadius; //The radius around the platform to check
    public LayerMask groundLayer; //Which layer to include
    //All of these are needed as parameters to Physics2D.Overlap circle
    //All used to restrain double jumping
    //You can hard code radius
    //Serializedfield means 

    public bool onGround = false;

    public int doubleJump = 0;


    [SerializeField] bool canDouble = false;

    public Animator myAnim;

    public Vector3 respawnPos;

    public LevelManager lvlManager;

    public bool canClimb = true;

    public float wait;

    public Stair stairs;

    public Rigidbody2D rg;
    void Start()
    {
        // myRigidBody = GetComponent<Rigidbody2D>(); //Get correct component
        respawnPos = transform.position;

    }

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        rg = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        lvlManager = FindObjectOfType<LevelManager>();
        stairs = FindObjectOfType<Stair>();


    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle(playerPoint.position, groundRadius, groundLayer);
        Debug.Log(onGround);


        direction = Input.GetAxis("Horizontal");
        if (direction > 0f)
        {
            myRigidBody.velocity = new Vector2(direction * moveSpeed, myRigidBody.velocity.y);
            if (transform.localScale.x < 0)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
        } else if (direction < 0f)
        {
            myRigidBody.velocity = new Vector2(direction * moveSpeed, myRigidBody.velocity.y);
            //transform.localScale = new Vector2(-1f, 1f);

            if (transform.localScale.x > 0)
            {
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
            }
        }

            if (Input.GetButtonDown("Jump") && onGround)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpSpeed);
            canDouble = true;
        }
        else if (Input.GetButtonDown("Jump") && canDouble)
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpSpeed);
            canDouble = false;
        }

        myAnim.SetFloat("speed", Mathf.Abs(myRigidBody.velocity.x));
        myAnim.SetBool("grounded", onGround);


        // else if(doubleJump >= 2)
        // {
        //     doubleJump = 0;
        // }



        /*  if (Input.GetAxisRaw("Horizontal") > 0f) //If statement checking input
          {
              myRigidBody.velocity = new Vector3(moveSpeed, myRigidBody.velocity.y, 0f); //setting rigibody velocity to vector with speed, y and z?)
          }
          else if (Input.GetAxisRaw("Horizontal") < 0f) //If statement checking input
          {
              myRigidBody.velocity = new Vector3(-moveSpeed, myRigidBody.velocity.y, 0f); //setting rigibody velocity to vector with speed, y and z?)
          }
          else
          { //stops sliding
              myRigidBody.velocity = Vector3.zero;
          } */


        //onGround = Physics2D.OverlapCircle(playerPoint.position, groundRadius, groundLayer);
        //onGround bool = Physics2D.overlap circle which takes ground position (from transform),
        //ground radius to check, and the layermask.

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "KillPlane")
        {
            lvlManager.Respawn();
        }

        if (other.tag == "Check")
        {
           respawnPos = other.transform.position;
        }

        if (other.tag == "stair") //Bouncing platform
        {

            // myRigidBody.position = new Vector2(stairs.gameObject.transform.position.x, stairs.gameObject.transform.position.y); //Teleport to last instance
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpSpeed);

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
   {
       if (other.gameObject.tag == "MovePlat")
        {
            // transform.parent = other.transform; //Tiny size

            transform.SetParent(other.gameObject.transform, true);


            //breaking blocks     other.collider.transform.SetParent(transform);
        } 

         //breaking blocks other.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovePlat")
        {
         transform.SetParent(null);
         // transform.parent = null; //tinysize
           //breaking blocks  other.collider.transform.SetParent(null); 
        }
}

    /*         
            //myRigidBody.transform.position = new Vector2(other.rigidbody.position.x, other.rigidbody.position.y);
              //transform.localScale = new Vector3(scale.x, scale.y, scale.z);    
   
    } */
}

