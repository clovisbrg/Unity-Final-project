using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick_script : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.name == "Ball")
        {

            Destroy(gameObject);
            //adds 50 to the score which is the updated on screen by the "score manager" script
            GameObject.Find("Score").GetComponent<Score_manager>().score += 50;
            //calls the reportbrickdeath method from the GameMaster to update the number of bricks left
            GameObject.Find("GameMaster").GetComponent<GameMaster_script>().reportBrickDeath();
        }
      
    }
}