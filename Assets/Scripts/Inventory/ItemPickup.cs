using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public InventoryItemData item;

    [SerializeField] CheckForItem playerItemCheckScript;
    private LayerMask inventoryCollectibleLayer;

    private void Start()
    {
        inventoryCollectibleLayer = gameObject.layer;
    }

    void Pickup()
    {
        InventoryManager.Instance.AddItem(item);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerItemCheckScript.canCollect)
        {
            Pickup();
        }
    }
}
