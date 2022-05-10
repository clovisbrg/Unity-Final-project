using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_script : MonoBehaviour
{
    protected float timer = 0;
    public bool startTimer = false;

    protected float diffX=0;

    public AudioClip paddleSound, gameoverSound, wallSound;
    protected AudioSource ref_audiosource1, ref_audiosource2, ref_audiosource3;


    // Start is called before the first frame update
    void Start()
    {
        ref_audiosource1 = gameObject.AddComponent<AudioSource>();
        ref_audiosource2 = gameObject.AddComponent<AudioSource>();
        ref_audiosource3 = gameObject.AddComponent<AudioSource>();
        ref_audiosource1.clip = paddleSound;
        ref_audiosource2.clip = gameoverSound;
        ref_audiosource3.clip = wallSound;

        // gives the first impulsion on the ball
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, -4);
    }

    // Update is called once per frame
    void Update()
    {
        //detects when the ball goes under a predefined Y limit
        if (transform.position.y <= -5)
        {
            ref_audiosource2.Play();
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

            //only removes 500 when possible, otherwise just sets at zero
            if (GameObject.Find("Score").GetComponent<Score_manager>().score <= 500)
            {
                GameObject.Find("Score").GetComponent<Score_manager>().score = 0;
            }
            else
            {
                GameObject.Find("Score").GetComponent<Score_manager>().score -= 500;
            }

            startTimer = true;
        }

        //replaces the ball and starts a timer befor re-launching it
        if (startTimer == true)
        {
            transform.position = new Vector3(0, -2, 0);
            timer += Time.deltaTime;
        }
        
        //the timer has to wait for 5 seconds (to sync with the music)
        if(timer >= 5)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -4);
            timer = 0;
            startTimer = false;
        }



    }

    void OnCollisionEnter2D(Collision2D col)
    {
        //Calculates the angle at which the ball will rebound based on the distance and the side relative to the center of the paddle 
        if (col.gameObject.name == "Paddle")
        {
            ref_audiosource1.Play();

            float PaddleX = GameObject.Find("Paddle").transform.position.x;
            float BallX = transform.position.x;
            if (PaddleX < BallX)
            {
                diffX = BallX - PaddleX;
            }
            else
            {
                diffX = -(PaddleX - BallX);
            }
            GetComponent<Rigidbody2D>().velocity = new Vector2(diffX * 3f, 4);
        }
        else if ((col.gameObject.name == "Wall Right") || (col.gameObject.name == "Wall Left") || (col.gameObject.name == "Wall Top"))
        {
            ref_audiosource3.Play();
        }
        else
        {
            ref_audiosource1.Play();
        }

    }
}
