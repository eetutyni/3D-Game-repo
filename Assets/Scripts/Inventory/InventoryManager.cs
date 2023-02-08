using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<InventoryItemData> items = new List<InventoryItemData>();

    private void Awake()
    {
        Instance = this;
    }

    public void AddItem(InventoryItemData item)
    {
        items.Add(item);
    }

    public void RemoveItem(InventoryItemData item)
    {
        items.Remove(item);
    }
}
