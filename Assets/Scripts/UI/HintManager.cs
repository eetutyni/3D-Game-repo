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

    [SerializeField] private float objActivateTimerMax;
    private float objActivateTimer;

    [SerializeField] private float hintTimerMax; 
    private float hintTimer;

    private void Start()
    {
        objActivateTimer = 0;
        TriggerHint(hints[0]);
    }

    private void Update()
    {
        // Toggle objectives panel when N key is pressed and timer is done
        if (Input.GetKeyDown(InputManager.IM.interact) && objActivateTimer <= 0)
        {
            objsPanelScript.SetPanelActive(!objsPanelScript.panelActive);
            objActivateTimer = objActivateTimerMax;
        }
        else objActivateTimer -= Time.deltaTime;

        if (hintActive)
        {
            if (hintTimer <= 0)
            {
                hintPanelScript.SetPanelActive(false);
                hintActive = false;
            }
            else hintTimer -= Time.deltaTime;

            if (Input.GetKeyDown(InputManager.IM.interact) && hintTimer > 1) hintTimer = 1;
        }
    }

    private void TriggerHint(GameObject hint)
    {
        hintPanelScript.InitializeHint(hint);
        hintPanelScript.SetPanelActive(true);

        hintTimer = hintTimerMax;
        hintActive = true;
    }
}
