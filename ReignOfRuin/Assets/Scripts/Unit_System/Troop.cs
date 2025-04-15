using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Troop : MonoBehaviour 
{
    //GridManager gridManager = GridManager._Instance;
    public static Troop _Instance { get; private set; }

    public TroopStats troopStats; 
    //public Vector2Int targCord = new Vector2Int(2, 4);
    //public float speed = 0.5f;

    private void Awake()
    {
        if (null == _Instance)
            _Instance = this;
        else
            Destroy(gameObject);

        StartCoroutine(MoveOnGrid());
    } 

    private IEnumerator MoveOnGrid()
    {
        for (; transform.parent.position.x < GridManager._Instance.grid[troopStats.targCord].cords.x; 
            transform.parent.position = new Vector3(transform.parent.position.x+1, transform.parent.position.y, transform.parent.position.z)) {
            if (transform.parent.position.x  == 0) continue;
            
            yield return new WaitForSeconds(troopStats.speed);
        }

        for (; transform.parent.position.z < GridManager._Instance.grid[troopStats.targCord].cords.y; 
            transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z+1)) { 
            if (transform.parent.position.y == 0) continue;

            yield return new WaitForSeconds(troopStats.speed);
        }
    }
} 
