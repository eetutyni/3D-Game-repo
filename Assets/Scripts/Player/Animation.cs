using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Movement mov;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
       
        if(Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            animator.Play("attack");
        }
        
    }
}



