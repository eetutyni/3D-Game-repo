using UnityEngine;

public class ItemDisplayer : MonoBehaviour
{
    public void SpawnItem(GameObject prefab, Vector3 position)
    {
        Instantiate(prefab, position, Quaternion.identity);
    }

    public GameObject SpawnItemUnderParent(GameObject prefab, Quaternion rotation, Transform parent)
    {
        GameObject item = Instantiate(prefab, parent.position, rotation, parent);
        return item;
    }
}
