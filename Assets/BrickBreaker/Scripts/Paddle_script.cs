using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle_script : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-8.0f * Time.deltaTime, 0, 0);
            
            //prevents the paddle from going out of the screen
            if (transform.position.x <= -5.2f)
            {
                transform.position = new Vector3(-5.2f, -4.5f, 0);
            }
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(8.0f * Time.deltaTime, 0, 0);

            //prevents the paddle from going out of the screen
            if (transform.position.x >= 5.2f)
            {
                transform.position = new Vector3(5.2f, -4.5f, 0);
            }
        }

        
    }
}
