using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.iOS;

public class InfoPanel : MonoBehaviour
{
    [SerializeField] private GameObject objectivePanel;
    [SerializeField] private GameObject infoPanel;

    private Animator objAnim;
    private Animator infoAnim;

    private float infoTimer;
    private float infoTimerMax;

    void Start()
    {
        objAnim = objectivePanel.GetComponent<Animator>();
        infoAnim = infoPanel.GetComponent<Animator>();
    }

    void Update()
    {
        
    }

    private void ActivateObjsPanel(bool active)
    {
        if (active) { objAnim.Play("MoveIn"); return; }

        objAnim.Play("MoveOut");
    }

    private void ActivateInfoPanel(bool active)
    {
        if (active) { infoAnim.Play("MoveIn"); return; }

        infoAnim.Play("MoveOut");
    }

    void InitHint(Hint hint)
    {
        
    }
}
