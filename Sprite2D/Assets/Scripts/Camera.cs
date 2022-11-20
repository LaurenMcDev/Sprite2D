using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject player;
   // public float follow;
   // public Vector3 playerPos;
    public Vector3 offset;
    public Vector3 targetpos;
    public float smoothing;
    //public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        targetpos = new Vector3(player.transform.position.x + offset.x, player.transform.position.y + offset.y, player.transform.position.z + offset.z);
        //    offset.z); 
        // Camera follows the player with specified offset position

        /*  playerPos = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);

          if (player.transform.localScale.x > 0f)
          {
              playerPos = new Vector3(playerPos.x + follow, transform.position.y, transform.position.z);
          } else
          {
              playerPos = new Vector3(playerPos.x - follow, transform.position.y, transform.position.z);
          }

          transform.position = playerPos; */

        transform.position = Vector3.Lerp(transform.position, targetpos, smoothing * Time.deltaTime); 
    }
}

