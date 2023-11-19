using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class Barn : MonoBehaviour
{
    [SerializeField] float startHealth;
    [SerializeField] GameObject loseScreen;
    [SerializeField] ParticleSystem loseParticles;

    public float Health
    {
        get => startHealth;
        set
        {
            startHealth = value;
            CheckAlive();
        }
    }

    public void Awake()
    {
        Health = 1000;
    }

    void CheckAlive()
    {
        if (startHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator Lose(){
        loseParticles.Play();
        yield return new WaitUntil(() => loseParticles.isStopped);
        Destroy(gameObject);
        yield return new WaitForSeconds(1);
        loseScreen.SetActive(true);
    }

    
}
