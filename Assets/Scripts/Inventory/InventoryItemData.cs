using UnityEngine;

[CreateAssetMenu(fileName = "InventoryItem", menuName = "Item/Create InventoryItem")]
public class InventoryItemData : ScriptableObject
{
    public int itemId = 0;
    public bool hintShown = false;
    public GameObject prefab;
    public Vector3 spawnPos;
    public Quaternion rotation;
}
