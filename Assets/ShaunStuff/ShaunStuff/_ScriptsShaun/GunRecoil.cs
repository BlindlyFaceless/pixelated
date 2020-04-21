﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRecoil : MonoBehaviour
{
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

    // Update is called once per frame
    void FixedUpdate()
    {
        currentRotation = Vector3.Lerp(currentRotation, Vector3.zero, returnSpeed * Time.deltaTime);
        Rot = Vector3.Slerp(Rot, currentRotation, rotationSpeed * Time.fixedDeltaTime);
        transform.localRotation = Quaternion.Euler(Rot);
    }

    public void Fire()
    {
        if (Aiming)
        {
            currentRotation += new Vector3(-RecoilRoationAiming.x, Random.Range(-RecoilRoationAiming.y, RecoilRoationAiming.y), Random.Range(-RecoilRoationAiming.z, RecoilRoationAiming.z));
        }
        else
        {
            currentRotation += new Vector3(-RecoilRoation.x, Random.Range(-RecoilRoation.y, RecoilRoation.y), Random.Range(-RecoilRoation.z, RecoilRoation.z));
        }

    }

    void Update()
    {
          if (Input.GetButtonDown("Fire1"))
            Fire();
        
        if (Input.GetButton("Fire2"))
            Aiming = true;
        else
            Aiming = false;
    }


}
