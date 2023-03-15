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

    public GameObject activeHint;
    public bool hintActive;

    [SerializeField] private float objActivateTimerMax;
    private float objActivateTimer;

    [SerializeField] private float hintTimerMax; 
    private float hintTimer;

    private void Start()
    {
        objActivateTimer = 0;
        if (hints[0] != null) TriggerHint(hints[0]);
    }

    private void Update()
    {
        // Toggle objectives panel when objectives key is pressed and timer is done
        if (Input.GetKeyDown(KeyCode.N) && objActivateTimer <= 0)
        {
            objsPanelScript.SetPanelActive(!objsPanelScript.panelActive);
            objActivateTimer = objActivateTimerMax;

            if (activeHint = hints[0]) SkipHint();
        }
        else objActivateTimer -= Time.deltaTime;

        // Hint show timer logic
        if (hintActive && hintTimer <= 0)
        {
            hintPanelScript.SetPanelActive(false);
            hintActive = false;
        }
        else hintTimer -= Time.deltaTime;
    }

    public void SkipHint()
    {
        if (hintTimer > 1) hintTimer = 1;
    }

    private void TriggerHint(GameObject hint)
    {
        hintPanelScript.InitializeHint(hint);
        hintPanelScript.SetPanelActive(true);

        hintTimer = hintTimerMax;
        activeHint = hint;
        hintActive = true;
    }
}
