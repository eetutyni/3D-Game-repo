using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEditor.Experimental.GraphView;
using Unity.VisualScripting;

public class EnemyStateControl : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerHealth playerHealthScript;

    [Header("Enemy state activation ranges")]
    [Range(50f, 65f)] public float roamRange;
    [Range(25f, 40f)] public float sightRange;
    public float attackRange;

    [Header("Reference components")]
    // The NavMeshAgent component
    private NavMeshAgent agent;
    // The animator component
    [SerializeField] private Animator anim;
    // Is the player in the roamRange radius from the enemy
    public bool playerInRoamRange;

    [Header("Enemy attributes")]
    // The run speed modifier
    [SerializeField] private float runMod;
    // THe attack speed modifier
    [SerializeField] private float attackSpeedMod;
    // Enemy attack rate
    [SerializeField] private float attackWaitTime;
    // How much damage does one hit deal to the player
    [SerializeField] private int enemyDamage;

    [Header("Public variables")]
    public Vector3 lastKnownPlayerPos;
    public Vector3 roamPos;
    public float distToPlayer;
    public bool seesPlayer;
    public int enemyHealth = 100;

    private bool runState;
    private float runTimer;
    private float speed;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = gameObject.GetComponent<Animator>();
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

    public void Takedmg(int damage)
    {
        enemyHealth -= damage;
        if (enemyHealth <= 0) 
        {
            Destroy(gameObject);
        }
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

        // Check which state the enemy should be in based on the distance to the player
        if (distToPlayer < attackRange) AttackPlayer();
        else if (distToPlayer < sightRange) PlayerInSightRange();
        else Roam();

        if(enemyHealth <= 0)
        {
            anim.SetTrigger("death");
            //Destroy gameobj
        }
    }

    // Called when the player is outside of the sight range
    void Roam()
    {
        // Set animation vars
        anim.SetBool("inAttackRange", false);
        anim.SetBool("inRunRange", false);
        anim.SetBool("inRoamRange", true);

        if (playerInRoamRange && Vector3.Distance(transform.position, lastKnownPlayerPos) < 10f)
        {
            Debug.Log("lastposinrange");
            lastKnownPlayerPos = new Vector3(player.transform.position.x + Random.Range(-15f, 15f), player.transform.position.y, player.transform.position.z + Random.Range(-40f, 40f));
            agent.SetDestination(lastKnownPlayerPos);
        }

        runTimer += Time.deltaTime;
    }

    // Called when the player is in the sightRange
    void PlayerInSightRange()
    {
        // Set animation vars
        anim.SetBool("inAttackRange", false);
        anim.SetBool("inRunRange", true);
        anim.SetBool("inRoamRange", false);

        // Update the last known position of the player to the player's current position
        lastKnownPlayerPos = player.transform.position;

        // Set the destination of the NavMeshAgent to the player's current position
        agent.SetDestination(player.transform.position);

        runState = true;
        runTimer = 0;
    }

    // Called when the player is in the attackRange
    private void AttackPlayer()
    {
        // Slow enemy down while attacking
        agent.speed = speed * attackSpeedMod;
        agent.SetDestination(player.transform.position);
        
        // Set animation vars
        anim.SetBool("inAttackRange", true);
        anim.SetBool("inRunRange", false);
        anim.SetBool("inRoamRange", false);

        // Update the last known position of the player to the player's current position
        lastKnownPlayerPos = player.transform.position;
    }

    public void HitPlayer()
    {
        if(distToPlayer < attackRange + 1f)
        {
            playerHealthScript.TakeDamage(15);
        }
    }
}
