using UnityEngine;

public class Character : MonoBehaviour
{
   public static Character _Instance { get; private set; }

   private void Awake()
   {
      if (null == _Instance)          
        _Instance = this;
      else
         Destroy(gameObject);

      DialogueHandler._Instance.Begin();
   } 
}
