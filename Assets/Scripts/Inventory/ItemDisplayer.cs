using UnityEngine;
using static UnityEditor.Progress;

public class ItemDisplayer : MonoBehaviour
{
    public void SpawnItem(InventoryItemData itemData, Vector3 position)
    {
        GameObject item = Instantiate(itemData.prefab, position, Quaternion.identity);
        Rigidbody rb;
        item.TryGetComponent(out rb);
        rb.constraints = RigidbodyConstraints.None;
    }

    public GameObject SpawnItemUnderParent(InventoryItemData itemData, Transform parent)
    {
        GameObject item = Instantiate(itemData.prefab, parent.position + itemData.spawnPos, parent.rotation * itemData.rotation, parent);
        Rigidbody rb;
        item.TryGetComponent(out rb);
        rb.constraints = RigidbodyConstraints.FreezeAll;
        return item;
    }
}
