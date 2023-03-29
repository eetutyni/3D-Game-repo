using UnityEngine;

public class ItemController : MonoBehaviour
{
    public InventoryItemData itemData;
    public bool objectInSight;

    public void SetObjectInSight(bool value)
    {
        objectInSight = value;
    }

    public InventoryItemData GetItemData()
    {
        return itemData;
    }
}
