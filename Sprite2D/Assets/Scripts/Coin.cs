using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    // Start is called before the first frame update

    private LevelManager lvlMana;

    public int coinValue;
    void Start()
    {
        lvlMana = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Player")
        {
            lvlMana.coinsAdd(coinValue);
            Destroy(gameObject);
        }
    }
}
