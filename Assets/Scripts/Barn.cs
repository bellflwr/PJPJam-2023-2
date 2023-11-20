using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Barn : MonoBehaviour
{
    [SerializeField] GameObject barn;
    private float maxHealth;
    public float health;
    [SerializeField] GameObject loseScreen;
    [SerializeField] Animator animator;
    [SerializeField] ParticleSystem loseParticles;
    [SerializeField] Text healthText;

    public void Awake()
    {
        maxHealth = health;
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
        healthText.text = "Fertilizer Health:" + health + "/" + maxHealth; 
        if (health <= 0)
        {
            StartCoroutine(Lose());
        }
    }
}
