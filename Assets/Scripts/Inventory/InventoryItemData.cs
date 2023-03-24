using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Item/Create InventoryItem")]
public class InventoryItemData : ScriptableObject
{
    public GameObject prefab;
    public Vector3 spawnPos;
    public Quaternion rotation;
}
