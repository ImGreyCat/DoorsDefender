using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Enemy enemyPrefab;

    public Transform topBorder;
    public Transform bottomBorder;

    public int spawnAddPerLevel = 5;

    public int spawnCounter = 10;

    // [Header("Spawn Time Settings")]
    //public float spawnInterval = 1f;
    [HideInInspector] public float spawnTimer = 0f;

    [Header("Spawn Time Randomizer")]
    public float spawnIntervalMax = 3.5f;
    public float spawnIntervalMin = 0.5f;


    private void Start()
    {
        spawnCounter = 5;
        spawnCounter += spawnAddPerLevel * LevelController.level;
    }
    public void Spawn()
    {
        spawnCounter--;
        spawnTimer = Random.Range(spawnIntervalMin, spawnIntervalMax);
        Vector2 randomPos = new Vector2(this.transform.position.x, Random.Range(bottomBorder.position.y, topBorder.position.y));

        Instantiate(enemyPrefab, randomPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (LevelController.isFinished == false)
        {
            if (spawnTimer > 0f)
            {
                spawnTimer -= Time.deltaTime;
            }
            else if (spawnCounter > 0)
            {
                Spawn();
                // spawnTimer = spawnInterval;
            }
        }
    }
}
