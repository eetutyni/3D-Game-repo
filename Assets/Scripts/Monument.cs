using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monument : MonoBehaviour
{

    [SerializeField]EnemyStateControl enemy;
    [Range(0f, 100f)] public float MaxRunDistance;

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, MaxRunDistance);
        Gizmos.color = Color.red;  
    }
    
}