using UnityEngine;
using System.Collections.Generic;

public class Inventory : MonoBehaviour
{
    [SerializeField] private HintManager hintManager;

    public List<InventoryItemData> items;
    public float pickupDistance = 2f;

    [SerializeField] private Transform cameraTransform;
    [SerializeField] private ItemDisplayer itemDisplayer;
    [SerializeField] private Transform itemHolder;

    private ItemController objectInSight;
    private GameObject currentlyHeldItem;

    public int activeSlotIndex = 0;
    private int maxItems = 5;

    private void Start()
    {
        items = new List<InventoryItemData>();
    }

    private void FixedUpdate()
    {
        CheckForObjectInSight();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickupObjectInSight();
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            DropItem();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SetActiveSlot(0);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SetActiveSlot(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            SetActiveSlot(2);
        }
    }

    private void CheckForObjectInSight()
    {
        RaycastHit hit;
        if (Physics.Raycast(cameraTransform.position, cameraTransform.forward, out hit, pickupDistance))
        {
            ItemController itemController = hit.collider.gameObject.GetComponent<ItemController>();
            if (itemController != null && itemController.itemData != null)
            {
                itemController.SetObjectInSight(true);
                objectInSight = itemController;
                InteractLabel.instance.SetLabel("pickup");
            }
            else InteractLabel.instance.HideLabel();
        }
        else
        {
            if (objectInSight != null)
            {
                objectInSight.SetObjectInSight(false);
                objectInSight = null;
                InteractLabel.instance.HideLabel();
            }
        }
    }

    private void PickupObjectInSight()
    {
        if (items.Count >= maxItems) return;

        if (objectInSight != null && objectInSight.objectInSight)
        {
            InventoryItemData itemData = objectInSight.GetItemData();
            if (itemData != null && itemData.prefab != null)
            {
                itemDisplayer.SpawnItemUnderParent(itemData, itemHolder.transform);
                items.Add(itemData);
                for (int i = 0; i < items.Count; i++) if (items[i] == itemData) SetActiveSlot(i);
                Destroy(objectInSight.gameObject);

                if (itemData.itemId == 0 && !itemData.hintShown)
                {
                    hintManager.TriggerHint(1);
                    itemData.hintShown = true;
                }
            }
        }
    }

    private void DropItem()
    {
        if (items.Count > 0)
        {
            InventoryItemData itemData = items[items.Count - 1];
            itemDisplayer.SpawnItem(itemData, transform.position + transform.forward * 2f);
            items.Remove(itemData);
            if (items.Count == 0)
            {
                currentlyHeldItem = null;
            }
            else
            {
                currentlyHeldItem = itemDisplayer.SpawnItemUnderParent(items[0], itemHolder.transform);
            }
        }
    }

    private void SetActiveSlot(int index)
    {
        if (index >= 0 && index + 1 < items.Count && index != activeSlotIndex)
        {
            activeSlotIndex = index;
            currentlyHeldItem = itemDisplayer.SpawnItemUnderParent(items[activeSlotIndex], itemHolder.transform);
        }
    }

    public int GetPartsInInventory()
    {
        int parts = 0;
        foreach (InventoryItemData item in items)
        {
            if (item.itemId == 1)
            {
                parts++;
            }
        }
        return parts;
    }
}
