using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamAnimation : MonoBehaviour
{
    private Animator camAnimator;

    private void Start()
    {
        camAnimator = GetComponent<Animator>();
    }
}
