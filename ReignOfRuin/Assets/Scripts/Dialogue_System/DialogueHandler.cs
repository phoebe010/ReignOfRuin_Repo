using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueHandler : MonoBehaviour
{
    public static DialogueHandler _Instance;

    public TestDialogue testDialogue; 
    public TextMeshProUGUI txtToScreen;
    public float delay = 0.1f;

    private void Awake()
    {
        if (null == _Instance)
            _Instance = this;
        else Destroy(gameObject);
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Begin()
    {
        testDialogue.inx = 0;        
        StartCoroutine(TypeWriter(testDialogue.dialogueSequence[testDialogue.inx]));
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow)) { 
            testDialogue.inx++;
            
            if (testDialogue.inx >= testDialogue.dialogueSequence.Capacity)
                return;
            else  
                StartCoroutine(TypeWriter(testDialogue.dialogueSequence[testDialogue.inx]));
        }
    }

    IEnumerator TypeWriter(string dialogue) {
        for (int i=0; i<testDialogue.dialogueSequence[testDialogue.inx].Length+1; i++) {
            txtToScreen.text = testDialogue.dialogueSequence[testDialogue.inx].Substring(0, i);
            yield return new WaitForSeconds(delay);
        }
    }
}
