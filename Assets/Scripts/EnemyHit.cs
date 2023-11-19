using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    private EnemyMovement enemyMovement;
    private EnemyInstance enemyInstance;
    [SerializeField] private Barn barn;
    [SerializeField] private float hitrate;

    void Awake(){
        enemyMovement = gameObject.GetComponent<EnemyMovement>();
        enemyInstance = gameObject.GetComponent<EnemyInstance>();
        barn = GameObject.Find("Game Manager").GetComponent<Barn>();
    }

    void Update(){
        if(enemyMovement.doneMoving){
            if(hitrate >= enemyMovement.enemyData.hitrate){
                barn.health -= enemyMovement.enemyData.damage;
                hitrate = 0;
            } else {
                hitrate += Time.deltaTime;
            }
        }
    }
}

