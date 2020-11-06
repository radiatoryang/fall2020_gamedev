using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// PURPOSE: show how to parse a .TXT file as if it were an NPC dialogue script (see GameData/NPC_Dialogue.txt)
// USAGE: put this on an object with a Text UI component?
public class TxtDialogue : MonoBehaviour
{
    public TextAsset textFile; // assign in Inspector!
    string[] dialogueLines; // store dialogue lines as separate strings in array
    int dialogueIndexCounter = 0; // which index in dialogueLines array to display?

    public Text myTextUI; // assign in Inspector!

    void Start()
    {
        dialogueLines = textFile.text.Split('\n'); // split the ENTIRE text data by line breaks (\n)
    }

    void Update()
    {
        myTextUI.text = dialogueLines[dialogueIndexCounter];
    }

    // called by our Button UI object from the Inspector
    public void ContinueDialogue() {
        // e.g. if there are 4 dialogue lines, then the last index is 3
        if ( dialogueIndexCounter < dialogueLines.Length-1 ) {
            dialogueIndexCounter++;
        }
    }
}
