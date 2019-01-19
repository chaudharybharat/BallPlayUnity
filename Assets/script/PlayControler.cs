using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayControler : MonoBehaviour {

    public float speed = 5f;
    private float mooment =0f;
    private float jumpspeed = 10f;
    private Rigidbody2D rigidbody;
    public Transform groundCheckPoint;
    public float groundcheckRadius;
    public LayerMask groundlayer;
    public bool isToochGround=true;
   public Vector3 last_checkpoint;
    public Vector3 pos;
   public Joystick myjs;
    public LevelManager gamelevelmanager;

    // Use this for initialization
    void Start () {
        last_checkpoint = transform.position;
        gamelevelmanager = FindObjectOfType<LevelManager>();
       
      Screen.orientation = ScreenOrientation.LandscapeLeft;
        rigidbody = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void Update () {
       
      if(transform.position.x>= 278f)
        {
            SceneManager.LoadScene("overgame");
        }
        Debug.Log("=>>" + transform.position.x);
      //  isToochGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundcheckRadius, groundlayer);
      // mooment = Input.GetAxis("Horizontal");
            mooment = myjs.Horizontal;

        //Debug.Log("test move boll" + mooment);
        if (mooment > 0f)
        {
            rigidbody.velocity = new Vector2(mooment * speed, rigidbody.velocity.y);
        }else if (mooment < 0f)
        {
             rigidbody.velocity = new Vector2(mooment * speed, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
       // Debug.Log("test" + isToochGround);
        if (Input.GetButtonDown("Jump")  && isToochGround)
        {
            rigidbody.velocity = new Vector2(rigidbody.velocity.x,jumpspeed);
        }
    }
    public void moveBoll()
    {
        Debug.Log("test move boll"+ mooment);
        mooment = 0.200f;
      
        //this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        // mooment = transform.position.x+5;
        //pos = transform.position;
        //pos.x = pos.x + 0.200f;
        //this.transform.position = pos;
        //Debug.Log("test move boll"+ mooment);
        if (mooment > 0f)
        {
            rigidbody.velocity = new Vector2(mooment * speed, rigidbody.velocity.y);
        }
        else if (mooment < 0f)
        {
            rigidbody.velocity = new Vector2(mooment * speed, rigidbody.velocity.y);
        }
        else
        {
            rigidbody.velocity = new Vector2(0, rigidbody.velocity.y);
        }
    }
    public IEnumerator notjumpfivesecond()
    {
        yield return new WaitForSeconds(5);
        isToochGround = true;
    }
    public void jumpBoll()
    {
        
        if (isToochGround)
        {
            isToochGround = false;
            StartCoroutine("notjumpfivesecond");
            Debug.Log("jumpBoll call");
            if (isToochGround)
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpspeed);
            }
            else
            {
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, jumpspeed);

            }
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("test plyaer toch");
       // Debug.Log("test plyaer toch+"+ collision.tag);
      
        if (collision.tag == "fall")
        {
          //  transform.position = last_checkpoint;
            gamelevelmanager.Respaws();
        }
        if (collision.tag == "checkPointtag")
        {
            last_checkpoint = collision.transform.position;

        }
        if (collision.tag == "bird")
        {
            gamelevelmanager.scoreDonw();

        }
       if (collision.tag == "diamandcoin")
        {

            Destroy(collision.gameObject);
            gamelevelmanager.addCoinScore(10);

        }
    }
        
}
