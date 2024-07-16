using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerBoss : MonoBehaviour
{
    public GameObject boss;
    public GameController gameController;
    private bool lastBoss = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(BossSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        if (lastBoss && FindObjectOfType<BossScript>() == null)
        {
            StartCoroutine(gameController.LevelComplete());
        }
    }
    IEnumerator BossSpawner()
    {
       
        yield return new WaitForSeconds(1f);
        SpawnBoss();
        lastBoss = true;

    }

    void SpawnBoss()
    {
        Instantiate(boss, new Vector2(0,10f), Quaternion.identity);
        Debug.Log("Spawn Boss");
    }
}
