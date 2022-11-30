using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelManager : MonoBehaviour
{
    public float wait;
    public Char player;
    // Start is called before the first frame update

    public GameObject deathPart;
    public int coinCount;

    public TMP_Text coinText;

    public Image heart1, heart2, heart3;

    public Sprite full, half, empty;

    public int maxhealth;
    public int healthcount;

    public bool respawning;

    public TMP_Text livesText;
    public float startingLives;
    public float currentLives;

    void Start()
    {
        player = FindObjectOfType<Char>(); //New type of function other than getcomponent
        coinText.text = "Coins: " + coinCount;
        healthcount = maxhealth;

        currentLives = startingLives;
        livesText.text = "Lives x " + currentLives;

    } 

    // Update is called once per frame
    void Update()
    {
        if(healthcount <= 0 && !respawning)
        {
           Respawn();
           respawning = true;
        }
    }
    public void Respawn()
    {
        currentLives -= 1.0f;
        livesText.text = "Lives x " + currentLives;
        if (currentLives >= 1.0f)
        {
            StartCoroutine("RespawnCo"); //Call coroutinbe
        } else
        {
            player.gameObject.SetActive(false);
        }
    }

    public void coinsAdd(int addCoin)
    {
        coinCount += addCoin;
        coinText.text = "Coins: " + coinCount;
    }

    public IEnumerator RespawnCo() //Coroutine 
    { 
        player.gameObject.SetActive(false); //Take the player (char) gameobject and set active to false
        Instantiate(deathPart, player.transform.position, player.transform.rotation); //Create gameObject (see declaration)

        yield return new WaitForSeconds(wait); //Coroutine purpose, wait, set seconds in unity script component.
        healthcount = maxhealth;
        respawning = false;
        heart();

        player.transform.position = player.respawnPos; //Check respawnPos variable in char script
        player.gameObject.SetActive(true); //Set back to true
    }

    public void HurtPlayer(int damagetaken)
    {
        healthcount -= damagetaken;
        heart();
    }
    public void heart()
    {
        switch(healthcount)
        {
            case 6:
                heart1.sprite = full;
                heart2.sprite = full;
                heart3.sprite = full;
                return;

            case 5:
                heart1.sprite = full; //first
                heart2.sprite = full; //middle
                heart3.sprite = half; //last
                return;

            case 4:
                heart1.sprite = full;
                heart2.sprite = full;
                heart3.sprite = empty;
                return;
                
            case 3:
                heart1.sprite = full;
                heart2.sprite = half;
                heart3.sprite = empty;
                return;
                

            case 2:
                heart1.sprite = full;
                heart2.sprite = empty;
                heart3.sprite = empty;
                return;

            case 1:
                heart1.sprite = half;
                heart2.sprite = empty;
                heart3.sprite = empty;
                return;

            default:
                heart1.sprite = empty;
                heart2.sprite = empty;
                heart3.sprite = empty;
                return; 

        }
    }

}
