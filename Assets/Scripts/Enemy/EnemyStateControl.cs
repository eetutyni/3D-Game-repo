using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEditor.Experimental.GraphView;

public class EnemyStateControl : MonoBehaviour
{
    [Header("Enemy state activation ranges")]
    [Range(20f, 30f)] public float roamRange;
    [Range(15f, 20f)] public float sightRange;
    [Range(5f, 12f)] public float runRange;
    public float attackRange = 2f;

    [Header("Enemy attributes")]
    [Range(1f, 10f)] private float attackSpeed;

    // The player gameObject
    [SerializeField] private GameObject player;
    // The NavMeshAgent component
    private NavMeshAgent agent;
    // The animator component
    private Animator anim;
    // The wait time between attacks - inverse of the attackSpeed
    private float attackWaitTime;

    public Vector3 lastKnownPlayerPos;
    public float distToPlayer;
    public bool seesPlayer;
    public Vector3 roamPos;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        attackWaitTime = 1 / attackSpeed;
}

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0f, 1f, 0f), roamRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0f, 1f, 0f), sightRange);
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0f, 1f, 0f), runRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0f, 1f, 0f), attackRange);
    }

    private void OnDrawGizmos()
    {
        // Editor visualization for the last known player position
        Gizmos.color = Color.black;
        Gizmos.DrawSphere(lastKnownPlayerPos, 2f);
    }

    private void FixedUpdate()
    {
        // Calculate the distance to the player
        distToPlayer = Vector3.Distance(transform.position, player.transform.position);

        // Check which state the enemy should be in based on the distance to the player
        if (distToPlayer < attackRange) AttackPlayer();
        else if (distToPlayer < runRange) PlayerInRunRange();
        else if (distToPlayer < sightRange) PlayerInSightRange();
        else Roam(distToPlayer < roamRange);
    }

    // Called when the player is outside of the sight range
    private void Roam(bool inRoamRange)
    {
        if (inRoamRange)
        {
            // If the enemy has reached its current roaming destination, set a new one within sight range of the player
            if (Vector3.Distance(transform.position, roamPos) < sightRange)
            {
                roamPos = player.transform.position + new Vector3(Random.Range(-15f, 15f), 0, Random.Range(-15f, 15f));

                // Update the last known position of the player to the new roaming destination
                lastKnownPlayerPos = roamPos;

                // Set the destination of the NavMeshAgent to the new roaming destination
                agent.SetDestination(roamPos);
            }
        }
        // If the player is outside of the roaming range, move towards the last known position of the player
        else agent.SetDestination(lastKnownPlayerPos);
    }

    // Called when the player is in the sightRange
    private void PlayerInSightRange()
    {
        // Set the destination of the NavMeshAgent to the player's current position
        agent.SetDestination(player.transform.position);

        // Set the walking and running animation bools
        anim.SetBool("walking", true);
        anim.SetBool("running", false);

        // Update the last known position of the player to the player's current position
        lastKnownPlayerPos = player.transform.position;
    }

    // Called when the player is in the runRange
    private void PlayerInRunRange()
    {
        // Set the destination of the NavMeshAgent to the player's current position
        agent.SetDestination(player.transform.position);

        anim.SetBool("running", true);
        anim.SetBool("walking", false);

        // Update the last known position of the player to the player's current position
        lastKnownPlayerPos = player.transform.position;
    }

    // Called when the player is in the attackRange
    private void AttackPlayer()
    {
        // Stop NavMeshAgent from moving
        agent.ResetPath();

        // Set attack animation trigger
        anim.SetTrigger("attack");
        // Reset attack animation trigger
        anim.ResetTrigger("attack");

        // Wait between attacks
        AttackWait();
    }

    private IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(attackWaitTime);
    }
}
