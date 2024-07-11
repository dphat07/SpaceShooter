using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiftScript : MonoBehaviour
{
    public GameObject[] giftPrefab;
    public float spawnTime = 7f;
    //public float speed = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GiftSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        //transform.Translate (Vector2.down * speed * Time.deltaTime);
    }

    IEnumerator GiftSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnTime);
            SpawnGift();

        }
    }

    void SpawnGift()
    {
        int randomValue = Random.Range(0, giftPrefab.Length);
        int randomXpos = Random.Range(-7, 7);
        Instantiate(giftPrefab[randomValue], new Vector2(randomXpos, transform.position.y), Quaternion.identity);
    }
}
