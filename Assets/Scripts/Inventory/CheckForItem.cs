using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForItem : MonoBehaviour
{
    public bool canCollect = false;
    public GameObject hitobj;

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 3f))
            hitobj = hit.collider.gameObject;
        else hitobj = null;

        if (hitobj != null && hitobj.layer == 8) canCollect = true;
        else canCollect = false;
    }
}
