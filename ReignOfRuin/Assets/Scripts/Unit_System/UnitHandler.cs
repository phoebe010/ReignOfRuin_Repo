using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitHandler : MonoBehaviour
{
   //brainstorm: Use monobehavior exclusives like OnTrigger in scriptable objects 
   public static UnitHandler _Instance { get; private set; }
   public int state = 1; 

   private void Awake()
   {
      if (null == _Instance)
         _Instance = this;
      else 
         Destroy(gameObject);
   }

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space))
      {
         if (state == 3) return;

         StateProceed(); 
      }
   }

   public void StateProceed()
   {
      UnitInterface unitState = transform.GetChild(state-1).gameObject.GetComponent<UnitInterface>();
      unitState.DestroyUI();
      transform.GetChild(state-1).gameObject.SetActive(false);
         //access function to destroy children's instantiated UI
      transform.GetChild(state++).gameObject.SetActive(true);

   }
}
