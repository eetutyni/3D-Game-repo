using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractLabelManager : MonoBehaviour
{
    [SerializeField] private InteractLabel pickupLbl;
    [SerializeField] private InteractLabel showLbl;
    [SerializeField] private InteractLabel buildLbl;
    [SerializeField] private InteractLabel openLbl;

    public static InteractLabel pickupLabel;
    public static InteractLabel showLabel;
    public static InteractLabel buildLabel;
    public static InteractLabel openLabel;

    private void Start()
    {
        pickupLabel = pickupLbl;
        showLabel = showLbl;
        buildLabel = buildLbl;
        openLabel = openLbl;
    }
}
