using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KillTracker : MonoBehaviour
{
    public Text ScoreBoard; 
    public 
    // Start is called before the first frame update
    void Start()
    {        
        ScoreBoard.text = "Score: 0";
    }

    // Update is called once per frame
    void Update()
    {
        ScoreBoard.text = "Score: " + Enemy.kills;     
    }
}
