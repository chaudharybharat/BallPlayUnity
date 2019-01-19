using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    public GameObject player;
    public float offset;
    public float offsetSomething;
    public Vector3 playerPostion;
	// Use this for initialization
	void Start () {
		
	}
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
          
    playerPostion = new Vector3(player.transform.position.x, transform.position.y, transform.position.z);
        if (player.transform.localScale.x > 0f)
        {
            playerPostion = new Vector3(player.transform.position.x+offset, transform.position.y, transform.position.z);
        }
        else
        {
            playerPostion = new Vector3(player.transform.position.x - offset, transform.position.y, transform.position.z);
        }
        transform.position = Vector3.Lerp(transform.position, playerPostion, offsetSomething * Time.deltaTime);
	}
}
