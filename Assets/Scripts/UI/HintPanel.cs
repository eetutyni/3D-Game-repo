using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintPanel : MonoBehaviour
{
    [SerializeField] private HintManager hintManagerScript;

    public GameObject activeHint;

    private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void ActivateHint(GameObject hint)
    {
        hint.SetActive(true);
        activeHint = hint;
        anim.Play("MoveIn");
    }

    public void DeactivateHint()
    {
        anim.Play("MoveOut");
    }

    public void DisableHintText()
    {
        activeHint.SetActive(false);
    }
}
