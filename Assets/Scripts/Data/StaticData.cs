using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using static GunData;

public class StaticData : MonoBehaviour
{
    public static GunInstance[] guns = new GunInstance[3] {null, null, null};
    public static int currentGun = 0;

    public static Dictionary<AmmoType, int> ammo = new()
    {
        { AmmoType.Light, 1000000000 },
        { AmmoType.Medium, 1000000000 },
        { AmmoType.Heavy, 1000000000 },
        { AmmoType.Shells, 1000000000 },
    };
}
