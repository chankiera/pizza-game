using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;

    public float spawnInterval = 5f;

    void Start()
    {
        InvokeRepeating(
            nameof(SpawnEnemy),
            2f,
            spawnInterval
        );
    }

    void SpawnEnemy()
    {
        Instantiate(
            enemyPrefab,
            transform.position,
            Quaternion.identity
        );
    }
}