using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: show how to spawn a list of NPCs and manage those NPCs (not unlike a god)
// USAGE: place this script on an empty game object called FishGod
public class FishGod : MonoBehaviour
{
    public Fish fishPrefab; // assign in Inspector!
    List<Fish> fishCloneList = new List<Fish>();
    public int maxFishCount = 100;

    void Start()
    {
        while ( fishCloneList.Count < maxFishCount ) {
            Vector2 randomPosition = new Vector2( Random.Range(-5f, 5f), Random.Range(-5f, 5f) );
            Fish newFishClone = Instantiate( fishPrefab, randomPosition, Quaternion.Euler(0,0,Random.Range(0,360)) );
            fishCloneList.Add( newFishClone );
        }
    }

    void Update()
    {
        // press SPACEBAR, tell all the fish to randomly swim somewhere else?
        if ( Input.GetKeyDown(KeyCode.Space) ) {
            for ( int i=0; i<fishCloneList.Count; i++) {
                fishCloneList[i].myDestination = new Vector2( Random.Range(-5f, 5f), Random.Range(-5f, 5f) );
            }
        }

        // press P, tell all fish to return back to (0,0)
        if ( Input.GetKeyDown(KeyCode.P ) ) {
            foreach ( Fish eachFish in fishCloneList ) {
                eachFish.myDestination = Vector2.zero;
            }
        }
        
    }
}
