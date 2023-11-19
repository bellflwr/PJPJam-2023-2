using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public LayerMask hitLayer;
    private float _lastBurst = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GunInstance gun = StaticData.guns[StaticData.currentGun];
        if((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0) && gun.gunData.automatic) && gun.loaded > 0) {
            if(Time.time - _lastBurst > gun.gunData.fireInterval) {
                
                StartCoroutine(Burst(gun.gunData.burst, gun.gunData.burstInterval));
            }
        }
    }

    IEnumerator Burst(int times, float interval) {
        _lastBurst = Time.time;
        print("pluh");

        int i = 0;
        while(i < times)
        {
            Shoot();
            yield return new WaitForSeconds(interval); //wait 1 second per interval
            i++;
        }
    }

    void Shoot() {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100f, hitLayer)) {
            // Destroy(hit.transform.gameObject);
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
        }
    }
}
