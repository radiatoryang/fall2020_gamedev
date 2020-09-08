using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardMove : MonoBehaviour
{
    void Update()
    {
        // Four different ways to code movement

        // if the player holds down UP ARROW, then move up
        if ( Input.GetKey(KeyCode.UpArrow) ) {
            GetComponent<Transform>().position += new Vector3(0f, 0.1f, 0f);
        }

        // if the player holds down RIGHT ARROW, then move right
        if ( Input.GetKey(KeyCode.RightArrow)) {
            // "transform" is a shortcut for "GetComponent<Transform>()"
            transform.position += new Vector3( 0.1f, 0f, 0f );
        }

        // etc. for DOWN ARROW, move down
        if ( Input.GetKey(KeyCode.DownArrow) ) {
            // if you don't need to do extra math with a position, and just want to
            // do the equilvalent of a "+=" type of thing, then Translate() is good too
            transform.Translate(0f, -0.1f, 0f);
        }

        // etc. for LEFT ARROW, move left
        if ( Input.GetKey(KeyCode.LeftArrow) ) {
            // if a GameObject has no parents, then "position" and "localPosition" are the same
            transform.localPosition += new Vector3( -0.1f, 0f, 0f );
        }
    }
}
