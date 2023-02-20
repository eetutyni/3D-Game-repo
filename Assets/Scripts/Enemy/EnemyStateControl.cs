using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyStateControl : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] Animator anim;

    private void Start()
    {
        seesPlayer = false;
    }

    //Enemy states
    public bool passive;
    public bool searching;
    public bool seesPlayer;
    public bool atttacking;

    //Enemy state activation ranges
    [Range(0f, 15f)] public float sightRange = 10f;
    [Range(0f, 15f)] public float attackRange = 7.5f;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    private void FixedUpdate()
    {
        if (Physics.CheckSphere(transform.position, sightRange, player.layer))
        {
            PlayerOnRange();
        }

        if (Vector3.Distance(transform.position, player.transform.position) > sightRange)
        {
            PlayerNotOnRange();
        }

        void PlayerOnRange()
        {
            anim.ResetTrigger("NotAngry");
            anim.StopPlayback();
            anim.SetTrigger("AngryTrigger");
        }

        void PlayerNotOnRange()
        {
            anim.ResetTrigger("AngryTrigger");
            anim.SetTrigger("NotAngry");   
        }
    }
}
