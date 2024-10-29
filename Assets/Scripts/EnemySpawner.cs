using UnityEngine;

public class SquareDonutSpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign your enemy prefab in the inspector
    public float outerSize = 10f; // Size of the outer square (half-width)
    public float innerSize = 9f;  // Size of the inner square (half-width)
    public float spawnRate = 1f;   // Rate of spawning enemies
    private float nextSpawnTime = 0f;

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + 1f / spawnRate;
        }
    }

    void SpawnEnemy()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPos;

        do
        {
            // Generate a random position within the outer square
            float x = Random.Range(-outerSize, outerSize);
            float z = Random.Range(-outerSize, outerSize);
            spawnPos = new Vector3(x, 0f, z); // Set Y to 0 for flat plane
        }
        while (Mathf.Abs(spawnPos.x) < innerSize && Mathf.Abs(spawnPos.z) < innerSize); // Check if within inner square

        return spawnPos;
    }
}
