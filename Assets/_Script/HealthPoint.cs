using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    public GameObject heart;
    public float timeSpawn = 7f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HeartSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator HeartSpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeSpawn);
            spawnHeart();

        }
    }

    void spawnHeart()
    {
        int randomXPos = Random.Range(-7, 7);
        Instantiate(heart, new Vector2(randomXPos, transform.position.y), Quaternion.identity);
    }
        


        
}
