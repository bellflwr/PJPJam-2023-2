using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Barn : MonoBehaviour
{
    [SerializeField] GameObject barn;
    [SerializeField] float startHealth;
    [SerializeField] GameObject loseScreen;
    [SerializeField] Animator animator;
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
        animator = loseScreen.GetComponent<Animator>();
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
        yield return new WaitForSeconds(0.5f);
        Destroy(barn);
        yield return new WaitForSeconds(0.5f);
        loseScreen.SetActive(true);
        animator.Play("YouLoseAnimation");
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
