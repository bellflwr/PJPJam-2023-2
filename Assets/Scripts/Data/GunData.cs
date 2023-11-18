using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class GunData : ScriptableObject
{
    public float damage;
    public int maxAmmo;
    public float reloadTime;
    public float fireRate;
    public AmmoType ammoType;


    public enum AmmoType
    {
        Light,
        Medium,
        Shells,
        Heavy
    }
}
