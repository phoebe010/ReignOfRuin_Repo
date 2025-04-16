using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class WaitAndSelect : MonoBehaviour, UnitInterface
{
    public static WaitAndSelect _Instance { get; private set; }

    public Vector2Int teleCords = new Vector2Int(0, 0);
    TextMeshProUGUI displayCordsText;

    public GameObject startTileUI;
    private GameObject startTileObj; 

    private void Awake()
    {
        if (null == _Instance)
            _Instance = this;
        else
            Destroy(gameObject);
        
        GameObject canvas = GameObject.Find("Canvas");

        startTileObj = Instantiate(startTileUI, canvas.transform.position, startTileUI.transform.rotation, canvas.transform);
        
        displayCordsText = startTileObj.GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        Debug.Log(displayCordsText);
        displayCordsText.text = $"{teleCords.x}, {teleCords.y}";

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            teleCords.x++;
            if (teleCords.x >= GridManager._Instance.gridSize.x)
                teleCords.x = 0;
        }
    }
   
   public void DestroyUI()
   {
        Destroy(startTileObj);
   } 
}
