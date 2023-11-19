using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public float minSpawnRadius;
    public float maxSpawnRadius;
    public Wave wave;
    public int waveNumber;
    int maxEnemies;
    public int enemiesLeft;
    public float spawnInterval;
    public float maxSpawnInterval;

    public void Awake()
    {
        wave = Resources.Load<Wave>("Waves/1");
        waveNumber = 1;
        maxEnemies = wave.totalEnemies;
        enemiesLeft = wave.totalEnemies;
    }

    public void nextWave()
    {
        waveNumber++;
        wave = Resources.Load<Wave>("Waves/" + waveNumber);
        enemiesLeft = wave.totalEnemies;
    }

    public void spawnEnemy()
    {
        float randomX = UnityEngine.Random.Range(-maxSpawnRadius, maxSpawnRadius);
        float randomZ = UnityEngine.Random.Range(-maxSpawnRadius, maxSpawnRadius);

        while (randomX < minSpawnRadius && randomX > -minSpawnRadius)
        {
            randomX = UnityEngine.Random.Range(-maxSpawnRadius, maxSpawnRadius);
        }
        while (randomZ < minSpawnRadius && randomZ > -minSpawnRadius)
        {
            randomZ = UnityEngine.Random.Range(-maxSpawnRadius, maxSpawnRadius);
        }

        
        float yPosition = Terrain.activeTerrain.SampleHeight(new Vector3(transform.position.x + randomX, 0, transform.position.z + randomZ)) + 10;

        Vector3 randomPosition = new Vector3(transform.position.x + randomX, yPosition, transform.position.x + randomZ);
        GameObject enemy = Instantiate(enemyPrefab[UnityEngine.Random.Range(0, enemyPrefab.Length - 1)], randomPosition, Quaternion.identity);
    }

    void Update()
    {
        if (enemiesLeft > 0)
        {
            if(maxEnemies > 0)
            {
                if (spawnInterval <= 0)
                {
                    maxEnemies--;
                    spawnEnemy();
                    spawnInterval = maxSpawnInterval;
                }
                else
                {
                    spawnInterval -= Time.deltaTime;
                }
            }
            
        }
        else
        {
            nextWave();
        }
    }
}
