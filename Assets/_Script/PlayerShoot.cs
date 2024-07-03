using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectileObject;
    public float fireRate;
    private float nextFire;
    bool shootingIsActive = true;
    private GunShot gunShot;




    // Start is called before the first frame update
    void Start()
    {
        gunShot = new GunShot();
        gunShot.centerGun = GameObject.Find("CentreGun"); // Thay thế "CenterGun" bằng tên của GameObject thực tế trong scene của bạn
        if (gunShot.centerGun != null)
        {
            gunShot.centerGunVFX = gunShot.centerGun.GetComponent<ParticleSystem>();
        }
        else
        {
            Debug.LogError("CentreGun GameObject not found!");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (shootingIsActive)
        {
            if (Time.time > nextFire)
            {
                MakeShot();
                nextFire = Time.time + 1 / fireRate;
            }
        }
    }

    void MakeShot()
    {
        if (gunShot.centerGun != null)
        {
            gunShot.CreateGunShot(projectileObject, gunShot.centerGun.transform.position, Vector3.zero);
            gunShot.centerGunVFX?.Play();
        }

        else
        {
            Debug.LogError("GunShot centerGun is not initialized!");
        }

    }    
}
