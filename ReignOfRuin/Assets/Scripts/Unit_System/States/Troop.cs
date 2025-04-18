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

    public int health, dmg;
    private bool opponentFound;
    private GameObject enemy;

    private void Awake()
    {   
        transform.parent.position = new Vector3(tC.teleCords.x, transform.parent.position.y, tC.teleCords.y); 
        
        troopStats.xPosition = Mathf.RoundToInt(transform.parent.position.x);
        troopStats.yPosition = Mathf.RoundToInt(transform.parent.position.z); 

        health = troopStats.health;
        dmg = troopStats.dmg; 
        opponentFound = false;
 
        StartCoroutine(WaitForInstance());
    } 

    private IEnumerator WaitForInstance()
    {
        while (GridManager._Instance == null)
            yield return null;
        Debug.Log("GridManager ready");

        StartCoroutine(MoveOnGrid());
    }

    private IEnumerator MoveOnGrid()
    { 
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
        
        //Debug.Log(opponentFound);
        //Debug.Log(health);
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
