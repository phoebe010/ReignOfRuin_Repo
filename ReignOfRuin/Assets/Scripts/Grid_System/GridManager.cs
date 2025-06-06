using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public static GridManager _Instance { get; private set; }

    public Vector2Int gridSize;
    [SerializeField] int unityGridSize; 
    public int UnityGridSize {get {return unityGridSize;} }

    public Dictionary<Vector2Int, Node> grid = new Dictionary<Vector2Int, Node>();
    Dictionary<Vector2Int, Node> Grid {get {return grid;} }

    private void Awake()
    {
        if (null == _Instance) 
            _Instance = this;
        else Destroy(gameObject);

        for(int x=0; x<gridSize.x; x++) {
            for (int y=0; y<gridSize.y; y++) {
                Vector2Int cords = new Vector2Int(x, y);
                grid.Add(cords, new Node(cords));
            }
        }
    }
}
