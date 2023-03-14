using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjsPanel : MonoBehaviour
{
    public bool panelActive;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        panelActive = false;
    }

    public void SetPanelActive(bool active)
    {
        if (active) anim.Play("MoveIn");
        if (!active) anim.Play("MoveOut");

        panelActive = active;
    }
}
