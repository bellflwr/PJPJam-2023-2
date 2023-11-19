using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public EnemyData enemyData;
    public Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = enemyData.speed;
        agent.destination = target.position;
    }

    void Update()
    {
        if (enemyData.ranged)
        {
            if(Vector3.Distance(transform.position, target.position) <= enemyData.range)
            {
                agent.destination = transform.position;
            }
            else
            {
                agent.destination = target.position;
            }
        }
    }
}
