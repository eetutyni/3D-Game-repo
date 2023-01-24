using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animation : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] CharacterController playerController;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetAxis("Horizontal") > 0 || Input.GetAxis("Vertical") > 0)
        {
            
        }
    }
}
