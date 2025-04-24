using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Character : MonoBehaviour, UnitInterface
{ 
   public GameObject dialogueUI;
   public Dialogue dialogue;
   private GameObject dialogueObj; 
   private UnitHandler unitHandler;

   GameObject canvas; 

   [SerializeField] bool notPriority;

   private void Awake()
   { 
      notPriority = false;
      unitHandler = transform.parent.gameObject.GetComponent<UnitHandler>();
      //StartCoroutine(WaitForInstance()); 
      Again();
      canvas = GameObject.Find("Canvas"); 
      //put this under here in a OnTriggerEnter when we have player
   }  

   public void Again()
   {
      transform.parent.gameObject.tag = "Untagged";  
   }

   private void OnTriggerEnter(Collider other)
   { 
      //Debug.Log("Collided");
      if (other.tag == "Player" &&  !PlayerStates._Instance.isEngaged && unitHandler.unitType == UnitHandler.UnitType.Unit) {
         transform.parent.gameObject.tag = "PlayerUnit"; 
         dialogueObj = Instantiate(dialogueUI, canvas.transform.position, dialogueUI.transform.rotation, canvas.transform); 
         DialogueHandler._Instance.Begin(dialogue); 
         PlayerStates._Instance.isEngaged = true;
      } 
      else if (other.tag == "Player" && !notPriority && unitHandler.unitType == UnitHandler.UnitType.Station) {
         notPriority = true;
         transform.parent.gameObject.tag = "Station"; 
         dialogueObj = Instantiate(dialogueUI, canvas.transform.position, dialogueUI.transform.rotation, canvas.transform); 
         DialogueHandler._Instance.Begin(dialogue);   
      } 
   } 

   //private void OnTriggerStay(Collider other)
   //{
   //   if (other.tag == "PlayerUnit" && unitHandler.unitType == UnitHandler.UnitType.Station) {
   //      notPriority = true;
   //   }
   //}

   private void OnTriggerExit(Collider other)
   {
      if (other.tag == "Player") { 
         PlayerStates._Instance.Blink();
         PlayerStates._Instance.isEngaged = false;
         Destroy(dialogueObj);
      }

      if (other.tag == "PlayerUnit" && unitHandler.unitType == UnitHandler.UnitType.Station) { 
         notPriority = false;
      }
   }

   public void Blink()
   {
      StartCoroutine(BlinkRoutine());
   }

   private IEnumerator BlinkRoutine()
   { 
      transform.parent.gameObject.GetComponent<CapsuleCollider>().enabled = false;
      yield return new WaitForSeconds(0.1f); 
      transform.parent.gameObject.GetComponent<CapsuleCollider>().enabled = true; 
   }

   public void DestroyUI()
   {  
      Destroy(dialogueObj);  
   }
}
