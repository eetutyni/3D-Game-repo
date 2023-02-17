using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{


    [SerializeField] Collider coll;

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    //when player approaches enemy, "angry" animation activates
    public void OnCollisionEnter(Collision collision)
    {
        if (coll.CompareTag("Player"))
        {
            //nimator.SetTrigger("AngryTrigger");
        }

    }
}
