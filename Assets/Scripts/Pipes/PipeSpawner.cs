using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject pipePrefab;

    private float heightOffset = 5;

    [SerializeField] private float spawnDelay = 1;
    private float spawnTimer;

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        GameManager gameManager = GameManager.instance;

        if (gameManager.HasGameStarted())
        {
            if (spawnTimer < 0)
            {
                SpawnPipe();
                spawnTimer = spawnDelay;
            }
        }
    }

    void SpawnPipe()
    {
        float lowestPoint = transform.position.y - heightOffset;
        float highestPoint = transform.position.y + heightOffset;

        Vector3 spawnPosition = new(transform.position.x, Random.Range(lowestPoint, highestPoint), 0);

        Instantiate(pipePrefab, spawnPosition, Quaternion.identity, transform);
    }
}
