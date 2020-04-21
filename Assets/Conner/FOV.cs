using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FOV : MonoBehaviour
{
    public LayerMask obstacleMask;
    public float speed = 10;
    public bool canSee = false;
    public Transform flyto;
    public float veiwRadius;
    [Range(0, 360)]
    public GameObject target;
    public float stopDist = 2f;
    public float dist = 2;
    bool toClose;

    void Update()
    {
        float dist = Vector3.Distance(target.transform.position, transform.position);
        Collider[] hits = Physics.OverlapSphere(transform.position, veiwRadius);
        foreach (Collider hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                canSee = true;
            }
        }
        
        if (canSee == true && dist >= stopDist)
        {
           
            float step = speed * Time.deltaTime;
            transform.LookAt(flyto);
            transform.position = Vector3.MoveTowards(transform.position, flyto.position, step);
            if(Physics.Raycast(transform.position, -Vector3.up, dist + 0.1f))
            {
                transform.localRotation = Quaternion.Euler(1,0,1);
            }
        }
        if (canSee == true)
        {
            transform.LookAt(target.transform);
        }
    }
}


