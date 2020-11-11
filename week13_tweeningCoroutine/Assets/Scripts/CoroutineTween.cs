using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: demoing how coroutines work, how to use a coroutine to tween an object
// USAGE: put this on a visible gameobject / sprite
public class CoroutineTween : MonoBehaviour
{
    public Vector3 destination = new Vector3( 4, 0f, 0f);
    public AnimationCurve tweeningCurve; // assign in Inspector!

    void Start()
    {
        // to call a coroutine, you MUST use this special function called StartCoroutine
        // StartCoroutine( MyFirstCoroutine() );

        // StartCoroutine( LerpCoroutine() );

        StartCoroutine( AnimationCurveLerpCoroutine() );
    }

    // "IEnumerator" is what you use to define coroutine logic
    // coroutine is a function that can last for more than 1 frame / control how fast it runs
    IEnumerator MyFirstCoroutine() {
        Debug.Log("Coroutine started!");

        yield return 0; // wait 1 frame

        Debug.Log("I waited 1 frame, now I'm continuing...");

        // how to pause for 2 frames:
        yield return 1; // still wait 1 frame
        yield return null; // also wait 1 frame

        // how to pause for 1 second:
        yield return new WaitForSeconds(1.0f);

        Debug.Log("I waited for 2 frames and 1 second, now I'm continuing...");

        // when the coroutine reaches the end, it stops
    }

    IEnumerator LerpCoroutine() {
        // smoothly move this square from one point to another
        Vector3 squareStart = transform.position;
        float tweenDuration = 3f;

        // use a "for" loop to move the square a little, then yield, then move the square a little, then yield... etc
        for (float t=0f; t<1f; t+=Time.deltaTime/tweenDuration) { // remember: dT is duration of the frame in sec
            // Lerp = "linear interpolation", change from one state to another with "t" (usually a number from 0.0 to 1.0... 1.0 = 100%)
            transform.position = Vector3.Lerp(squareStart, destination, t);
            yield return 0; // wait 1 frame
        }

        // to be safe, teleport the object to its destination
        transform.position = destination;
    }

    IEnumerator AnimationCurveLerpCoroutine() {
        // smoothly move this square from one point to another
        Vector3 squareStart = transform.position;
        float tweenDuration = 3f;

        // we can also lerp / tween anything that is a number
        SpriteRenderer mySprite = GetComponent<SpriteRenderer>();
        Color startColor = mySprite.color;

        // use a "for" loop to move the square a little, then yield, then move the square a little, then yield... etc
        for (float t=0f; t<1f; t+=Time.deltaTime/tweenDuration) { // remember: dT is duration of the frame in sec
            // LerpUnclamped does NOT clamp "t" between 0.0 and 1.0
            transform.position = Vector3.LerpUnclamped(squareStart, destination, tweeningCurve.Evaluate(t) );
            mySprite.color = Color.Lerp( startColor, Color.black, t);
            yield return 0; // wait 1 frame
        }

        // to be safe, teleport the object to its destination
        transform.position = destination;
    }

}
