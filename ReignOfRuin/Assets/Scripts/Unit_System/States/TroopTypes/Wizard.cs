using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Wizard : MonoBehaviour
{
    public Troop troop;
    public List<GameObject> enemies = new List<GameObject>();
    public GameObject enemy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "OpponentUnit" && troop.opponentFound == false) { 
            troop.opponentFound = true;
            enemies.Add(other.gameObject);
            
            foreach(GameObject en in enemies)
                StartCoroutine(DealDamage(en));
        }
        if (other.tag == "OpponentStronghold" && troop.opponentFound == false) {
            troop.opponentFound = true;
            enemy = other.gameObject;
            StartCoroutine(DealDamageStronghold());
        }
    }

    private IEnumerator DealDamageStronghold()
    {
        while (true) { 
            if (enemy != null) {
                enemy.GetComponent<Stronghold>().health -= troop.dmg;

                yield return new WaitForSeconds(troop.troopStats.speed);
            } else {
                troop.opponentFound = false;
                yield break;
            }
        }
    }

    private IEnumerator DealDamage(GameObject en)
    { //infinite loop
        //while (true) {
            if (en != null) {
                en.GetComponentInChildren<TroopOpponent>().health -= troop.dmg;
                yield return new WaitForSeconds(troop.troopStats.speed);
            } else if (enemies.Count < 1) {
                troop.opponentFound = false;
                StartCoroutine(troop.MoveOnGrid());
                yield break;
            }
        //}
    }
}
