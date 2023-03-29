using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperDisplayScript : MonoBehaviour
{
    [SerializeField] private GameObject paperText;

    private void FixedUpdate()
    {
        if (CamItemChecker.instance.GetItemInView() != null && CamItemChecker.instance.GetItemInView().tag == "paper")
            paperText.SetActive(true);
        else paperText.SetActive(false);
    }
}
