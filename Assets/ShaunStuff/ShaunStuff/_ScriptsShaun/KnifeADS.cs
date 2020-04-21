using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeADS : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     if (Input.GetButton("Fire1"))
            transform.localPosition = new Vector3(0, -0.860f, -0.187f);
     else
            transform.localPosition = new Vector3(0.08f, -0.865f, -0.187f);
    }
}
