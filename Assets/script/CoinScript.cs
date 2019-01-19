using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour {

    public AudioSource mucis_souce;
    public AudioClip music_clip;
    public int CoinValue = 5;
    private LevelManager gamelevelmanager;
    private AudioSource audioSource;
    // Use this for initialization
    void Start () {
        audioSource = GetComponent<AudioSource>();

        mucis_souce.clip = music_clip;
        gamelevelmanager = FindObjectOfType<LevelManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        audioSource.Play();
        gamelevelmanager.addCoinScore(CoinValue);
       // Destroy(gameObject);
        Destroy(gameObject);
    }
}
