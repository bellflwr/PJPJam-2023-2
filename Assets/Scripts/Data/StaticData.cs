using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using static GunData;

public class StaticData : MonoBehaviour
{
    public static GunInstance[] guns = new GunInstance[3];
    public static int currentGun = 0;

    public static Dictionary<AmmoType, int> ammo = new()
    {
        { AmmoType.Light, 100 },
        { AmmoType.Medium, 100 },
        { AmmoType.Heavy, 100 },
        { AmmoType.Shells, 100 },
    };
}
