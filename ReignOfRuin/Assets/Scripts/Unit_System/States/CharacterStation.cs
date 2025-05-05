using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterStation : MonoBehaviour, UnitInterface
{ 
   public GameObject dialogueUI;
   public Dialogue dialogue;
   //private GameObject dialogueObj; 
   private UnitHandler unitHandler;

   GameObject canvas;  

   private void Awake()
   { 
      unitHandler = transform.parent.gameObject.GetComponent<UnitHandler>(); 

      Again();
      canvas = GameObject.Find("Canvas");  
   }  

   public void Again()
   {
      transform.parent.gameObject.tag = "Untagged";   
      
      if (dialogueUI == null)
         dialogueUI = GameObject.Find("InteractionUI").transform.GetChild(0).gameObject;
   }

   private void OnTriggerEnter(Collider other)
   {    
      if (other.tag == "Player" && !PlayerStates._Instance.isEngaged) { 
         transform.parent.gameObject.tag = "Station"; 
         DialogueEngaged();          
      } 
   }  

   private void OnTriggerExit(Collider other)
   {
      if (other.tag == "Player") {
         Again();
         //Destroy(dialogueObj);
         dialogueUI.SetActive(false);
         PlayerStates._Instance.isEngaged = false;
         unitHandler.imEngaged = false;
      }
   }  

   void Update()
   {
      if (Input.GetKeyDown(KeyCode.Space) && unitHandler.imEngaged)
         DialogueHandler._Instance.SpeechProceed();
   }

   private void DialogueEngaged()
   {
      if (GameObject.FindWithTag("InteractUI") == null) {
         //dialogueObj = Instantiate(dialogueUI, canvas.transform.position, dialogueUI.transform.rotation, canvas.transform); 
         dialogueUI.SetActive(true);
         DialogueHandler._Instance.Begin(dialogue); 
         PlayerStates._Instance.isEngaged = true;
         unitHandler.imEngaged = true;
      }
   }

   public void DestroyUI()
   {  
      PlayerStates._Instance.isEngaged = false; 
      //Destroy(dialogueObj);  
      dialogueUI.SetActive(false);
   }
}
