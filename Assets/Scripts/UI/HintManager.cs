using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    [Header("Reference scripts")]
    [SerializeField] private HintPanel hintPanelScript;
    [SerializeField] private ObjsPanel objsPanelScript;

    [Header("List of the hint texts")]
    public List<GameObject> hints = new List<GameObject>();

    public bool hintActive;
    public GameObject activeHint;

    [SerializeField] private float hintTimerMax; 
    private float hintTimer;

    private void Update()
    {
        // Hint show timer logic
        if (hintActive && hintTimer <= 0)
        {
            hintPanelScript.DeactivateHint();
            hintActive = false;
            activeHint = null;
        }
        else hintTimer -= Time.deltaTime;
    }

    public void SkipHint()
    {
        if (hintTimer > 1) hintTimer = 1;
    }

    public void TriggerHint(GameObject hint)
    {
        hintPanelScript.ActivateHint(hint);
        hintActive = true;
        activeHint = hint;
    }
}
