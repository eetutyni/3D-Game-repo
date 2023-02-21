using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDisplayer : MonoBehaviour
{
    [SerializeField] private InventoryManager invManagerScript;
    [SerializeField] private Transform holder;

    public void OnSlotChanged(int index)
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

        //Instantiate new object in scene
        InstantiateItem(invManagerScript.items[index]);
    }

    public void InstantiateItem(InventoryItemData item)
    {
        Instantiate(item.prefab, holder.position + item.spawnPos, Quaternion.Euler(holder.eulerAngles), holder);
    }

    public void DeleteItem(GameObject obj)
    {
        Destroy(obj);
    }
}
