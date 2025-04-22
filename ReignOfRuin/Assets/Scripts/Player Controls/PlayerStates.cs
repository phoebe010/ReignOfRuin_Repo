using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerStates : MonoBehaviour
{
    public static PlayerStates _Instance { get; private set; }
    public Vector3 playerPos;
    public bool isEngaged;

    private void Awake()
    {
        if (null == _Instance)
            _Instance = this;
        else   
            Destroy(gameObject);

        isEngaged = false;
    }

    void Update()
    {
        playerPos = transform.position;

        if (isEngaged == true) {
            gameObject.GetComponent<CapsuleCollider>().enabled = false;
        } else {
            gameObject.GetComponent<CapsuleCollider>().enabled = true;
        }
    }
}
