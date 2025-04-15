using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitHandler : MonoBehaviour
{
   //brainstorm: Use monobehavior exclusives like OnTrigger in scriptable objects 
   public int state = 1; 

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         if (state == 3) return;
         
         transform.GetChild(state-1).gameObject.SetActive(false);
         transform.GetChild(state++).gameObject.SetActive(true);
      }
   }
}
