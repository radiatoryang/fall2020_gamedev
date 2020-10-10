using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: hold down movement inputs on keyboard to change the character animation
// USAGE: put this on a gameobject with an Animator + SpriteRenderer with animations already configured
public class AnimatorInput : MonoBehaviour
{
    Animator myAnimator; // cached in Start()

    void Start()
    {
        myAnimator = GetComponent<Animator>(); // find animator that's on the same gameobject
    }

    void Update()
    {
        // if holding down right arrow, then (1) use the WalkAnimation and (2) move 1m / second to the right
        if ( Input.GetKey(KeyCode.RightArrow) ) {
            myAnimator.SetBool("isWalking", true);
            transform.Translate( Time.deltaTime, 0, 0);
        } else { // else, go back to idle animation
            myAnimator.SetBool("isWalking", false);
        }
    }
}
