using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance : MonoBehaviour
{
    [SerializeField] private EnemyData enemyData;
    public float health;

    public void Awake()
    {
        health = enemyData.maxHealth;
    }
}
