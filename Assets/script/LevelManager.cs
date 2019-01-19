using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;

using admob;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    private BannerView bannerView;
    public AudioClip audio_bird;
    public AudioClip audio_coin;
    public float repawndealy;
    private PlayControler gameplayer;
    int coinScore = 0;
    AudioSource audiosource;
    public Text text;
    // Use this for initialization
    void Start () {
        string appId = "ca-app-pub-8895289942625815~3183172823";
        gameplayer = FindObjectOfType<PlayControler>();
        audiosource = GetComponent<AudioSource>();
        MobileAds.Initialize(appId);

        this.RequestBanner();
        Admob.Instance().showBannerRelative(admob.AdSize.Banner, AdPosition.BOTTOM_CENTER, 0);


    }
    private void RequestBanner()
    {
        Debug.Log("Request banner api call=============>>>>>>>>============");
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-8895289942625815/6241775889";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/2934735716";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create a 320x50 banner at the top of the screen.
        bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Top);
        bannerView.Show();
    }
    // Update is called once per frame
    void Update () {
		
	}

    public void Respaws()
    {
        StartCoroutine("callFuncation");
      
    }

    public IEnumerator callFuncation()
    {
        yield return new WaitForSeconds(2);
        gameplayer.gameObject.SetActive(false);
        gameplayer.transform.position = gameplayer.last_checkpoint;
        gameplayer.gameObject.SetActive(true);
        gameplayer.isToochGround = true;
    }

    public void addCoinScore(int coinvalue)
    {
        audiosource.clip = audio_coin;
        audiosource.Play();

        coinScore += coinvalue;

       

        text.text =""+ coinScore;
      //  Debug.Log("test" + coinvalue);
    }
    public void addBombScore(int coinvalue)
    {
        audiosource.clip = audio_coin;
        audiosource.Play();
       
        coinScore += coinvalue;
        text.text = "" + coinScore;
        Debug.Log("test" + coinvalue);
    }
    public void scoreDonw()
    {
        audiosource.clip = audio_bird;
        audiosource.Play();

        coinScore = coinScore - 5;
        text.text = "" + coinScore;
      //  Debug.Log("test" + coinvalue);
    }

}