using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{
    public GameObject objectToSpawn;          // The GameObject to spawn
    public float minSpawnTime = 25f;          // Minimum time between spawns (seconds)
    public float maxSpawnTime = 40f;          // Maximum time between spawns (seconds)

    private void Start()
    {
        // Start the spawning coroutine
        StartCoroutine(SpawnCoroutine());
    }

    private IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            // Calculate a random spawn interval between minSpawnTime and maxSpawnTime
            float spawnInterval = Random.Range(minSpawnTime, maxSpawnTime);

            // Wait for the calculated interval
            yield return new WaitForSeconds(spawnInterval);

            // Spawn the GameObject
            if (objectToSpawn != null)
            {
                Instantiate(objectToSpawn, transform.position, Quaternion.identity);
            }
        }
    }
}
