using UnityEngine;

public class Character : MonoBehaviour, UnitInterface
{ 
   public GameObject dialogueUI;
   public Dialogue dialogue;
   private GameObject dialogueObj; 
   private UnitHandler unitHandler;

   GameObject canvas;

   bool instantiated;

   private void Awake()
   { 
      unitHandler = transform.parent.gameObject.GetComponent<UnitHandler>();
      Again();
      canvas = GameObject.Find("Canvas");
      //put this under here in a OnTriggerEnter when we have player
   } 

   public void Again()
   {
      transform.parent.gameObject.tag = "Untagged";
      instantiated = false;
   }

   private void OnTriggerEnter(Collider other)
   {
      //Debug.Log("Collided");
      if (other.tag == "Player" &&  !PlayerStates._Instance.isEngaged && unitHandler.unitType == UnitHandler.UnitType.Unit) {
         transform.parent.gameObject.tag = "PlayerUnit";
         if (!instantiated)
            dialogueObj = Instantiate(dialogueUI, canvas.transform.position, dialogueUI.transform.rotation, canvas.transform);
         instantiated = true;
         DialogueHandler._Instance.Begin(dialogue);
         PlayerStates._Instance.isEngaged = true;
      } 
      else if (other.tag == "Player" && !PlayerStates._Instance.isEngaged && unitHandler.unitType == UnitHandler.UnitType.Station) {
         transform.parent.gameObject.tag = "Station";
         if (!instantiated)
            dialogueObj = Instantiate(dialogueUI, canvas.transform.position, dialogueUI.transform.rotation, canvas.transform);
         instantiated = true;
         DialogueHandler._Instance.Begin(dialogue);
         //PlayerStates._Instance.isEngaged = true;
      }
   }

   private void OnTriggerExit(Collider other)
   {
      if (other.tag == "Player") {
         instantiated = false;
         Destroy(dialogueObj);
      }
   }

   public void DestroyUI()
   { 
      Destroy(dialogueObj); 
   }
}
