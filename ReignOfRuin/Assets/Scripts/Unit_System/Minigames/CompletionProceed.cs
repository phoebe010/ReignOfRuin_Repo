using UnityEngine;

public class CompletionProceed : MonoBehaviour
{
   public UnitHandler uH;

   private DialogueHandler dH;

   private void Awake()
   {
      //this shit needs to change 
      uH = GameObject.FindWithTag("PlayerUnit").GetComponent<UnitHandler>();

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
            CompleteProceed();
            return;
      } else  
         if (dH.testDialogue.dialogueSequence[dH.testDialogue.inx] == null) {
            CompleteProceed();
            return; 
         }
         else
            dH.StartCoroutine(dH.TypeWriter(dH.testDialogue.dialogueSequence[dH.testDialogue.inx], dH.testDialogue));    
      
   }
}
