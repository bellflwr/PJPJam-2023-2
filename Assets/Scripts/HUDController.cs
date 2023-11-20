using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    public Text loadedAmmo;
    public Text totalAmmo;
    public Text ammoType;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var currentGun = StaticData.guns[StaticData.currentGun];
        loadedAmmo.text = currentGun.loaded.ToString() + "/" + currentGun.stats.maxAmmo.ToString();
        totalAmmo.text = StaticData.ammo[currentGun.stats.ammoType].ToString();
        ammoType.text = currentGun.stats.ammoType.ToString();
    }
}
