using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GunData defaultGun;
    
    private void Awake()
    {
        StaticData.guns[0] = GunInstance.CreateLoaded(defaultGun);
        StaticData.guns[1] = null;
        StaticData.guns[2] = null;
    }
}
