using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public GameObject enemyPrefab;
    private float minSpawnTime,maxSpawnTime,timeUntilSpawn, currTime;

    void Awake()
    {
        SpawnTimeFunction();
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        timeUntilSpawn -= Time.deltaTime;
        if (timeUntilSpawn <= 0) {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            SpawnTimeFunction();
            SetTimeUntilSpawn();
        }
    }

    private void SetTimeUntilSpawn() {timeUntilSpawn = Random.Range(minSpawnTime, maxSpawnTime);} 
    private void SpawnTimeFunction() {
        currTime = Time.time/60f;
        minSpawnTime = (float) (Mathf.Pow(1.5f, (currTime-2.25f)*-1));
        maxSpawnTime = (float) (Mathf.Pow(1.5f, (currTime-2.25f)*-1) + 0.5f);

    }

}
