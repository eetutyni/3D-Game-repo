using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuildRaft : MonoBehaviour
{
    public bool canBuild = false;
    [SerializeField] private GameObject hitobj;
    public GameObject raft;


    [SerializeField] private GameObject buildText;

    private void Start()
    {
        buildText.SetActive(false);
    }
    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 3f))
        {
            hitobj = hit.collider.gameObject;
        }


        if (hitobj.tag == "workbench")
        {
            buildText.SetActive(true);
            canBuild = true;
        }
        else canBuild = false;

        if (Input.GetKeyDown(KeyCode.E) && canBuild)
        { 
            raft.SetActive(true);
        }
    }
}
