using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintPanel : MonoBehaviour
{
    [SerializeField] private HintManager hintManagerScript;

    public GameObject activeHint;
    public bool panelActive;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();

        panelActive = false;
    }

    public void InitializeHint(GameObject hint)
    {
        hint.SetActive(true);
    }

    public void SetPanelActive(bool active)
    {
        if (active) anim.Play("MoveIn");
        if (!active) anim.Play("MoveOut");

        panelActive = active;
    }

    public void DisableHintText()
    {
        activeHint.SetActive(false);

        hintManagerScript.hintActive = false;
    }
}
