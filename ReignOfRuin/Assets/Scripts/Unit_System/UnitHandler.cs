using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitHandler : MonoBehaviour
{
   //brainstorm: Use monobehavior exclusives like OnTrigger in scriptable objects  
   public int state = 1, maxStates = 3;  
   public enum UnitType {
      Station,
      Unit
   } public UnitType unitType;

   private void Awake()
   {
      maxStates = transform.childCount;
   } 

   public void StateProceed()
   {
      if (state == maxStates) return; 

      transform.GetChild(state-1).gameObject.GetComponent<UnitInterface>().DestroyUI();
      transform.GetChild(state-1).gameObject.SetActive(false);
 
      transform.GetChild(state++).gameObject.SetActive(true); 
      transform.GetChild(state-1).gameObject.GetComponent<UnitInterface>().Again();
   }

   public void StateReset()
   {
      transform.GetChild(state-1).gameObject.SetActive(false);
      transform.GetChild(0).gameObject.SetActive(true);
      if (unitType == UnitType.Station) transform.GetChild(0).gameObject.GetComponent<Character>().Again();
      state = 1;
   }
}
