using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperDisplayScript : MonoBehaviour
{
    [SerializeField] private InteractLabel labelScript;
    [SerializeField] private GameObject paper;

    private bool isPanelActive;

    private void FixedUpdate()
    {
        GameObject hitObj = CamItemChecker.instance.GetItemInView();
        if (hitObj != null && hitObj.tag == "paper")
        {
            if (Input.GetKeyDown(KeyCode.E)) SetPaperActive(isPanelActive);
            labelScript.seesShowable = true;
        }
        else
        {
            if (isPanelActive) SetPaperActive(false);
            labelScript.seesShowable = false;
        }
    }

    private void SetPaperActive(bool active)
    {
        paper.SetActive(active);
        isPanelActive = active;
    }
}
