using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float minX;
    [SerializeField] private float maxX;
    [SerializeField] private float minZ;
    [SerializeField] private float maxZ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        for (int i = 0; i < 6; i++){
            Instantiate(coinPrefab, new Vector3(Random.Range(minX, maxX), 0.75f,Random.Range(minZ,maxZ)), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
