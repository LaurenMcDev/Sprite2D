using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckFlag : MonoBehaviour
{

    public Sprite flagClose, flagOpen;
    private SpriteRenderer spriteRender;

    public bool checkActive;
    // Start is called before the first frame update
    void Start()
    {
        spriteRender = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        spriteRender.sprite = flagOpen;
        checkActive = true;
    }
}
