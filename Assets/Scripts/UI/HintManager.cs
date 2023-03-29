using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintManager : MonoBehaviour
{
    public List<GameObject> hints;
    private int activeHintIndex = -1;

    [SerializeField] private Animator anim;
    [SerializeField] private float hintTimerMax;
    private float hintTimer;

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
        if (hints[index] == null) return;
        if (activeHintIndex != -1) hints[index].SetActive(true);
        anim.Play("MoveIn");
    }

    public void DisableHint()
    {
        if (hints[activeHintIndex] != null) hints[activeHintIndex].SetActive(false);
    }
}
