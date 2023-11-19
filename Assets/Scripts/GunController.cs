using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GunController : MonoBehaviour
{
    public LayerMask hitLayer;
    public GameObject bulletHole;

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
                StartCoroutine(Burst());
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }

    IEnumerator Burst()
    {
        _lastBurst = Time.time;

        int i = 0;
        while (i < _gun.stats.burst)
        {
            Shoot();

            yield return new WaitForSeconds(_gun.stats.burstInterval); //wait 1 second per interval
            i++;
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    void Shoot()
    {
        if (_gun.loaded <= 0)
        {
            return;
        }

        _audioSource.pitch = Random.Range(0.8f, 1.2f);
        _audioSource.PlayOneShot(_gun.stats.audio, 0.5f);

        for (int j = 0; j < _gun.stats.pellets; j++)
        {
            HitScan();
        }

        _gun.loaded -= 1;
    }

    void HitScan()
    {
        var rot = transform.rotation.eulerAngles;

        float r = _gun.stats.precision * Mathf.Sqrt(Random.value);
        float theta = Random.value * 2 * Mathf.PI;
        
        rot.x += r * Mathf.Cos(theta);
        rot.y += r * Mathf.Sin(theta);
        
        var dir = Quaternion.Euler(rot) * Vector3.forward;

        print(rot);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, dir, out hit, 100f, (1 << 6) ^
                                                                    (1 << 7)))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                EnemyInstance ei = hit.collider.GetComponent<EnemyInstance>();
                ei.Health -= _gun.stats.damage;
                print(ei.Health);
            }
            else
            {
                Instantiate(bulletHole, hit.point, Quaternion.Euler(hit.normal));
            }


            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance,
                Color.yellow);
        }
    }

    void ChangeGun(int num)
    {
        StaticData.currentGun = num;
        _gun = StaticData.guns[StaticData.currentGun];
    }

    void Reload()
    {
        var space = _gun.stats.maxAmmo - _gun.loaded;
        
        var toBeLoaded = Mathf.Min(StaticData.ammo[_gun.stats.ammoType], space);
        StaticData.ammo[_gun.stats.ammoType] -= toBeLoaded;
        
        _gun.loaded += toBeLoaded;
    }
}