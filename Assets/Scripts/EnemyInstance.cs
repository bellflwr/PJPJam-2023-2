using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyInstance
{
    [SerializeField] private EnemyData enemyData;
    public float health;

    public static EnemyInstance Create(EnemyData data)
    {
        EnemyInstance ei = new EnemyInstance();
        ei.enemyData = data;
        ei.health = data.maxHealth;
        return ei;
    }
}
