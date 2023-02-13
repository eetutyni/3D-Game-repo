using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForItem : MonoBehaviour
{
    public bool canCollect = false;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Pickup"))
        {
            canCollect = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.CompareTag("Pickup"))
        {
            canCollect = false;
        }
    }
}
