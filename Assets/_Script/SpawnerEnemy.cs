using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{

    public GameObject enemy;
    public float respawnTime = 4f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator EnemySpawner()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        int randomXpos = Random.Range(-7, 7);
        Instantiate(enemy, new Vector2(randomXpos, transform.position.y), Quaternion.identity);
    }
}
