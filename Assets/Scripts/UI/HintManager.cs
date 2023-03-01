using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    [SerializeField] private HintPanel hintPanelScript;
    [SerializeField] private ObjsPanel objsPanelScript;

    public List<Hint> hints;

    // Timer to stop spamming the objective panel from messing up the animation
    [SerializeField] private float objPanelTimerMax;
    private float objPanelTimer;

    private void Start()
    {
        TriggerHint(0);

        objPanelTimer = 0;
    }

    private void Update()
    {
        // Toggle objectives panel when N key is pressed and timer is done
        if (Input.GetKeyDown(KeyCode.N) && objPanelTimer <= 0)
        {
            objsPanelScript.SetPanelActive(!objsPanelScript.panelActive);
            objPanelTimer = objPanelTimerMax;

            if (hints[0].isActive) hintPanelScript.StopHint(hints[0]);
        }
        else objPanelTimer -= Time.deltaTime;
    }

    private void TriggerHint(int index)
    {
        hintPanelScript.InitializeHint(hints[index]);
    }
}
