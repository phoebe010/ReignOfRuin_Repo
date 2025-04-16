using UnityEngine;

public class Character : MonoBehaviour, UnitInterface
{ 
   public GameObject dialogueUI;
   private GameObject dialogueObj; 

   private void Awake()
   { 
      GameObject canvas = GameObject.Find("Canvas");
      //put this under here in a OnTriggerEnter when we have player
      dialogueObj = Instantiate(dialogueUI, canvas.transform.position, dialogueUI.transform.rotation, canvas.transform);
      DialogueHandler._Instance.Begin();
   } 

   public void DestroyUI()
   {
      Destroy(dialogueObj); 
   }
}
