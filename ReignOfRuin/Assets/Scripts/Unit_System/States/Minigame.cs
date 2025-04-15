using UnityEngine;

public class Minigame : MonoBehaviour, UnitInterface
{
   public GameObject minigame;
   private GameObject miniGameObj;

   private void Awake()
   {
        //Debug.Log("This is a minigame");
      GameObject canvas = GameObject.Find("Canvas");

      miniGameObj = Instantiate(minigame, canvas.transform.position, minigame.transform.rotation, canvas.transform);

   } 

   public void DestroyUI()
   {
      Destroy(miniGameObj);
   }
}
