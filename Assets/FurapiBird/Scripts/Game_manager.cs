using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Game_manager : MonoBehaviour
{
    public GameObject Obstacle_prefab;
    public GameObject Bird;
    private Bird_script ref_birdscript;

    private float timer = 2f;

    // Start is called before the first frame update
    void Start()
    {
        ref_birdscript = Bird.GetComponent<Bird_script>();
    }

    // Update is called once per frame
    void Update()
    {
        //checks if the game has started to spawn obstacles
        if (ref_birdscript.gameStarted == true)
        {
            //starts timer
            timer -= Time.deltaTime;

            //spawns an obstacle every 2 seconds in a radom Y position (within the screen limits)
            if (timer <= 0)
            {
                float randomY = Random.Range(-2f, 2f);

                spwanObsatcle(randomY);

                //resets timer witha random value
                timer = Random.Range(1.5f, 2.5f);
            }
        }

        //Go back to menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu_scene");
        }
    }

    //Method to spawn pipe obstacle
    public void spwanObsatcle(float posY)
    {
        GameObject newObstacle = Instantiate(Obstacle_prefab);
        newObstacle.transform.position = new Vector3(10, posY, 0);
    }
}
