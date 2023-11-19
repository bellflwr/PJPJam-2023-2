using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy", order = 1)]
public class EnemyData : ScriptableObject
{
    public float maxHealth;
    public float damage;
    public float hitrate;
    public float speed;
    public bool ranged;
    public float range;
}
