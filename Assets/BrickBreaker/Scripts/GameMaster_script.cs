using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster_script : MonoBehaviour
{
    public GameObject Brick_prefab;
    public Ball_script ref_ball;
    public int countBricks = 1;

    public AudioClip introSound;
    protected AudioSource ref_audiosource1;

    // Start is called before the first frame update
    void Start()
    {
        ref_audiosource1 = gameObject.AddComponent<AudioSource>();
        ref_audiosource1.clip = introSound;
        spawnBricks();
    }

    // Update is called once per frame
    void Update()
    {
        //Go back to menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu_scene");
        }
    }

    //Method to spawn bricks
    public void spawnBricks()
    {
        ref_audiosource1.Play();
        countBricks = 0;

        //the first "for" method takes takes care of the Y axy and moves on when the second "for" method has finished "laying" the bricks on the X axis
        for(float posY = 3.5f; posY >=0.3f; posY -= 0.638f)
        {
            for (float posX = -5.31f; posX <= 5.31f; posX += 1.18f)
            {
                float rand = Random.value;
                if(rand >= 0.2f)
                {
                    //each brick is instantiated from a prefab and counted to allow the game to knwo when the player destroyed all of them
                    GameObject newBrick = Instantiate(Brick_prefab);
                    newBrick.transform.position = new Vector3(posX, posY, 0);
                    newBrick.name = "Brick " + countBricks;
                    countBricks += 1;
                }
                
            }
        }
        
    }


    public void reportBrickDeath()
    {
        //this methos spawns new brick when the player destroyed them all
        countBricks -= 1;
        if(countBricks < 1)
        {
            spawnBricks();
            ref_ball.startTimer = true;
        }
    }
}
