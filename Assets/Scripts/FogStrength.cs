using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;

public class FogStrength : MonoBehaviour
{
    [SerializeField] private Transform player;
    private float distance;
    private float calculatedStrength;

    private void FixedUpdate()
    {
        distance = Vector3.Distance(transform.position, player.position);

        if (distance > 350)
        {
            calculatedStrength = (distance - 350) / 350;
            RenderSettings.fogDensity = calculatedStrength;
        }
    }
}
