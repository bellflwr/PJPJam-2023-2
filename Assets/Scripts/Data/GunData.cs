using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Gun", menuName = "Gun")]
public class GunData : ScriptableObject
{
    public float damage;
    public int maxAmmo;
    public int currentAmmo;
    public float reloadTime;
    public float fireRate;

    public void Fire()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
            Debug.Log("Pew!");
        }
        else
        {
            Debug.Log("Click!");
        }
    }

    public IEnumerator Reload()
    {
        Debug.Log("Reloading...");
        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;
        Debug.Log("Reloaded!");
    }
}
