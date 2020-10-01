using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: demonstrate a robot sensing walls in front of it and turning, to explore a maze
// USAGE: put this on an "robot" object facing along +X axis (red axis)
public class RobotSteering : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // always move "forward" (move along it's X axis (red arrow) )
        transform.Translate(2f * Time.deltaTime, 0f, 0f); // move 2m per second

        // raycast in front of us and randomly turn +/- 90 degrees if there's a wall
        Ray2D myRay = new Ray2D( transform.position, transform.right );
        float myMaxRayDist = 1.1f;
        Debug.DrawRay( myRay.origin, myRay.direction * myMaxRayDist, Color.yellow );
        RaycastHit2D myRayHit = Physics2D.Raycast( myRay.origin, myRay.direction, myMaxRayDist );

        // did the raycast hit something?
        if ( myRayHit.collider != null ) {
            // ... if so, then randomly turn left or right
            float randomNumber = Random.Range(0, 100);
            if ( randomNumber < 50 ) { // 50% chance to turn left
                transform.Rotate(0, 0, 90f);
            } else { // 50% chance to turn right
                transform.Rotate(0, 0, -90f);
            }
        }

    }
}
