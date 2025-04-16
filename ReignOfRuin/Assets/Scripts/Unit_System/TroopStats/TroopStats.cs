using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "TestTroopStats", menuName = "Scriptable Objects/TestTroopStats")]
public class TroopStats : ScriptableObject
{
   public Vector2Int targCord; //= new Vector2Int(0, 4);
   public float speed = 0.5f; 

   public int xPosition, yPosition;
   
   public enum Path {
      Straight,
      L,
      Across
   } public Path path;

   public Vector2Int TargCordCompiler()
   {
      if (path == Path.Straight) {
         targCord = new Vector2Int(xPosition, GridManager._Instance.gridSize.y-1);
      } 
      else if (path == Path.L) {
         if (xPosition <= Mathf.RoundToInt((GridManager._Instance.gridSize.x-1)/2))
            targCord = new Vector2Int(xPosition+1, GridManager._Instance.gridSize.y-1);
         else if (xPosition > Mathf.RoundToInt((GridManager._Instance.gridSize.x-1)/2))
            targCord = new Vector2Int(xPosition-1, GridManager._Instance.gridSize.y-1);
      } 
      else if (path == Path.Across) {
         if (xPosition <= Mathf.RoundToInt((GridManager._Instance.gridSize.x-1)/2))
            targCord = new Vector2Int(GridManager._Instance.gridSize.x-1, GridManager._Instance.gridSize.y-1);      
         else if (xPosition > Mathf.RoundToInt((GridManager._Instance.gridSize.x-1)/2))
            targCord = new Vector2Int(0, GridManager._Instance.gridSize.y-1); 
      }

      return targCord;
   }
}
