using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wiggle : MonoBehaviour
{

    public Transform left, right;
    public float speed;
    private Rigidbody2D myRB;

    public bool moveRight;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent < Rigidbody2D >();
    }

    // Update is called once per frame
    void Update()
    {
        if (moveRight && transform.position.x > right.position.x) 
        {
            moveRight = false;
        }

        if (!moveRight && transform.position.x < left.position.x)
        {
            moveRight = true;
        }

        if(moveRight)
        {
            myRB.velocity = new Vector3(speed, myRB.velocity.y, 0f);
        }
        else
        {
            myRB.velocity = new Vector3(-speed, myRB.velocity.y, 0f);
        }
    }
}
