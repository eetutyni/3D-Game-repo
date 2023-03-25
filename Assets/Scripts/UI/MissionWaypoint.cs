using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionWaypoint : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private Transform target;

    void Update()
    {
        if (img.gameObject.activeInHierarchy) img.transform.position = Camera.main.WorldToScreenPoint(target.position);
    }

    public void ShowMarker()
    {
        img.gameObject.SetActive(true);
    }

    public void HideMarker()
    {
        img.gameObject.SetActive(false);
    }
}
