using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Troop : MonoBehaviour, UnitInterface 
{
    //GridManager gridManager = GridManager._Instance;
    public static Troop _Instance { get; private set; }

    public TroopStats troopStats;  

    private void Awake()
    {
        if (null == _Instance)
            _Instance = this;
        else
            Destroy(gameObject);

        troopStats.xPosition = Mathf.RoundToInt(transform.position.x);
        troopStats.yPosition = Mathf.RoundToInt(transform.position.z);

        StartCoroutine(MoveOnGrid());
    } 

    private IEnumerator MoveOnGrid()
    {
        if (transform.parent.position.x < GridManager._Instance.grid[troopStats.TargCordCompiler()].cords.x) {
            for (; transform.parent.position.x < GridManager._Instance.grid[troopStats.TargCordCompiler()].cords.x; 
                transform.parent.position = new Vector3(transform.parent.position.x+1, transform.parent.position.y, transform.parent.position.z)) {
                if (transform.parent.position.x  == 0) continue;
                
                yield return new WaitForSeconds(troopStats.speed);
            }
        } else if (transform.parent.position.x > GridManager._Instance.grid[troopStats.TargCordCompiler()].cords.x) {
            for (; transform.parent.position.x > GridManager._Instance.grid[troopStats.TargCordCompiler()].cords.x; 
                transform.parent.position = new Vector3(transform.parent.position.x-1, transform.parent.position.y, transform.parent.position.z)) {
                if (transform.parent.position.x  == 0) continue;
                
                yield return new WaitForSeconds(troopStats.speed);
            }
        }

        for (; transform.parent.position.z < GridManager._Instance.grid[troopStats.TargCordCompiler()].cords.y; 
            transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z+1)) { 
            if (transform.parent.position.y == 0) continue;

            yield return new WaitForSeconds(troopStats.speed);
        }
    }

    public void DestroyUI()
    {}
} 
