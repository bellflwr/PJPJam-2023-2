using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private void Awake()
    {
        StaticData.guns[0] = Resources.Load<GunData>("Guns/Pistol");
        StaticData.guns[1] = null;
        StaticData.guns[2] = null;
    }
}
