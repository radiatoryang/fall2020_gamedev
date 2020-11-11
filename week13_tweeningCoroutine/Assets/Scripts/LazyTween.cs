using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: show a "lazy" / "dirty" framerate-dependent tweening method in Update()
// USAGE: put this on a Triangle? a 2D shape?
public class LazyTween : MonoBehaviour
{
    public Vector3 destination = new Vector3( 5, 5, 0 );

    void Update()
    {
        // smoothly move this object to its destination

        // move 10% of the distance, from current position to destination, every frame
        transform.position += (destination - transform.position) * 0.1f;
    }
}
