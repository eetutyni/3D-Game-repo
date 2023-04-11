using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperDisplayScript : MonoBehaviour
{
    [SerializeField] private GameObject textPanel;

    private bool isPanelActive;

    private void FixedUpdate()
    {
        GameObject hitObj = CamItemChecker.instance.GetItemInView();
        if (hitObj != null && hitObj == gameObject)
        {
            InteractLabelManager.showLabel.SetActive(true);

            if (Input.GetKeyDown(KeyCode.E)) SetPaperActive(!isPanelActive);
        }
        else
        {
            InteractLabelManager.showLabel.SetActive(false);

            if (isPanelActive) SetPaperActive(false);
        }
    }

    private void SetPaperActive(bool active)
    {
        textPanel.SetActive(active);
        isPanelActive = active;
    }
}
