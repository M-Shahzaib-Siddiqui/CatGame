using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    public float minSpawnTime;
    public float maxSpawnTime;
    private float timeUntilSpawn;

    void Awake()
    {
        SetTimeUntilSpawn();

    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0) {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn() {timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);} 

}
