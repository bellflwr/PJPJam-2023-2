using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    private EnemySpawner enemySpawner;
    private float _health;

    public float Health
    {
        get => _health;
        set
        {
            _health = value;
            CheckAlive();
        }
    }

    public void Awake()
    {
        Health = enemyData.maxHealth;
        enemySpawner = GameObject.Find("Barn").GetComponent<EnemySpawner>();
    }

    void CheckAlive()
    {
        if (_health <= 0)
        {
            enemySpawner.enemiesLeft--;
            Destroy(gameObject);
        }
    }
}