using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ButtonCycler : MonoBehaviour
{
    public int cIndex=0;
    public int maxButtons;

    private void Awake() 
    {
        maxButtons = transform.childCount;
    }
    // Update is called once per frame
    void Update()
    {
       if (Input.GetKeyDown(KeyCode.E)) {
            cIndex++;
            if (cIndex > maxButtons-1)
                cIndex=0;
       }
       if (Input.GetKeyDown(KeyCode.Q)) {
            cIndex--;
            if (cIndex < 0)
                cIndex=maxButtons-1;
       }
       if (Input.GetKeyDown(KeyCode.Space)) {
            Debug.Log("Time for a minigame");
            transform.GetChild(cIndex).GetComponent<ProceedButton>().MinigameProceed();
       }
    }
}
