using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: demo how to generate a random maze-like grid pattern with instantiation (10PRINT)
// USAGE: put this on an empty game object with forward slash / backslash prefabs assigned in Inspector
public class TenPrint : MonoBehaviour
{
    public Transform backslashPrefab, forwardslashPrefab; // assign in Inspector!

    void Start()
    {
        for( int x=0; x<10; x++ ) { // move along the X axis
            for ( int y=0; y<10; y++ ) { // move along the Y axis
                Vector2 newPosition = new Vector2( x, y );
                float randomNumber = Random.Range(0, 100);
                if ( randomNumber < 50 ) { // 50%
                    Instantiate( backslashPrefab, newPosition, backslashPrefab.rotation );
                } else {
                    Instantiate( forwardslashPrefab, newPosition, forwardslashPrefab.rotation );
                }
            }
        }
    }

}
