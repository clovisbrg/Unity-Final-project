using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Score_manager : MonoBehaviour
{
    public TextMeshPro displayed_text;
    public int score = 0;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //updates the score on the screen 
        displayed_text.SetText("Score : " + score);
    }
}
