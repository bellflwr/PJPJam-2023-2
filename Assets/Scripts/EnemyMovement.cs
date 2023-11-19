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
        

        // if the player has been on the ground for more than 1 second, then they are grounded
        if (timeForGrounded > 1)
        {
            isGrounded = true;
        }

        if(gameObject.GetComponent<Rigidbody>().velocity.y == 0)
        {
            timeForGrounded += Time.deltaTime;
        } else {
            timeForGrounded = 0;
        }
    }
}
