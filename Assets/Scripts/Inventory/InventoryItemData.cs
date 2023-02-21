using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Item/Create InventoryItem")]
public class InventoryItemData : ScriptableObject
{
    public string itemName;
    public int id;
    public Sprite icon;
    public GameObject prefab;
    public Vector3 spawnPos;
}
