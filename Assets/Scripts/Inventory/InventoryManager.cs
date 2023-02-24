using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance;
    public List<InventoryItemData> items = new List<InventoryItemData>(3);

    [SerializeField] private ItemDisplayer itemDisplayScript;
    public int oldSlot;
    public int activeSlot;

    void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        activeSlot = 1;
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { oldSlot = activeSlot; activeSlot = 0; itemDisplayScript.OnSlotChanged(activeSlot); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { oldSlot = activeSlot; activeSlot = 1; itemDisplayScript.OnSlotChanged(activeSlot); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { oldSlot = activeSlot; activeSlot = 2; itemDisplayScript.OnSlotChanged(activeSlot); }

        if (Input.GetKeyDown(KeyCode.G) && items[activeSlot] != null) itemDisplayScript.DropItem(items[activeSlot]);
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
