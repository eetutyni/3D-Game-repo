using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryDisplay : MonoBehaviour
{
    public int activeSlot = 1;

    [SerializeField] private Sprite axeImg;
    [SerializeField] private Sprite woodImg;

    [SerializeField] private InventoryManager invManagerScript;
    [SerializeField] private Image invSlotIcon1;
    [SerializeField] private Image invSlotIcon2;
    [SerializeField] private Image invSlotIcon3;

    public void UpdateHudInventory()
    {
        for (int i = 1; i < invManagerScript.items.Count; i++)
        {
            if (i == 1) DisplaySlot(invSlotIcon1, invManagerScript.items[i]);
            if (i == 2) DisplaySlot(invSlotIcon2, invManagerScript.items[i]);
            if (i == 3) DisplaySlot(invSlotIcon3, invManagerScript.items[i]);
        }
    }
    
    private void DisplaySlot(Image iconSlot, InventoryItemData item)
    {
        iconSlot.sprite = item.icon;
    }
}
