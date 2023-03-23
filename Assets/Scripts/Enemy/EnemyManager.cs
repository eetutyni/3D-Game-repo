using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float villageRange = 20f;
    [SerializeField] private int maxEnemies = 10;
    [SerializeField] private float spawnDelay = 2f;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private Transform[] villagePoints;
    [SerializeField] private Transform[] spawnPoints;

    private int playerInVillageIndex = -1;
    private int currentEnemyCount = 0;
    private float timeSinceLastSpawn = Mathf.Infinity;

    private void Update()
    {
        if (playerTransform == null)
        {
            return;
        }

        // Find the closest village to the player
        float minDistance = Mathf.Infinity;
        int closestVillageIndex = -1;
        for (int i = 0; i < villagePoints.Length; i++)
        {
            float distance = Vector3.Distance(playerTransform.position, villagePoints[i].position);
            if (distance < minDistance)
            {
                minDistance = distance;
                closestVillageIndex = i;
            }
        }

        // Check if player is inside village range
        if (minDistance < villageRange)
        {
            playerInVillageIndex = closestVillageIndex;

            // Spawn enemies
            timeSinceLastSpawn += Time.deltaTime;
            if (timeSinceLastSpawn >= spawnDelay && currentEnemyCount < maxEnemies)
            {
                SpawnEnemy();
                timeSinceLastSpawn = 0f;
            }
        }
        else
        {
            // Roam enemies back to village if they're not already in run range
            if (playerInVillageIndex != -1)
            {
                EnemyStateControl[] enemies = FindObjectsOfType<EnemyStateControl>();
                foreach (EnemyStateControl enemy in enemies)
                {
                    if (!enemy.playerInRoamRange)
                    {
                        enemy.RoamToPos(villagePoints[playerInVillageIndex].position + new Vector3(Random.Range(-10, 10), 0, Random.Range(-10, 10)));
                    }
                }

                playerInVillageIndex = -1;
            }
        }
    }

    private void SpawnEnemy()
    {
        int villageSpawnPointsCount = spawnPoints.Length / villagePoints.Length;
        int randomSpawnPointIndex = Random.Range(playerInVillageIndex * villageSpawnPointsCount,
            (playerInVillageIndex + 1) * villageSpawnPointsCount);

        Transform spawnPoint = spawnPoints[randomSpawnPointIndex];
        GameObject enemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];
        GameObject enemyObject = ObjectPool.Instance.GetObjectFromPool(enemyPrefab);

        enemyObject.transform.position = spawnPoint.position;
        enemyObject.transform.rotation = spawnPoint.rotation;

        Enemy enemyScript = enemyObject.GetComponent<Enemy>();
        if (enemyScript != null)
        {
            enemyScript.SetupAgentFromConfiguration();
        }

        currentEnemyCount++;
    }
}
