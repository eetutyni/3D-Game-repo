using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperDisplayScript : MonoBehaviour
{
    [SerializeField] private GameObject paper;

    private bool isPanelActive;

    private void FixedUpdate()
    {
        GameObject hitObj = CamItemChecker.instance.GetItemInView();
        if (hitObj != null && hitObj.tag == "paper")
        {
            if (Input.GetKeyDown(KeyCode.E)) SetPaperActive(isPanelActive);

            InteractLabel.instance.SetLabel("show");
        }
        else
        {
            if (isPanelActive) SetPaperActive(false);
            InteractLabel.instance.HideLabel();
        }
    }

    private void SetPaperActive(bool active)
    {
        paper.SetActive(active);
        isPanelActive = active;
    }
}
