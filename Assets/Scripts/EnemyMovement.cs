using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public EnemyData enemyData;
    public Transform target;
    private NavMeshAgent agent;
    public bool isGrounded = false;
    public float timeForGrounded = 0;
    [SerializeField] private bool barnTouched;

    void Start()
    {
        barnTouched = false;
        agent = GetComponent<NavMeshAgent>();
        agent.speed = enemyData.speed;
        Rigidbody rb = GetComponent<Rigidbody>();

        rb.velocity = new Vector3(rb.velocity.x, -1, rb.velocity.z);
    }

     

    void Update()
    {
        if(target == null)
        {
            agent.destination = transform.position;
        }

        if(isGrounded && !barnTouched && target != null)
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

        if(transform.position.y < -10)
        {
            Destroy(gameObject);
        }
        
        
        if (timeForGrounded > 1)
        {
            isGrounded = true;
        }

        if(gameObject.GetComponent<Rigidbody>().velocity.y <= 2 && gameObject.GetComponent<Rigidbody>().velocity.y >= -2)
        {
            timeForGrounded += Time.deltaTime;
        } else if(!isGrounded){
            timeForGrounded = 0;
        }
        Debug.Log(GetComponent<Rigidbody>().velocity.y);
    }

    void OnCollisionStay(Collision other)
    {
        if(other.gameObject.tag == "Barn")
        {
            agent.destination = transform.position;
        }
    }
}
