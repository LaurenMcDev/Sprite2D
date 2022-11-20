using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    // Start is called before the first frame update

    public LevelManager lvlM;

    public int damageGiven;

    void Start()
    {
        lvlM = FindObjectOfType<LevelManager>(); //of typeLlevelManager
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other) //Object set as trigger
    {
        if (other.tag == "Player"){ //Using tags to check collision

            lvlM.HurtPlayer(damageGiven);

        }
    }
}
