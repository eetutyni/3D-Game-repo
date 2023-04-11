using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HintManager : MonoBehaviour
{
    public List<GameObject> hints;
    private int activeHintIndex = -1;

    [SerializeField] private Animator anim;
    [SerializeField] private float hintTimerMax = 5f;
    private float hintTimer;

    private void Start()
    {
        TriggerHint(0);
    }

    private void FixedUpdate()
    {
        if (activeHintIndex != -1 && hintTimer <= 0)
        {
            DisableHint();
        }
        else hintTimer += Time.fixedDeltaTime;
    }

    public void TriggerHint(int index)
    {
        if (index > hints.Count - 1) return;
        if (activeHintIndex != -1) hints[index].SetActive(true);
        activeHintIndex = index;
        anim.Play("MoveIn");
        hintTimer = hintTimerMax;
    }

    public void DisableHint()
    {
        if (hints[activeHintIndex] != null) hints[activeHintIndex].SetActive(false);
        activeHintIndex = -1;
    }
}
