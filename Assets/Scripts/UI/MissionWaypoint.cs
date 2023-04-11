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

    private Vector2 targetPos;

    private float minX;
    private float maxX;

    private float minY;
    private float maxY;

    private void Start()
    {
        color = img.color;
    }

    void Update()
    {
        playerDistance = Vector3.Distance(target.position, player.transform.position);

        if (playerDistance < 25)
        {
            color.a = playerDistance / 25;
            img.color = color;
        }
        else
        {
            color.a = 1;
            img.color = color;
        }

        minX = img.GetPixelAdjustedRect().width / 2;
        maxX = Screen.width - minX;

        minY = img.GetPixelAdjustedRect().height / 2;
        maxY = Screen.height - minY;

        targetPos = mainCam.WorldToScreenPoint(target.position);
        
        targetPos.x = Mathf.Clamp(targetPos.x, minX, maxX);
        targetPos.y = Mathf.Clamp(targetPos.y, minY, maxY);

        img.transform.position = targetPos;
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
