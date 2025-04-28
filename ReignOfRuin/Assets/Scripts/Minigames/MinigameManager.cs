using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager _Instance { get; private set; }

    [System.Serializable] public struct MiniGame {
        public int lvl;
        public GameObject miniGameObj;
    }
 
    public List<MiniGame> miniGames = new List<MiniGame>();
    public List<MiniGame> randGames = new List<MiniGame>();  

    private void Awake()
    {
        if (null == _Instance)
            _Instance = this;
        else
            Destroy(gameObject);
    }
//how to randomize this though...
    public void InitMinigame(int x, UnitHandler sH)
    { 
       for (int i=0; i<miniGames.Count; i++) {
            if (x == miniGames[i].lvl) {
                randGames.Add(miniGames[i]);              
            }
       } 
        
       StartCoroutine(StartMiniGame(randGames[Random.Range(0, randGames.Count)], sH));

    }

    private IEnumerator StartMiniGame(MiniGame mG, UnitHandler sH)
    {
        //instantiate minigame object here
        yield return null;

        //at the end of this coroutine, clear randGames
    } 
}
