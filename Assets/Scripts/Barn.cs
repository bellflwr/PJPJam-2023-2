using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        yield return new WaitForSeconds(0.5f);
        loseScreen.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }

    void Update()
    {
        if (startHealth <= 0)
        {
            StartCoroutine(Lose());
        }
    }
}
