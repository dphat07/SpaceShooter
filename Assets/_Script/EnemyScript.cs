using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public Transform[] gunPoint;

    public GameObject enemyFlash;
    public GameObject enemyBullet;
    public GameObject explosionPrefab;
    public HealthBar healthBar;
    public GameObject damageEffect;
    public GameObject coinPrefab;
    public float speed = 5f;

    public float enemyBulletSpawnTime = 1f;


    public float health = 10f;
    float damage = 0f;
    float barSize = 1f;

    // Start is called before the first frame update
    void Start()
    {
        enemyFlash.SetActive(false);
        StartCoroutine(EnemyShooting());
        damage = barSize / health;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (Vector2.down * speed * Time.deltaTime);
    }

    void DamageHealthBar()
    {
        if (health > 0)
        {
            health -= 1;
            barSize = barSize - damage;
            healthBar.SetSize(barSize);
        }
    }

    void EnemyFire()
    {
        //Instantiate(enemyBullet, gunPoint1.position, Quaternion.identity);
        //Instantiate(enemyBullet, gunPoint2.position, Quaternion.identity);

        for (int i = 0; i < gunPoint.Length; i++)
        {
            Instantiate(enemyBullet, gunPoint[i].position, Quaternion.identity);
        }
    }

    IEnumerator EnemyShooting()
    {
        while (true)
        {
            yield return new WaitForSeconds(enemyBulletSpawnTime);
            EnemyFire();
            //audioSource.PlayOneShot(bulletSound, 0.5f);
            enemyFlash.SetActive(true);
            yield return new WaitForSeconds(0.04f);
            enemyFlash.SetActive(false);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "PlayerBullet")
        {
            //audioSource.PlayOneShot(damageSound, 0.5f);
            DamageHealthBar();
            Destroy(collision.gameObject);
            GameObject damageVFx = Instantiate(damageEffect, collision.transform.position, Quaternion.identity);
            Destroy(damageVFx, 0.05f);
            if (health <= 0)
            {
                //AudioSource.PlayClipAtPoint(explosionSound, Camera.main.transform.position, 0.5f);
                Instantiate(coinPrefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
                GameObject enemyExplosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
                Destroy(enemyExplosion, 0.6f);

            }
        }
    }
}
