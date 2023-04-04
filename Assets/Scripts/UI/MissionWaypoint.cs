using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MissionWaypoint : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private Transform target;
    [SerializeField] private GameObject player;
    [SerializeField] private Camera mainCam;

    private Color color;
    private float playerDistance;

    private void Start()
    {
        color = img.color;
    }

    void Update()
    {
        playerDistance = Vector3.Distance(target.position, player.transform.position);

        if (playerDistance < 10)
        {
            color.a = playerDistance / 10;
            img.color = color;
        }
        else
        {
            color.a = 1;
            img.color = color;
        }

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
