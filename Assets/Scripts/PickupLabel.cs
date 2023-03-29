using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupLabel : MonoBehaviour
{
    [SerializeField] private GameObject label;

    public void ShowLabel()
    {
        label.SetActive(true);
    }

    public void HideLabel()
    {
        label.SetActive(false);
    }
}
