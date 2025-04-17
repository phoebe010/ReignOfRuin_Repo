using UnityEngine;

public class Character : MonoBehaviour, UnitInterface
{ 
   public GameObject dialogueUI;
   public Dialogue dialogue;
   private GameObject dialogueObj; 

   GameObject canvas;

   private void Awake()
   { 
      transform.parent.gameObject.tag = "Untagged";
      canvas = GameObject.Find("Canvas");
      //put this under here in a OnTriggerEnter when we have player
   } 

   private void OnTriggerEnter(Collider other)
   {
      //Debug.Log("Collided");
      transform.parent.gameObject.tag = "PlayerUnit";
      dialogueObj = Instantiate(dialogueUI, canvas.transform.position, dialogueUI.transform.rotation, canvas.transform);
      DialogueHandler._Instance.Begin(dialogue);
   }

   public void DestroyUI()
   { 
      Destroy(dialogueObj); 
   }
}
