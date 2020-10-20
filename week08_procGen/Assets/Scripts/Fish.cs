using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: this is a Fish NPC that randomly swims around with its own free will!!
// USAGE: put this on an orange triangle prefab
public class Fish : MonoBehaviour
{
    public Vector3 myDestination; // where the fish is swimming towards

    // Update is called once per frame
    void Update()
    {
        // tell the fish to swim toward its destination
        Vector3 swimVector = myDestination - transform.position;
        transform.position += swimVector.normalized * Time.deltaTime;

        // tell the fish to point toward where it's going
        transform.up = swimVector.normalized;

        // when coding NPCs, debug what the NPC is thinking
        Debug.DrawLine( transform.position, myDestination, Color.yellow );
    }
}
