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
        if (hitObj != null && hitObj == paper)
        {
            if (Input.GetKeyDown(KeyCode.E)) SetPaperActive(isPanelActive);

            InteractLabelManager.showLabel.SetActive(true);
        }
        else
        {
            if (isPanelActive) SetPaperActive(false);

            InteractLabelManager.showLabel.SetActive(false);
        }
    }

    private void SetPaperActive(bool active)
    {
        paper.SetActive(active);
        isPanelActive = active;
    }
}
