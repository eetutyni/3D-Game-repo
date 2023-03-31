using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperDisplayScript : MonoBehaviour
{
    [SerializeField] private GameObject paper;
    [SerializeField] private GameObject showText;

    private bool isPanelActive;
    private bool paperInView;

    private void FixedUpdate()
    {
        GameObject hitObj = CamItemChecker.instance.GetItemInView();
        if (hitObj != null && hitObj.tag == "paper")
        {
            if (Input.GetKeyDown(KeyCode.E)) SetPaperActive(isPanelActive);

            if (!isPanelActive) showText.SetActive(true);
            else showText.SetActive(false);
        }
        else
        {
            if (isPanelActive) SetPaperActive(false);
            showText.SetActive(false);
        }
    }

    private void SetPaperActive(bool active)
    {
        paper.SetActive(active);
        isPanelActive = active;
    }
}
