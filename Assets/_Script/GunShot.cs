using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class GunShot
{
    public GameObject centerGun;
    [HideInInspector] public ParticleSystem centerGunVFX;

    public void CreateGunShot(GameObject lazer, Vector3 pos, Vector3 rot) 
    {
        GameObject gameObject = UnityEngine.Object.Instantiate(lazer, pos, Quaternion.Euler(rot));
        UnityEngine.Object.Destroy(gameObject,7f);
    }

}
