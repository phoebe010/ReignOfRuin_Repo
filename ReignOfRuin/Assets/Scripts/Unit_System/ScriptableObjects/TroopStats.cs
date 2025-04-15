using UnityEngine;

[CreateAssetMenu(fileName = "TestTroopStats", menuName = "Scriptable Objects/TestTroopStats")]
public class TroopStats : ScriptableObject
{
   public Vector2Int targCord = new Vector2Int(0, 4);
   public float speed = 0.5f; 
}
