using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// PURPOSE: demo different ways of sound playback using C# code
// USAGE: put this on a game object with an AudioSource
public class AudioDemo : MonoBehaviour
{
    AudioSource myAudioSource;

    float soundTimer = 0f; // when it is 2.0f, it will play the sound... see use-case 4

    void Start()
    {
        myAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // use-case 1: play sound when I press SPACE
        if ( Input.GetKeyDown(KeyCode.Space)  ) {
            myAudioSource.Play(); // can be interrupted by another Play, or with Stop or Pause
        }

        // use-case 2: play a sound frequently with overlap but no interrupt 
        if ( Input.GetKeyDown(KeyCode.Alpha1) ) {
            myAudioSource.PlayOneShot( myAudioSource.clip, 0.5f); // play an uncontrollable sound at 50% volume
        }

        // use-case 3: toggle a looping sound
        if ( Input.GetKeyDown(KeyCode.L) ) {
            myAudioSource.loop = !myAudioSource.loop; // set it to the opposite of itself
            if ( myAudioSource.isPlaying == false ) {
                myAudioSource.Play(); // regular Play() makes use of the looping bool, NOT PlayOneShot
            }
        }

        // use-case 4: play a sound every X seconds
        soundTimer += Time.deltaTime; // after 1 second, soundTimer will be 1.0 larger
        if ( soundTimer >= 2.0f ) {
            myAudioSource.Play();
            soundTimer = 0f; // reset timer back to 0!!
        }



    }
}
