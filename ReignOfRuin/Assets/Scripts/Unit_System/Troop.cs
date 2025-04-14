using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Troop : MonoBehaviour
{
    //GridManager gridManager = GridManager._Instance;
    
    public Vector2Int targCord = new Vector2Int(2, 4);
    public float speed = 0.5f;

    private void Start()
    { 
        Debug.Log(GridManager._Instance);

        StartCoroutine(MoveOnGrid());         
    }  

    private IEnumerator MoveOnGrid()
    {
        for (; transform.position.x < GridManager._Instance.grid[targCord].cords.x; 
            transform.position = new Vector3(transform.position.x+1, transform.position.y, transform.position.z)) {
            if (transform.position.x  == 0) continue;
            //for (; transform.position.z < GridManager._Instance.grid[targCord].cords.y; 
            //    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+1)) { 

            //    yield return new WaitForSeconds(speed);
            //}
            yield return new WaitForSeconds(speed);
        }

        for (; transform.position.z < GridManager._Instance.grid[targCord].cords.y; 
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z+1)) { 
            if (transform.position.y == 0) continue;

            yield return new WaitForSeconds(speed);
        }
    }
} 
