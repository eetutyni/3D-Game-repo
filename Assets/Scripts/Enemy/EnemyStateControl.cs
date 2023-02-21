using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEditor.TerrainTools;
using UnityEngine;
using UnityEngine.Animations;

public class EnemyStateControl : MonoBehaviour
{
    [SerializeField] Monument mon;
    [SerializeField] private GameObject player;

    [SerializeField] Animator anim;


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

        if (Physics.CheckSphere(transform.position, mon.MaxRunDistance, player.layer))
        {
            PlayerOnRange();
        }

        if (Vector3.Distance(transform.position, player.transform.position) > mon.MaxRunDistance)
        {
            PlayerNotOnRange();
        }

    }
        public void PlayerOnRange()
        {
            anim.ResetTrigger("NotAngry");
            anim.StopPlayback();
            anim.SetTrigger("AngryTrigger");
            anim.StopPlayback();

            anim.SetTrigger("RunTrigger");
        }

        public void PlayerNotOnRange()
        {
            anim.ResetTrigger("AngryTrigger");
            anim.ResetTrigger("RunTrigger");
            anim.SetTrigger("NotAngry"); 
        }
}
