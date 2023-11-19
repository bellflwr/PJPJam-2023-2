using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticData : MonoBehaviour
{
    public static GunInstance[] guns = new GunInstance[3];
    public static int currentGun = 0;

    public static int lightAmmo = 0;
    public static int mediumAmmo = 0;
    public static int shellsAmmo = 0;
    public static int heavyAmmo = 0;
}
