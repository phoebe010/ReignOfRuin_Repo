using UnityEngine;

public class CompletionProceed : MonoBehaviour
{
   public UnitHandler uH;
 

   private DialogueHandler dH;

   private void Awake()
   {
      
      uH = GameObject.Find("Unit").GetComponent<UnitHandler>();

      dH = DialogueHandler._Instance; 
   }

   public void CompleteProceed()
   { 
      uH.StateProceed(); 
   } 

   public void SpeechProceed()
   { 
      dH.testDialogue.inx++;
   
      if (dH.testDialogue.inx >= dH.testDialogue.dialogueSequence.Capacity) {
            uH.StateProceed();
            return;
      } else  
         if (dH.testDialogue.dialogueSequence[dH.testDialogue.inx] == null) {
            uH.StateProceed();
            return; 
         }
         else
            dH.StartCoroutine(dH.TypeWriter(dH.testDialogue.dialogueSequence[dH.testDialogue.inx]));    
      
   }
}
