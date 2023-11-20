using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GunData defaultGun1;
    public GunData defaultGun2;
    public GunData defaultGun3;
    public Transform directionalLight;
    float currentIntensity;
    
    public Vector3 sunDirection;
    
    private void Awake()
    {
        if (defaultGun1 != null)
        {
            StaticData.guns[0] = GunInstance.CreateLoaded(defaultGun1);
        }
        if (defaultGun2 != null)
        {
            StaticData.guns[1] = GunInstance.CreateLoaded(defaultGun2);
        }
        if (defaultGun3 != null)
        {
            StaticData.guns[2] = GunInstance.CreateLoaded(defaultGun3);
        }
    }

    private void Update()
    {
        sunDirection = directionalLight.rotation * Vector3.forward;
        currentIntensity = .6f * sunDirection.z + .9f;
        RenderSettings.ambientIntensity = currentIntensity;        
    }
}
