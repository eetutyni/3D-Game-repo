using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using Unity;
using UnityEngine;

public class CamItemChecker : MonoBehaviour
{
    public static CamItemChecker instance;

    private GameObject sigtObj;

    private void Awake()
    {
        if (instance != null) return;
        instance = this;
    }

    public GameObject GetItemInView()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
            return hit.collider.gameObject;
        return null;
    }
}
