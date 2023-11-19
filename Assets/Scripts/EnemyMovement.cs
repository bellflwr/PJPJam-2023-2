using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public EnemyData enemyData;
    public Transform target;
    private NavMeshAgent agent;
    private bool isGrounded = false;
    public float timeForGrounded = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = enemyData.speed;
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(rb.velocity.x, -1, rb.velocity.z);
    }

     bool RandomPoint(Vector3 center, float range, out Vector3 result)
    {
        for (int i = 0; i < 30; i++)
        {
            Vector3 randomPoint = center + Random.insideUnitSphere * range;
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

    void Update()
    {
        if(isGrounded)
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
            else
            {
                agent.destination = target.position;
            }
        }
        
        Vector3 point;
        if(RandomPoint(transform.position, 10, out point))
        {
            transform.position = point;
            isGrounded = true;
        }
        // if the player has been on the ground for more than 1 second, then they are grounded
        // if (timeForGrounded > 1)
        // {
            
        // }

        // if(gameObject.GetComponent<Rigidbody>().velocity.y == 0)
        // {
        //     timeForGrounded += Time.deltaTime;
        // } else {
        //     timeForGrounded = 0;
        // }
    }
}
