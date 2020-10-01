using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: show how to aim a turret and fire hitscan weapon based on mouse aiming
// USAGE: put this on a player turret object facing east (+X Axis)
public class MouseAim : MonoBehaviour
{
    public GameObject explodePrefab; // assign in Inspector
    void Update()
    {
        // mouse aiming: always face towards the mouse cursor position
        Vector3 mouseCursorPosInWorld = Camera.main.ScreenToWorldPoint( Input.mousePosition );
        Vector2 fromPlayerToMouseCursor = mouseCursorPosInWorld - transform.position;

        // rotate to align my "right" with vec toward mouse cursor
        transform.right = fromPlayerToMouseCursor; 
        Debug.DrawRay( transform.position, fromPlayerToMouseCursor, Color.cyan );

        // raycast from player towards mouse cursor
        Ray2D myRay = new Ray2D( transform.position, transform.right );
        float myMaxRayDist = 10f;
        RaycastHit2D myRayHit = Physics2D.Raycast( myRay.origin, myRay.direction, myMaxRayDist );

        // did we hit something? if so, instantiate something at impact point
        if ( myRayHit.collider != null && Input.GetMouseButtonDown(0) ) {
            // instantiate an explosion at the impact point
            Instantiate( explodePrefab, myRayHit.point, Quaternion.Euler(0, 0, 0) );

            // destroy (delete) the object the raycast hit
            Destroy( myRayHit.collider.gameObject);
        }
    }
}
