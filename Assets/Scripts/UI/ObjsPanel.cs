using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjsPanel : MonoBehaviour
{
    private Animator anim;

    public bool panelActive;

    void Start()
    {
        anim = GetComponent<Animator>();

        panelActive = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.N)) SetPanelActive(!panelActive);
    }

    private void SetPanelActive(bool active)
    {
        if (active) { anim.Play("MoveIn"); return; }

        anim.Play("MoveOut");

        panelActive = !panelActive;
    }
}
