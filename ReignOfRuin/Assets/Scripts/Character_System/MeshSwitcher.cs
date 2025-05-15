using UnityEngine;

public class MeshSwitcher : MonoBehaviour
{
    public GameObject multiMeshPrefab; // Assign in inspector
    public Transform replaceTarget;    // The GameObject to replace (can be this.transform)

    public void ReplaceWithMultiMesh()
    {
        if (multiMeshPrefab == null || replaceTarget == null)
        {
            Debug.LogWarning("Missing reference(s).");
            return;
        }

        // Optional: Store position/rotation
        Vector3 pos = replaceTarget.position;
        Quaternion rot = replaceTarget.rotation;
        Transform parent = replaceTarget.parent;

        // Destroy the old object
        Destroy(replaceTarget.gameObject);

        // Instantiate the new prefab
        GameObject newObject = Instantiate(multiMeshPrefab, pos, rot, parent);
        newObject.name = multiMeshPrefab.name;
    }
}
