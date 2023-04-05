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

    private void Update()
    {
        sigtObj = GetItemInView();

        if (sigtObj != null)
        {
            if (sigtObj.tag == "doors") InteractLabel.instance.SetLabel("open");
            else if (sigtObj.tag == "Pickup") InteractLabel.instance.SetLabel("pickup");
            else if (sigtObj.tag == "paper") InteractLabel.instance.SetLabel("show");
            else if (sigtObj.tag == "workbench") InteractLabel.instance.SetLabel("build");
            else InteractLabel.instance.HideLabel();
        }
        else InteractLabel.instance.HideLabel();
    }

    public GameObject GetItemInView()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
            return hit.collider.gameObject;
        return null;
    }
}
