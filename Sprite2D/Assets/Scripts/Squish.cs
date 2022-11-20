using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Squish : MonoBehaviour
{
    public Sprite hear1, hear2, hear3;
    public Image  h1, h2, h3;
    public int currentHealth, maxHealth, damage;
    public float currentPosx, enemyPos;
    public bool display;

    public GameObject death;

    public Rigidbody2D playerRigid;
    public float bounceForce;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        display = false;
        playerRigid = transform.parent.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "enemy")
        {
            currentHealth -= damage;
            display = true;
            playerRigid.velocity = new Vector3(playerRigid.velocity.x, bounceForce, 0f);
            if (display == true)
            {
                if (currentHealth >= maxHealth)
                {
                    h3.enabled = true; //end
                    h2.enabled = true; //First
                    h1.enabled = true;
                }
                else if (currentHealth == 2)
                {
                    h3.enabled = false; //end
                    h2.enabled = true; //First
                    h1.enabled = true; //Middle
                }
                else if (currentHealth == 1)
                {
                    h3.enabled = false; //end
                    h2.enabled = true; //First
                    h1.enabled = false; //Middle
                }
                else if (currentHealth <= 0)
                {
                    h3.enabled = false; //end
                    h2.enabled = false; //First
                    h1.enabled = false; //Middle
                    Destroy(other.gameObject);
                    Instantiate(death, other.transform.position, other.transform.rotation);
                }

            }
        }

        if (display == false)
        {
            h3.enabled = false; //end
            h2.enabled = false; //First
            h1.enabled = false; //Middle
        }

        }
    }

