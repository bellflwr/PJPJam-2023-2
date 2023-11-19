using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class GunData : ScriptableObject
{
    public float damage;
    public int maxAmmo;
    public float reloadTime;
    public float fireInterval;
    public AmmoType ammoType;
    public bool automatic;
    public bool burst;



    public enum AmmoType
    {
        Light,
        Medium,
        Shells,
        Heavy
    }
}
