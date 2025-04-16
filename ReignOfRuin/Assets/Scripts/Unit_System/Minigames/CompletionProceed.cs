using UnityEngine;

public class CompletionProceed : MonoBehaviour
{
   public UnitHandler uH;

   private void Awake()
   {
      uH = GameObject.Find("Unit").GetComponent<UnitHandler>();
   }

   public void CompleteProceed()
   {
        uH.StateProceed();
   } 
}
