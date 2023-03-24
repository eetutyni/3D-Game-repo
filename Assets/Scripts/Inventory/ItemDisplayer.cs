using UnityEngine;

public class ItemDisplayer : MonoBehaviour
{
    public void SpawnItem(InventoryItemData itemData, Vector3 position)
    {
        Instantiate(itemData.prefab, position, Quaternion.identity);
    }

    public GameObject SpawnItemUnderParent(InventoryItemData itemData, Transform parent)
    {
        GameObject item = Instantiate(itemData.prefab, parent.position + itemData.spawnPos, parent.rotation * itemData.rotation, parent);
        return item;
    }
}
