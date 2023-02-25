using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEditor.Experimental.GraphView;

public class EnemyStateControl : MonoBehaviour
{
    [Header("Reference scripts")]
    [SerializeField] private PlayerHealth playerHealthScript;

    [Header("Enemy state activation ranges")]
    [Range(50f, 65f)] public float roamRange;
    [Range(25f, 40f)] public float sightRange;
    public float attackRange;

    [Header("Enemy attributes")]
    // Enemy attack rate
    [Range(1f, 10f)] public float attackSpeed;
    // How much damage does one hit deal to the player
    [SerializeField] public int enemyDamage;

    // The wait time between attacks - attackSpeed multiplied by 10 inverse
    public float attackWaitTime;

    // The player gameObject
    [SerializeField] private GameObject player;
    // The NavMeshAgent component
    private NavMeshAgent agent;
    // The animator component
    [SerializeField] private Animator anim;
    // Is the player in the roamRange radius from the enemy
    public bool playerInRoamRange;

    public Vector3 lastKnownPlayerPos;
    public float distToPlayer;
    public bool seesPlayer;
    public Vector3 roamPos;

    private bool runState;
    private float runTimer;
    private float speed;
    [SerializeField] private float runMod;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        attackWaitTime = 1 / (attackSpeed / 10);
        runTimer = 0;
        speed = agent.speed;
    }

    void OnDrawGizmosSelected()
    {
        //Visualize state activation ranges in editor
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0f, 1f, 0f), roamRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + new Vector3(0f, 1f, 0f), sightRange);
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
        if (lastKnownPlayerPos == null) lastKnownPlayerPos = player.transform.position;

        // If the enemy sees the player the speed is set to the runmodifier and else it is normal speed
        if (runTimer > 4f) runState = false;
        if (runState) agent.speed = speed * runMod; else agent.speed = speed;

        // Calculate the distance to the player
        distToPlayer = Vector3.Distance(transform.position, player.transform.position);
        playerInRoamRange = distToPlayer < roamRange;

        agent.isStopped = false;
        // Check which state the enemy should be in based on the distance to the player
        if (distToPlayer < attackRange) AttackPlayer();
        else if (distToPlayer < sightRange) PlayerInSightRange();
        else Roam();
    }

    // Called when the player is outside of the sight range
    private void Roam()
    {
        if (playerInRoamRange && Vector3.Distance(transform.position, lastKnownPlayerPos) < 10f)
        {
            Debug.Log("lastposinrange");
            lastKnownPlayerPos = new Vector3(player.transform.position.x + Random.Range(-40f, 40f), player.transform.position.y, player.transform.position.z + Random.Range(-40f, 40f));
            agent.SetDestination(lastKnownPlayerPos);
        }

        runTimer += Time.deltaTime;
    }

    // Called when the player is in the sightRange
    private void PlayerInSightRange()
    {
        // Set the destination of the NavMeshAgent to the player's current position
        agent.SetDestination(player.transform.position);

        runState = true;
        runTimer = 0;

        // Update the last known position of the player to the player's current position
        lastKnownPlayerPos = player.transform.position;
    }

    // Called when the player is in the attackRange
    private void AttackPlayer()
    {
        // Stop enemy
        agent.ResetPath();

        // Set attack animation trigger
        anim.SetTrigger("attack");
        anim.ResetTrigger("attack");

        playerHealthScript.TakeDamage(enemyDamage);
        // Wait between attacks
        AttackWait();
    }

    private IEnumerator AttackWait()
    {
        yield return new WaitForSeconds(attackWaitTime);
    }
}
