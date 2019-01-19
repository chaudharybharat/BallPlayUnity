using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fallDown : MonoBehaviour {
    public LevelManager gamelevelmanager;
    // Use this for initialization
    void Start () {
        gamelevelmanager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //audioSource.Play();
       
        if (collision.tag == "bomb")
        {
            gamelevelmanager.addBombScore(15);
            // Destroy(gameObject);
            Destroy(collision.gameObject);
        }
      
    }
}
