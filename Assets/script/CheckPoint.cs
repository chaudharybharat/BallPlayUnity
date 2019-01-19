using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    public Sprite green_flag;
    public Sprite red_flag;
    bool checkpointReached;
    
    private SpriteRenderer spriteRenderer;
    // Use this for initialization
    void Start () {
        spriteRenderer = GetComponent<SpriteRenderer>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        if (collision.tag == "player")
        {
            spriteRenderer.sprite = green_flag;
            checkpointReached = true;
        }
       
    }
    
}
