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

    public void SetPanelActive(bool active)
    {
        if (active) anim.Play("MoveIn");
        else anim.Play("MoveOut");

        panelActive = active;
    }
}
