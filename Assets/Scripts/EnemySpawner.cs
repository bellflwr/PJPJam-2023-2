using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefab;
    public float minSpawnRadius;
    public float maxSpawnRadius;
    public Wave wave;
    public int waveNumber;
    [SerializeField] int maxEnemies;
    public int enemiesLeft;
    public float spawnInterval;
    public float maxSpawnInterval;
    public Text nextWaveText;

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
        maxEnemies = wave.totalEnemies;
    }

    bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + UnityEngine.Random.insideUnitSphere * range;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomPoint, out hit, 1.0f, NavMesh.AllAreas))
            {
                result = hit.position;
                return true;
            }
        }
        result = Vector3.zero;
        return false;
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

        
        float yPosition = Terrain.activeTerrain.SampleHeight(new Vector3(transform.position.x + randomX, 0, transform.position.z + randomZ)) + 5;

        Vector3 randomPosition = new Vector3(transform.position.x + randomX, yPosition, transform.position.x + randomZ);
        GameObject enemy = Instantiate(enemyPrefab[UnityEngine.Random.Range(0, enemyPrefab.Length)], randomPosition, Quaternion.identity);
        print("test");
        enemy.GetComponent<EnemyMovement>().target = gameObject.transform;
        
        
        Vector3 point;
        if(RandomPoint(enemy.transform.position, 20, out point))
        {
            enemy.transform.position = point;
        }
    }

    void Update()
    {
     nextWaveText.text = "Wave " + waveNumber;   
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
