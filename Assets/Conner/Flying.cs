using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flying : MonoBehaviour
{
    public float speed = 10;

    public Transform flyto;

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.LookAt(flyto);
        transform.position = Vector3.MoveTowards(transform.position, flyto.position, step);
    }

}

