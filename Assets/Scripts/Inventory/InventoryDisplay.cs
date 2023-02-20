using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private InventoryManager invManagerScript;
    [SerializeField] private GameObject invSlot1;
    [SerializeField] private GameObject invSlot2;
    [SerializeField] private GameObject invSlot3;

    public void UpdateHudInventory()
    {
        for (int i = 0; i < invManagerScript.items.Count; i++)
        {
            if (i == 1) ;
        }
    }
}
