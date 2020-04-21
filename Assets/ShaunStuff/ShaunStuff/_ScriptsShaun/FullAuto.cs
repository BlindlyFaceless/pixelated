using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullAuto : MonoBehaviour
{
    public float damage;
    public float range;
    public float fireRate;

    public Camera fpsCam;
    public ParticleSystem muzzleFlash;
    public GameObject impactEffect;

    public static float CurrentAmmo;
    public float MaxAmmo;
    public bool Reloading;

    public bool BetweenShots = false;

    //Recoil Script
    [Header("Recoil Settings")]
    public float rotationSpeed;
    public float returnSpeed;
    [Space()]

    [Header("Hipfire")]
    public Vector3 RecoilRoation = new Vector3(25f, 25f, 25f);
    [Space()]

    [Header("Aiming")]
    public Vector3 RecoilRoationAiming = new Vector3(1f, 1f, 1f);
    public bool Aiming;

    private Vector3 currentRotation;
    private Vector3 Rot;

    void FixedUpdate()
    {
        currentRotation = Vector3.Lerp(currentRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        Rot = Vector3.Slerp(Rot, currentRotation, rotationSpeed * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(Rot);
    }

    private void Start()
    {
        CurrentAmmo = MaxAmmo;
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire2"))
            Aiming = true;
        else
            Aiming = false;

        if (Input.GetKeyDown(KeyCode.R) && CurrentAmmo != MaxAmmo)
        {
            StartCoroutine(Reload());           
        }

        if (Input.GetButton("Fire1") && CurrentAmmo > 0 && !Reloading && !BetweenShots)
        {
            StartCoroutine(Fire());
        }
    }

    void Shoot()
    {
         muzzleFlash.Play();

         CurrentAmmo -= 1;

         RaycastHit hit;

         if (Aiming)
         {
             currentRotation += new Vector3(-RecoilRoationAiming.x, Random.Range(-RecoilRoationAiming.y, RecoilRoationAiming.y), Random.Range(-RecoilRoationAiming.z, RecoilRoationAiming.z));
         }
         else
         {
             currentRotation += new Vector3(-RecoilRoation.x, Random.Range(-RecoilRoation.y, RecoilRoation.y), Random.Range(-RecoilRoation.z, RecoilRoation.z));
         }

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range))
        {
             Debug.Log(hit.transform.name);

             Enemy enemy = hit.transform.GetComponent<Enemy>();
             if (enemy != null)
             {
                 enemy.TakeDamage(damage);
             }

             GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
             Destroy(impactGO, 2f);
        }
         

    }

    IEnumerator Reload()
    {
        Reloading = true;
        transform.localPosition = new Vector3(0f, -1.2f, 0f);
        yield return new WaitForSeconds(1.25f);
        CurrentAmmo = MaxAmmo;
        transform.localPosition = new Vector3(0f, 0f, 0f);
        Reloading = false;
    }

    IEnumerator Fire()
    {
        BetweenShots = true;
        Shoot();
        yield return new WaitForSeconds(fireRate);
        BetweenShots = false;
        
    }
}
