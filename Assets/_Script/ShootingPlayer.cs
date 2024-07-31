using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class ShootingPlayer : MonoBehaviour
{
    public GameObject bulletRed;
    public GameObject bulletBlue;
    public Transform[] spawnPoint;
    //public GameObject item;

    private int bulletType = 0;

    public GameObject flash;
    public float bulletSpawnTime = 1f;

    int countShooting = 1;

    public AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        flash.SetActive(false);
        StartCoroutine(Shoot());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void Fire()
    {
       for (int i = 0; i < spawnPoint.Length; i++)
       {
            if (spawnPoint[i].gameObject.activeSelf)
            {
                if (bulletType == 0)
                {
                    Instantiate(bulletRed, spawnPoint[i].transform.position, Quaternion.identity);
                }
                else if (bulletType == 1)
                {
                    Instantiate(bulletBlue, spawnPoint[i].transform.position, Quaternion.identity);
                }    

            }
       }
    }


    IEnumerator Shoot()
    {
        while (true)
        {
            yield return new WaitForSeconds(bulletSpawnTime);
            Fire();
            
            audioSource.Play();
            flash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            flash.SetActive(false);

        }

    }

    public void GetItemShooting()
    {
        if (countShooting == 1)
        {
            spawnPoint[1].gameObject.SetActive(true);

        }
        else if (countShooting == 2)
        {
            spawnPoint[2].gameObject.SetActive(true);
        }
        else
            bulletType = 1;

        countShooting++;
    }

   
}
