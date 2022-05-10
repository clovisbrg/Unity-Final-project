using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Bird_script : MonoBehaviour
{
    //this variable will tell us wether or not the game is running
    public bool gameStarted = false;
    //variable used to know hwne a gameover hapened
    public bool dead = false;

    public Rigidbody2D rb;

    public TextMeshPro displayed_text;
    public float distance = 0;

    public AudioClip Theme, Impact, DeathJingle;
    protected AudioSource ref_audiosource1, ref_audiosource2, ref_audiosource3;
    protected Animator ref_animator;

    // Start is called before the first frame update
    void Start()
    {
        //sets the starting position of the bird
        transform.position = new Vector3(-6.5f, 0, 0);

        //setting the gravity at zero before the game starts
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        ref_audiosource1 = gameObject.AddComponent<AudioSource>();
        ref_audiosource2 = gameObject.AddComponent<AudioSource>();
        ref_audiosource3 = gameObject.AddComponent<AudioSource>();

        ref_audiosource1.clip = Theme;
        ref_audiosource2.clip = DeathJingle;
        ref_audiosource3.clip = Impact;

        ref_animator = GetComponent<Animator>();

        ref_audiosource1.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //gravity is only enabled after the first input and thanks to the "dead" variable, all inputs after gameover are ignored
        if (Input.GetKeyDown(KeyCode.Space) && dead == false)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 6f);
            rb.gravityScale = 1.2f;
            gameStarted = true;
        }

        //Prevents the player form going out of the frame, only works before the gameover to avoids infinite loops
        if((transform.position.y < -5 || transform.position.y >5) && dead == false)
        {
            StartCoroutine(iniDeath());
        }

        //this function calculates the distance based on the number of seconds since the game has started running
        if(gameStarted== true)
        {
            distance += Time.deltaTime;
        }

        //displays the distance on a TextmeshPro
        displayed_text.SetText("Distance: " + (int)distance + " m");
    }

    //Detects the collisions with the obstacles and starts "iniDeath" coroutine
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (dead == false)
        {
            StartCoroutine(iniDeath());
        }
       
    }

    IEnumerator iniDeath()
    {
        //Stop music and play the exit sound
        ref_audiosource3.Play();
        ref_audiosource1.Pause();

        //changes the animation
        ref_animator.SetTrigger("isDead");

        //disables the coliders so that the bird can fall freely
        rb.GetComponent<Collider2D>().enabled = false;

        //changing the status of "dead" and "gamaStarted" prevents unwanted "updates" loops from running
        dead = true;
        gameStarted = false;

        yield return new WaitForSeconds(2f);

        //Load game scene
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Menu_scene");

        //Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
    }
}
