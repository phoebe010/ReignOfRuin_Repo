using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Troop : MonoBehaviour, UnitInterface 
{
    //GridManager gridManager = GridManager._Instance;
    public TroopStats troopStats;  
    public TeleCords tC;

    private Vector2Int testCords = new Vector2Int(0, 0);

    public enum TroopType {
        Player,
        Opponent
    } public TroopType troopType;

    private void Awake()
    { 
        if (transform.parent.tag == "PlayerUnit") {
            transform.parent.position = new Vector3(tC.teleCords.x, transform.parent.position.y, tC.teleCords.y); 
            troopType = TroopType.Player;
        } else if (transform.parent.tag == "OpponentUnit") {
            troopType = TroopType.Opponent;
        }

        troopStats.xPosition = Mathf.RoundToInt(transform.parent.position.x);
        troopStats.yPosition = Mathf.RoundToInt(transform.parent.position.z); 

        if (troopType == TroopType.Player)
            StartCoroutine(MoveOnGridPlayer());
        else if (troopType == TroopType.Opponent)
            StartCoroutine(MoveOnGridOpponent());
    } 

    private IEnumerator MoveOnGridPlayer()
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
            if (transform.parent.position.z == 0) continue;

            yield return new WaitForSeconds(troopStats.speed);
        }
    }

    private IEnumerator MoveOnGridOpponent()
    { 
        if (transform.parent.position.x < GridManager._Instance.grid[testCords].cords.x) {
            for (; transform.parent.position.x < GridManager._Instance.grid[testCords].cords.x; 
                transform.parent.position = new Vector3(transform.parent.position.x+1, transform.parent.position.y, transform.parent.position.z)) {
                if (transform.parent.position.x  == 0) continue;
                
                yield return new WaitForSeconds(troopStats.speed);
            }
        } else if (transform.parent.position.x > GridManager._Instance.grid[testCords].cords.x) {
            for (; transform.parent.position.x > GridManager._Instance.grid[testCords].cords.x; 
                transform.parent.position = new Vector3(transform.parent.position.x-1, transform.parent.position.y, transform.parent.position.z)) {
                if (transform.parent.position.x  == 0) continue;
                
                yield return new WaitForSeconds(troopStats.speed);
            }
        }

        for (; transform.parent.position.z > GridManager._Instance.grid[testCords].cords.y; 
            transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z-1)) { 
            //Debug.Log(GridManager._Instance.grid[troopStats.TargCordCompiler()].cords.y);
            if (transform.parent.position.z == 0) continue;

            yield return new WaitForSeconds(troopStats.speed);
        }
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    public void DestroyUI()
    {}
} 
