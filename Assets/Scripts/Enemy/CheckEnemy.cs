using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{
    public float radius = 80f; // Radius of the sphere to check for enemies
    public LayerMask enemyLayerMask; // Layer mask to identify enemy objects // time it takes for the door to open
    [SerializeField] private OpenDoor doorscript;

    void Update()
    {
        // Check for enemy objects within the sphere
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, enemyLayerMask);

        // If no enemy objects are detected and the door isn't already open
        if (hits.Length == 0 && !doorscript.doorOpen)
        {
            // Open the door
            doorscript.UnlockDoor();
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw sphere gizmo in editor for visualization
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
