using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class EnemyStateControl : MonoBehaviour
{
    [Header("Enemy state activation ranges")]
    [Range(15f, 20f)] public float sightRange = 10f;
    [Range(5f, 12f)] public float runRange = 10f;
    public float attackRange = 2f;

    [Header("Enemy attributes")]
    [Range(1f, 10f)] private float attackSpeed;

    //The player gameObject
    [SerializeField] private GameObject player;
    //The NavMeshAgent component
    private NavMeshAgent agent;
    //The animator component
    private Animator anim;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        attackSpeed = 10 / attackSpeed;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0f, 1f, 0f), sightRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0f, 1f, 0f), runRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0f, 1f, 0f), attackRange);
    }

    private void FixedUpdate()
    {
        if (Physics.CheckSphere(transform.position + new Vector3(0f, 1f, 0f), sightRange)) PlayerInSightRange();
        if (Physics.CheckSphere(transform.position + new Vector3(0f, 1f, 0f), runRange)) PlayerInRunRange();
        if (Physics.CheckSphere(transform.position + new Vector3(0f, 1f, 0f), attackRange)) AttackPlayer();
    }

    private void PlayerInSightRange()
    {
        agent.SetDestination(player.transform.position);
    }

    private void PlayerInRunRange()
    {
        agent.SetDestination(player.transform.position);
    }

    private void AttackPlayer()
    {
        agent.ResetPath();
        anim.SetTrigger("attack");

        AttackWait();
    }

    private IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(attackSpeed);

        anim.ResetTrigger("attack");
    }
}
