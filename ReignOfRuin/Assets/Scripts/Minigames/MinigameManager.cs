using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinigameManager : MonoBehaviour
{
    public List<int> lvls = new List<int>(); 

    private void Awake()
    {
        for (int i=0; i<transform.childCount; i++) {   
            lvls.Add(i);
        }

        StartCoroutine(SetStats());       
    }

    private IEnumerator SetStats()
    {
        foreach (int lvl in lvls) {
            Debug.Log(lvl);

            yield return null;        
        } 
    }
}
