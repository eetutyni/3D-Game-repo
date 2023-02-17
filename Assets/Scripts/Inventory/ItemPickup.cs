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
        //Add object to inventorymanager and delete it from the scene
        InventoryManager.Instance.AddItem(item);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        //Check if E is pressed and there is an item in front of the crosshair
        if (Input.GetKeyDown(KeyCode.E) && playerItemCheckScript.canCollect)
        {
            //If the item in front is this gameObject
            if (playerItemCheckScript.hitobj == gameObject) Pickup();
        }
    }
}
