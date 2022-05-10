using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeObstacle_Script : MonoBehaviour
{
    const float pipeSpeed = 4f;
    const float despawn_posX = -12f;
    private Bird_script ref_birdscript;
    // Start is called before the first frame update
    void Start()
    {
        ref_birdscript = GameObject.Find("Player Bird").GetComponent<Bird_script>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate( -pipeSpeed * Time.deltaTime , 0, 0 );
        if (transform.position.x < despawn_posX)
        {
            Destroy(gameObject);
        }
    }
}
