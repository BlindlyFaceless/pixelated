using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class reloadTExt : MonoBehaviour
{
    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Gun.CurrentAmmo == 0 && weaponSwitching.selectedWeapon == 1)
            Text.SetActive(true);
        else if (FullAuto.CurrentAmmo == 0 && weaponSwitching.selectedWeapon == 0)
            Text.SetActive(true);
        else
            Text.SetActive(false);
  


    }
}
