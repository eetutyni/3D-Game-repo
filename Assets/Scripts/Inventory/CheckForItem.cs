using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForItem : MonoBehaviour
{
    public bool ItemCheck(LayerMask layer)
    {
        Debug.Log("Check succesful");
        return Physics.Raycast(transform.position, new Vector3(0, 0, 1), 3f, layer);
    }
}
