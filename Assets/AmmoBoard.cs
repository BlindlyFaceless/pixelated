using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBoard : MonoBehaviour
{
    public Text PistolAmmo;
    public Text AutoAmmo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PistolAmmo.text = "" + Gun.CurrentAmmo;
        AutoAmmo.text = "" + FullAuto.CurrentAmmo;
    }
}
