using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoShoot : MonoBehaviour
{
    public int damagePer = 10;
    public float timeBetween = 1f;
    public float range = 100f;
    
    float timer;
    Ray shootRay;
    RaycastHit shootHit;
    int shootableMask;
    LineRenderer gunLine;
    Light gunLight;
    float effectsTime = 0.5f;

    private void Awake()
    {
        shootableMask = LayerMask.GetMask("Obstacles");
        gunLine = GetComponent<LineRenderer>();
        gunLight = GetComponent<Light>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if(Shooting.canShoot == true && timer >= timeBetween)
        {
            DoTheShoot();
        }

        if (timer >= timeBetween * effectsTime)
        {
            DisableEffects();
        }
    }

    public void DisableEffects()
    {
        gunLight.enabled = false;
        gunLine.enabled = false;
    }

    void DoTheShoot()
    {
        timer = 0f;

        gunLight.enabled = true;

        gunLine.enabled = true;
        gunLine.SetPosition(0, transform.position);

        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
        {
            Debug.Log("shoot");
        }
    }
}
