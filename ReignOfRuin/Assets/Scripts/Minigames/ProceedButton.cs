using UnityEngine;

public class ProceedButton : MonoBehaviour
{
   public UnitHandler uH, sH;

   private DialogueHandler dH;

   private void Awake()
   {
      //this shit needs to change 
      dH = DialogueHandler._Instance; 
   }

   public void CompleteProceedButton()
   { 
      if (GameObject.FindWithTag("PlayerUnit") != null)
         uH = GameObject.FindWithTag("PlayerUnit").GetComponent<UnitHandler>();
      if (GameObject.FindWithTag("Station") != null)
         sH = GameObject.FindWithTag("Station").GetComponent<UnitHandler>();

      if (GameObject.FindWithTag("Station") != null && sH.imEngaged)
         sH.StateProceed();

      if (GameObject.FindWithTag("PlayerUnit") != null)
         uH.StateProceed(); 
   } 

   public void SpeechProceedButton()
   { 
      dH.SpeechProceed();
   }

   public void MinigameProceed()
   {
      MinigameManager._Instance.InitMinigame(transform.GetSiblingIndex(), sH);
      //Destroy(transform.parent.gameObject);
      transform.parent.gameObject.SetActive(false);
   }
}
