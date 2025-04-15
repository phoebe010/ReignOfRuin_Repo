using UnityEngine;

public class Character : MonoBehaviour
{
   private void Awake() //turn this into a behavior that activates upon trigger enter & button press
   {
        DialogueHandler._Instance.Begin();
   }
}
