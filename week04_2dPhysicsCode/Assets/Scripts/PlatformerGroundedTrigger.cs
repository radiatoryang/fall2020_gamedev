using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerGroundedTrigger : MonoBehaviour
{
    // we need a reference to the PlatformerCharacter script, or else we can't talk to it
    public PlatformerCharacter myCharacter; // public: assign in Inspector!

    // happens EVERY FRAME there's an object inside this trigger area
    void OnTriggerStay2D(Collider2D activator) {
        myCharacter.isGrounded = true;
    }

    // happens the FIRST FRAME when an object leaves the trigger area
    void OnTriggerExit2D(Collider2D activator) {
        myCharacter.isGrounded = false;
    }
}
