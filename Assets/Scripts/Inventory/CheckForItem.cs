using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForItem : MonoBehaviour
{
    public bool canCollect = false;

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.layer == 8)
        {
            canCollect = true;
        }
    }

    private void OnTriggerExit(Collider coll)
    {
        if (coll.gameObject.layer == 8)
        {
            canCollect = false;
        }
    }
}
