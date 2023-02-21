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
        oldSlot = activeSlot;
        if (Input.GetKeyDown(KeyCode.Alpha1)) { activeSlot = 0; itemDisplayScript.OnSlotChanged(activeSlot); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { activeSlot = 1; itemDisplayScript.OnSlotChanged(activeSlot); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { activeSlot = 2; itemDisplayScript.OnSlotChanged(activeSlot); }
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
