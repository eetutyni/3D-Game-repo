using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Animations;

public class Enemy : MonoBehaviour
{

    [SerializeField] Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            anim.SetTrigger("AngryTrigger");
        }

    }
}
