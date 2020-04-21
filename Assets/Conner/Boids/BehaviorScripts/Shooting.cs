using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask mask;
    public float reach;
    public static bool canShoot = false;


    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hit, reach) && hit.transform.CompareTag("Target"))
        {
            Shoot();

        }
    }
        

        
        void Shoot()
        {
            canShoot = true;
        }



}
    


