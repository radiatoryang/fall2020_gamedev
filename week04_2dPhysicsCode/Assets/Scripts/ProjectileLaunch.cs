using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: let me use the mouse to aim a cannon, 
// and left-click to shoot a projectile ball

// USAGE: put this script on pivot point parent,
// with a long sprite child pointing downwards

public class ProjectileLaunch : MonoBehaviour
{
    public float rotationSpeed = 90f; // public = exposed to Unity inspector
    public float shootForce = 1000f; 
    public Rigidbody2D myProjectilePrefab; // public = in Inspector, Rigidbody2D = for our convenience

    void Update()
    {
        // move the mouse to aim the cannon
        // -1f: moving mouse left, 0f: mouse not moving horizontal, +1.0f: moving mouse right
        float horizontalMouseSpeed = Input.GetAxis("Mouse X");

        // transform.Rotate( 0, 0, horizontalMouseSpeed); // this is FRAMERATE DEPENDENT
        transform.Rotate( 0, 0, horizontalMouseSpeed * Time.deltaTime * rotationSpeed); // FRAMERATE INDEPENDENT because we use Time.deltaTime
        // 60 FPS? dT = 1/60th of a second
        // 1 FPS? dT = 1/1 = 1 second
        // 1000 FPS? dT = 1/1000th of a second
        // dT: usually a very small number between 0.0 - 1.0

        // how to instantiate ("clone") an object
        // 1. make a prefab object
        // 2. declare and assign a public var to reference that prefab
        // 3. use the Instantiate function

        // left-click to shoot a projectile out of the cannon
        if ( Input.GetMouseButtonDown(0) ) { // 0 = left-click, 1 = right-click, 2 = middle-click
            Rigidbody2D myNewClone = Instantiate( myProjectilePrefab, transform.position - transform.up * 2, Quaternion.identity );
            // add force in the direction of this cannon's current "down" vector
            myNewClone.AddForce( -transform.up * shootForce );
        }

    }

}
