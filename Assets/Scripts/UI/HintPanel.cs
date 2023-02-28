using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintPanel : MonoBehaviour
{
    private Animator anim;

    private float hintTimer;

    public bool panelActive;

    void Start()
    {
        anim = GetComponent<Animator>();

        panelActive = false;
    }

    void Update()
    {
        if (hintTimer >= 0) hintTimer += Time.deltaTime;
        else SetPanelActive(!panelActive);
    }

    public void InitializeHint(Hint hint)
    {
        if (!gameObject.activeInHierarchy) gameObject.SetActive(!panelActive);
        hint.gameObject.SetActive(true);
        SetPanelActive(true);
        hintTimer = hint.displayTime;
    }

    private void SetPanelActive(bool active)
    {
        if (active) { anim.Play("MoveIn"); return; }

        anim.Play("MoveOut");

        panelActive = !panelActive;
    }
}

