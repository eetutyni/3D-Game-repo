using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionWaypoint : MonoBehaviour
{
    [SerializeField] private GameObject img;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject player;
    [SerializeField] private Camera mainCam;

    private float playerDistance;

    void Update()
    {
        if (gameObject.activeInHierarchy) img.transform.position = mainCam.WorldToScreenPoint(target.position);
    }

    public void SetMarker(Transform markerTarget)
    {
        target = markerTarget;
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
