using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    private LevelManager gamelevelmanager;

    // Use this for initialization
    void Start()
    {
        gamelevelmanager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
      //  gamelevelmanager.scoreDonw();
        Destroy(gameObject);
    }
}
