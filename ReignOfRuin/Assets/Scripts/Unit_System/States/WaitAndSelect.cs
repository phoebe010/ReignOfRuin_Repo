using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class WaitAndSelect : MonoBehaviour, UnitInterface
{
    public TeleCords tC;

    TextMeshProUGUI displayCordsText;

    public GameObject startTileUI;
    private GameObject startTileObj; 

    private void Awake()
    {     
        GameObject canvas = GameObject.Find("Canvas");

        startTileObj = Instantiate(startTileUI, canvas.transform.position, startTileUI.transform.rotation, canvas.transform);
        
        displayCordsText = startTileObj.GetComponent<TextMeshProUGUI>();
    }


    void Update()
    { 
        displayCordsText.text = $"{tC.teleCords.x}, {tC.teleCords.y}";

        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            tC.teleCords.x++;
            if (tC.teleCords.x > GridManager._Instance.gridSize.x-1)
                tC.teleCords.x = 0;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            tC.teleCords.x--;
            if (tC.teleCords.x < 0)
                tC.teleCords.x = GridManager._Instance.gridSize.x-1;
        }
    }
   
   public void DestroyUI()
   {
        Destroy(startTileObj);
   } 
}
