using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GunData defaultGun;
    public Transform directionalLight;
    float currentIntensity;
    
    public Vector3 sunDirection;
    
    private void Awake()
    {
        StaticData.guns[0] = GunInstance.CreateLoaded(defaultGun);
        StaticData.guns[1] = null;
        StaticData.guns[2] = null;
    }

    private void Update()
    {
        sunDirection = directionalLight.rotation * Vector3.forward;
        currentIntensity = .6f * sunDirection.z + .9f;
        RenderSettings.ambientIntensity = currentIntensity;        
    }
}
