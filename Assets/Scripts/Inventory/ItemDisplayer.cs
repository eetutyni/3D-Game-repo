using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplayer : MonoBehaviour
{
    [SerializeField] private InventoryManager invManagerScript;
    [SerializeField] private Transform holder;
    [SerializeField] private GameObject mainCamera;
    [SerializeField] private float itemThrowForce;

    public void OnSlotChanged(int index)
    {
        //Destroy object in hand before instantiating the changed slot item
        DeleteItem();

        //Instantiate new object in scene
        InstantiateItem(invManagerScript.items[index], 1);
    }

    public void InstantiateItem(InventoryItemData item, int instantiationType)
    {
        switch (instantiationType)
        {
            //Instantiationtype 1 is instantiation as a held item
            case 1:
                Instantiate(item.prefab, holder.position + item.spawnPos, Quaternion.Euler(holder.eulerAngles), holder);
                break;
            
            //Type 2 is as a dropped object
            case 2:
                Instantiate(item.prefab, mainCamera.transform.position, Quaternion.Euler(0f, 0f, 0f));
                break;
        }
    }

    public void DeleteItem()
    {
        //Destroy object in hand before instantiating the changed slot item
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Pickup"))
        {
            //Check if the object is the one the player is holding and destroy it if true
            if (obj.transform.IsChildOf(holder))
            {
                Destroy(obj);
            }
        }
    }

    public void ThrowItem()
    {
        DeleteItem();

        InstantiateItem(invManagerScript.items[invManagerScript.activeSlot], 2);

        GameObject obj = FindObject();
        if (obj != null) obj.GetComponent<Rigidbody>().AddForce(mainCamera.transform.forward * itemThrowForce, ForceMode.Impulse);

        invManagerScript.RemoveItem(invManagerScript.items[invManagerScript.activeSlot]);
    }

    public GameObject FindObject()
    {
        return GameObject.Find(invManagerScript.items[invManagerScript.activeSlot].name);
    }
}
