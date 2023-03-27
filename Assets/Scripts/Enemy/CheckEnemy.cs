using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnemy : MonoBehaviour
{
    public float radius = 1.0f; // radius of the sphere to check for enemies
    public LayerMask enemyLayerMask; // layer mask to identify enemy objects // time it takes for the door to open
    [SerializeField] private OpenDoor doorscript;

    private bool isDoorOpen = false; // flag to prevent multiple door openings

    void Update()
    {
        // check for enemy objects within the sphere
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, enemyLayerMask);

        // if no enemy objects are detected and the door isn't already open
        if (hits.Length == 0 && !isDoorOpen)
        {
            isDoorOpen = true;

            // open the door
            doorscript.canOpen = true;
        }
    }

    void OnDrawGizmosSelected()
    {
        // draw sphere gizmo in editor for visualization
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
