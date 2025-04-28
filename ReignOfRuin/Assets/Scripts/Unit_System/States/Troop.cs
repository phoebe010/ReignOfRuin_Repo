using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Troop : MonoBehaviour, UnitInterface 
{
    //turn this into two scripts
    public TroopStats troopStats;  
    public TeleCords tC;

    public enum TroopType {
        Peasant,
        Archer,
        Air
    } public TroopType troopType; 

    public float health, dmg;
    private bool opponentFound;
    private GameObject enemy;

    private void Awake()
    {  
        switch (transform.parent.gameObject.GetComponent<UnitHandler>().statMultiplier) {    
            case 0: 
                health = troopStats.health;
                dmg = troopStats.dmg; 
                break;
            case 1:
                health = troopStats.health*1.25f;
                dmg = troopStats.dmg*1.25f;
                break;
            case 2:
                health = troopStats.health*1.5f;
                dmg = troopStats.dmg*1.5f;
                break;
        }
        
        opponentFound = false; 
 
        StartCoroutine(WaitForInstance());
    } 

    public void Again()
    {}

    private IEnumerator WaitForInstance()
    {
        while (GridManager._Instance == null)
            yield return null;
        Debug.Log("GridManager ready");

        StartCoroutine(MoveToGrid());
    }

    private IEnumerator MoveToGrid()
    {
        float elapsedTime=0, hangTime=2f;
        Vector3 curPos=transform.parent.position, targPos=new Vector3(tC.teleCords.x, transform.parent.position.y, tC.teleCords.y), curRot=transform.parent.eulerAngles;

        while (elapsedTime < hangTime) {
            transform.parent.position = Vector3.Lerp(curPos, targPos, (elapsedTime/hangTime));
            transform.parent.eulerAngles = Vector3.Lerp(curRot, Vector3.forward, (elapsedTime/hangTime));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.parent.position = targPos;
        transform.parent.eulerAngles = Vector3.forward;

        StartCoroutine(MoveOnGrid());
    }

    private IEnumerator MoveOnGrid()
    { 
        troopStats.xPosition = Mathf.RoundToInt(transform.parent.position.x);
        troopStats.yPosition = Mathf.RoundToInt(transform.parent.position.z); 

        //probably gonna need to add lerping to this
        if (transform.parent.position.x < GridManager._Instance.grid[troopStats.TargCordCompiler()].cords.x) {
            for (; transform.parent.position.x < GridManager._Instance.grid[troopStats.TargCordCompiler()].cords.x; 
                transform.parent.position = new Vector3(transform.parent.position.x+1, transform.parent.position.y, transform.parent.position.z)) {
                if (opponentFound == true) yield break;
                if (transform.parent.position.x  == 0) continue;
                
                yield return new WaitForSeconds(troopStats.speed);
            }
        } else if (transform.parent.position.x > GridManager._Instance.grid[troopStats.TargCordCompiler()].cords.x) {
            for (; transform.parent.position.x > GridManager._Instance.grid[troopStats.TargCordCompiler()].cords.x; 
                transform.parent.position = new Vector3(transform.parent.position.x-1, transform.parent.position.y, transform.parent.position.z)) {
                if (opponentFound == true) yield break;
                if (transform.parent.position.x  == 0) continue;
                
                yield return new WaitForSeconds(troopStats.speed);
            }
        }
        
        for (; transform.parent.position.z < GridManager._Instance.grid[troopStats.TargCordCompiler()].cords.y; 
            transform.parent.position = new Vector3(transform.parent.position.x, transform.parent.position.y, transform.parent.position.z+1)) { 
            if (opponentFound == true) yield break;
            if (transform.parent.position.z == 0) continue;

            yield return new WaitForSeconds(troopStats.speed);
        }
    }

    void Update()
    {
        if (health <= 0)
            Destroy(transform.parent.gameObject);
         
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OpponentUnit") {
            opponentFound = true;
            enemy = other.gameObject;
            StartCoroutine(DealDamage());
        }
    }

    private IEnumerator DealDamage()
    {
        while (true) {
            if (enemy != null) {
                enemy.GetComponentInChildren<TroopOpponent>().health -= dmg;

                yield return new WaitForSeconds(troopStats.speed);
            } else {
                opponentFound = false;
                StartCoroutine(MoveOnGrid());
                yield break;
            }
        }
    }

    public void DestroyUI()
    {}
} 
