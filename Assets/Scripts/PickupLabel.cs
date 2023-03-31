using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLabel : MonoBehaviour
{
    public void ShowLabel()
    {
        gameObject.SetActive(true);
    }

    public void HideLabel()
    {
        gameObject.SetActive(false);
    }
}
