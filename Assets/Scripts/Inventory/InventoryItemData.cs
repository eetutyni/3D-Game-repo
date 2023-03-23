using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "ScriptableObject/Create InventoryItem")]
public class InventoryItemData : ScriptableObject
{
    public GameObject prefab;
    public Quaternion rotation;
}
