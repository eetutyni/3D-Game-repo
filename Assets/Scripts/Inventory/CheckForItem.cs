using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.UI;

public class CheckForItem : MonoBehaviour
{
    public bool canCollect = false;
    public GameObject hitobj;

    [SerializeField] GameObject storyPanel;

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 3f)) hitobj = hit.collider.gameObject;
        else hitobj = null;

        if (hitobj != null && hitobj.tag == "paper") storyPanel.SetActive(true);
        else if (storyPanel.activeInHierarchy) storyPanel.SetActive(false);
    }
}
