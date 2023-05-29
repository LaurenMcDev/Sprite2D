using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Char : MonoBehaviour
{
    public float moveSpeed; //Speed variable
    public Rigidbody2D myRigidBody; //Character rigidbody
    public float direction = 0f; //What direction are we going in? = Input.GetAxis("Horizontal");
    public float jumpSpeed;
    // Start is called before the first frame update
    public Transform playerPoint; //Everything has a transform (position) component
    public float groundRadius; //The radius around the platform to check
    public LayerMask groundLayer; //Which layer to include
    //All of these are needed as parameters to Physics2D.Overlap circle
    //All used to restrain double jumping
    //You can hard code radius
    //Serializedfield means 

    public bool onGround = false; //check for on-ground so char doesnt fall through the floor

    public int doubleJump = 0; //check if player can double jump (only once and ground false)


    [SerializeField] bool canDouble = false;

    public Animator myAnim;

    public Vector3 respawnPos; //changes with flags

    public LevelManager lvlManager;

    public float wait;

    public Rigidbody2D rg; //Two rigidbodies?

    public Switch redswitch;
    void Start()
    {
        // myRigidBody = GetComponent<Rigidbody2D>(); //Get correct component
        respawnPos = transform.position; //Original position

    }

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        rg = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();

        lvlManager = FindObjectOfType<LevelManager>();

        redswitch = FindObjectOfType<Switch>();


    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle(playerPoint.position, groundRadius, groundLayer); //circle radius for on gound
        Debug.Log(onGround);


        direction = Input.GetAxis("Horizontal");
        if (direction > 0f) //Going right
        {
            myRigidBody.velocity = new Vector2(direction * moveSpeed, myRigidBody.velocity.y); //Rigidbody new velocity x, y
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
                transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y); //Transform.position.x?
            }
        }

            if (Input.GetButtonDown("Jump") && onGround) //if on ground and button pressed
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

        if(other.tag == "bounce")
        {
            myRigidBody.velocity = new Vector2(myRigidBody.velocity.x, jumpSpeed);
        }
            
    }

    private void OnCollisionEnter2D(Collision2D other)
   {
        if (other.gameObject.tag == "MovePlat")
        {
            // transform.parent = other.transform; //Tiny size

            transform.SetParent(other.gameObject.transform, true);

            //breaking blocks other.collider.transform.SetParent(transform);
        }
    }

    public void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "MovePlat")
        {
         transform.SetParent(null);
         // transform.parent = null; //tinysize
           //breaking blocks  other.collider.transform.SetParent(null); 
        }
}
}

