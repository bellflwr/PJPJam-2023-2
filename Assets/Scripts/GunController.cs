using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GunController : MonoBehaviour
{
    public LayerMask hitLayer;
    private float _lastBurst = 0;

    private GunInstance _gun;
    private AudioSource _audioSource;

    private void Start()
    {
        ChangeGun(0);
        _audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0) && _gun.stats.automatic))
        {
            if (Time.time - _lastBurst > _gun.stats.fireInterval)
            {
                StartCoroutine(Burst(_gun.stats.burst, _gun.stats.burstInterval));
            }
        }
    }

    IEnumerator Burst(int times, float interval)
    {
        _lastBurst = Time.time;

        int i = 0;
        while (i < times)
        {
            Shoot();
            yield return new WaitForSeconds(interval); //wait 1 second per interval
            i++;
        }
    }

    void Shoot()
    {
        if (_gun.loaded <= 0)
        {
            return;
        }

        _audioSource.pitch = Random.Range(0.8f, 1.2f);
        _audioSource.PlayOneShot(_gun.stats.audio, 0.5f);
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100f, hitLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                Color.yellow);
        }

        _gun.loaded -= 1;
    }

    void ChangeGun(int num)
    {
        StaticData.currentGun = num;
        _gun = StaticData.guns[StaticData.currentGun];
    }
}