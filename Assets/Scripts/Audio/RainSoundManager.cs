using UnityEngine;

public class RainSoundManager : MonoBehaviour
{
    [Header("Shelter check references")]
    [SerializeField] private Transform playerTransform;
    [SerializeField] private LayerMask shelterLayer;

    [SerializeField] private AudioLowPassFilter lowPassFilter;

    private void FixedUpdate()
    {
        if (ShelterCheck()) lowPassFilter.cutoffFrequency = 8000;
        else lowPassFilter.cutoffFrequency = 22000;
    }

    private bool ShelterCheck()
    {
        return Physics.Raycast(playerTransform.position, playerTransform.up, 4f, shelterLayer);
    }
}
