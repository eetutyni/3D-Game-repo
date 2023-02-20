using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStateControl : MonoBehaviour
{
    [SerializeField] private GameObject player;

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
        
    }
}
