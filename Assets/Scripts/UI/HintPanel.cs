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
        else SetPanelActive(false);
    }

    public void InitializeHint(Hint hint)
    {
        if (!gameObject.activeInHierarchy) gameObject.SetActive(true);
        hint.gameObject.SetActive(true);
        SetPanelActive(true);
        hintTimer = hint.displayTime;
    }

    public void StopHint(Hint hint)
    {
        hint.hasBeenShown = true;
        SetPanelActive(false);
    }

    public void SetPanelActive(bool active)
    {
        if (active) anim.Play("MoveIn");
        else anim.Play("MoveOut");

        panelActive = active;
    }
}
