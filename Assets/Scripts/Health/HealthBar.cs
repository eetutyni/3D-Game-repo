using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthbar;

    public void UpdateHealth(float fraction)
    {
        healthbar.value = fraction;
    }
}
