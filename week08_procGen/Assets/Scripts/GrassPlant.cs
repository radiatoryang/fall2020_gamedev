using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: show how to randomly spawn an object at a random position, e.g. a bunch of grass
// USAGE: put this on an empty game object and assign a GrassPrefab in the Inspector
public class GrassPlant : MonoBehaviour
{
    public Transform grassPrefab; // prefab to assign in Inspector
    public int maxGrassCount = 500; // maximum number of grass clones to instantiate
    int currentGrassSpawnedSoFar = 0;

    void Update()
    {   // as long as we haven't spawned a lot of grass already, keep spawning grass
        if ( currentGrassSpawnedSoFar < maxGrassCount ) {
            Vector2 randomPosition = new Vector2(Random.Range(-5f, 5f), Random.Range(-4f, 4f ) );
            Instantiate( grassPrefab, randomPosition, Quaternion.Euler(0, 0, 0) );
            currentGrassSpawnedSoFar++;
        }
    }
}
