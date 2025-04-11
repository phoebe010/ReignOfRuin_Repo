using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHandler : MonoBehaviour
{
    public TestDialogue testDialogue; 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        testDialogue.inx = 0;
        Debug.Log(testDialogue.dialogueSequence[testDialogue.inx]);         
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) { 
            testDialogue.inx++;
            
            if (testDialogue.inx >= testDialogue.dialogueSequence.Capacity)
                return;
            else 
                Debug.Log(testDialogue.dialogueSequence[testDialogue.inx]);
        }
    }
}
