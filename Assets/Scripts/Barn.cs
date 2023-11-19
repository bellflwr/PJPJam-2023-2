using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Barn : MonoBehaviour
{
    [SerializeField] GameObject barn;
    public float health;
    [SerializeField] GameObject loseScreen;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem loseParticles;

    public void Awake()
    {
        animator = loseScreen.GetComponent<Animator>();
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
        if (health <= 0)
        {
            StartCoroutine(Lose());
        }
    }
}
