using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInstance
{
    public GunData gunData;
    public int loaded;

    public static GunInstance CreateLoaded(GunData data) {
        GunInstance gi = new GunInstance();
        gi.gunData = data;
        gi.loaded = data.maxAmmo;
        return gi;
    }
}
