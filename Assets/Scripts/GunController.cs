using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public LayerMask hitLayer;
    private float _lastShot = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // GunInstance gun = StaticData.guns[StaticData.currentGun];
        // if((Input.GetMouseButtonDown(0) || Input.GetMouseButton(0) && gun.isAuto) && gun.loaded > 0) {
        //     if(Time.time - _lastShot > gun.fireInterval) {
        //         RaycastHit hit;
        //         if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 100f, hitLayer)) {
        //             Destroy(hit.transform.gameObject);
                    
        //         }
        //     }
            
        // }
    }
}
