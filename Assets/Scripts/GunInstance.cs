using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunInstance
{
    public GunData stats;
    public int loaded;

    public static GunInstance CreateLoaded(GunData data) {
        GunInstance gi = new GunInstance();
        gi.stats = data;
        gi.loaded = data.maxAmmo;
        return gi;
    }
}
