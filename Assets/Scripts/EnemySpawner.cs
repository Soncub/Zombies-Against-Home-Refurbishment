using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public float outerSize = 38f;
    public float innerSize = 35f;
    public float spawnRate = 1f;
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
            float x = Random.Range(-outerSize, outerSize);
            float z = Random.Range(-outerSize, outerSize);
            spawnPos = new Vector3(x, 0f, z);
        }
        while (Mathf.Abs(spawnPos.x) < innerSize && Mathf.Abs(spawnPos.z) < innerSize);

        return spawnPos;
    }
}