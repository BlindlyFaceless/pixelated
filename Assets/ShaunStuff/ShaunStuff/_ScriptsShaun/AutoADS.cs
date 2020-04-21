using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoADS : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetButton("Fire2"))
            transform.localPosition = new Vector3(0, -0.15f, 0.37f);
     else
            transform.localPosition = new Vector3(0.18f, -0.2f, 0.37f);
    }
}
