using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    [Header("List of the hint texts")]
    public List<Hint> hints;

    public GameObject activeHint;
    public bool hintActive;

    [SerializeField] private float hintTimerMax; 
    private float hintTimer;

    private void Start()
    {
        TriggerHint(hints[0]);
    }

    public void SkipHint()
    {
        if (hintTimer > 1) hintTimer = 1;
    }

    private void TriggerHint(Hint hint)
    {
        if (hint != null) hintTimer = hintTimerMax;
    }
}
