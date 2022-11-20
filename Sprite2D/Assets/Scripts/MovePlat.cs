using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class MovePlat : MonoBehaviour
{
    // private Vector3 currentTar;
    // public GameObject moveObj;
    // public Transform start, end;

    [SerializeField] private GameObject[] waypoints;
    [SerializeField] public float movespeed = 2f;

    private int currentWay = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        /*  moveObj.transform.position = Vector3.MoveTowards(moveObj.transform.position, currentTar, movespeed * Time.deltaTime);

          if (moveObj.transform.position == end.position)
          {
              currentTar = start.position;
          }

          if(moveObj.transform.position == start.position)
          {
              currentTar = end.position;
          }
      } */

        if(Vector2.Distance(waypoints[currentWay].transform.position, transform.position) < 0.1f)
            {
            currentWay++;
            if(currentWay >= waypoints.Length)
            {
                currentWay = 0;
                
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWay].transform.position, Time.deltaTime * movespeed);
    }
    }
