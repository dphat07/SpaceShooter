using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemy : MonoBehaviour
{

    public GameObject[] enemy;
    public float respawnTime = 5f;
    public GameController gameController;
    public int enemyCount = 10;

    private bool lastEnemySpawned = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        if (lastEnemySpawned && FindObjectOfType<EnemyScript>() == null && FindObjectOfType<BossScript>() == null)
        {
            StartCoroutine(gameController.LevelComplete());
        }
    }
    IEnumerator EnemySpawner()
    {
        for (int i = 0; i < enemyCount; i++)
        {
            yield return new WaitForSeconds(respawnTime);
            SpawnEnemy();
        }
        lastEnemySpawned = true;   
       
    }

    void SpawnEnemy()
    {
        int randomValue = Random.Range(0, enemy.Length);
        int randomXpos = Random.Range(-7, 7);
        Instantiate(enemy[randomValue], new Vector2(randomXpos, transform.position.y), Quaternion.identity);
    }
}
