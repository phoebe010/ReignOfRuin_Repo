using UnityEngine;

public class CameraToggle : MonoBehaviour
{
    private Camera Camera1;
    private Camera Camera2;

    public int Manager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public void Start(){
        Camera1 = GameObject.Find ("Main Camera").GetComponent<Camera> ();
        Camera2 = GameObject.Find ("Lanes Camera").GetComponent<Camera> ();

        
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.C)){
            CameraChange();
            Debug.Log("pressed");
        }
    }

    void CameraChange(){
        if (Manager == 0){
            Camera1.rect = new Rect(0, 0, .6f, 1);
            Camera1.rect = new Rect(0, 0, 1, .6f);
            Manager = 1;
        }
        else{
            Camera1.rect = new Rect(0, 0, 1, 1);
            Camera1.rect = new Rect(0, 0, 0, 0);
            Manager = 0;
        }
    }
}