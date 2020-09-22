using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// put this script on our trigger?
public class CameraTrigger : MonoBehaviour
{
    Transform cameraFocusTarget;

    void OnTriggerEnter2D(Collider2D activator) {
        cameraFocusTarget = activator.transform;
    }

    void OnTriggerExit2D(Collider2D activator) {
        cameraFocusTarget = null;
    }

    void Update () {
        if ( cameraFocusTarget != null ) {

            // Method A: manually move the Camera position towards the Camera target
            Vector3 moveVector = cameraFocusTarget.position - Camera.main.transform.position;
            if ( moveVector.magnitude > 1f ) {
                moveVector = moveVector.normalized;
            }
            moveVector.z = 0f; // oops this is the bug I didn't fix during class
            Camera.main.transform.position += moveVector * Time.deltaTime * 20f;

            // Method B: or have Unity calculate all of the above for you
            // Camera.main.transform.position = Vector2.MoveTowards( 
            //     Camera.main.transform.position, 
            //     cameraFocusTarget.position, 
            //     Time.deltaTime * 20f
            // );
        }
    }

}
