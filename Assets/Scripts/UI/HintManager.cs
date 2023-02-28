using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    [SerializeField] private HintPanel hintPanelScript;

    public List<Hint> hints;

    private void Start()
    {
        ActivateHint(0);
    }

    private void ActivateHint(int index)
    {
        if (index + 1 <= hints.Count) hintPanelScript.InitializeHint(hints[index]);
    }
}
