using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextGame : MonoBehaviour
{
    // declare some variables to keep track of our score
    int myScore = 0;
    public int scoreVictory = 20; // if a variable is "public" then it appears in the Inspector

    void Update()
    {
        // press SPACE to get points
        if ( Input.GetKeyDown(KeyCode.Space) ) { // KeyCode is an "enum"
            myScore = myScore + 1; // other ways of doing the same thing: myScore +=1; myScore++;
            Debug.Log( "myScore: " + myScore.ToString() );
        }

        // does the player have 20 points? if so, then they win!!
        if ( myScore >= scoreVictory) {
            Debug.Log("YOU WON!!!");
        }

    }
}
