using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject powerup;
    //public float startDelay = 0.0f;
    //public float repeatTime = 5.0f;
    public float spawnRange = 8.0f;
    public int enemiesInWave = 1;
    public int enemyCount;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Spawn(enemiesInWave)", startDelay, repeatTime);
        Spawn(enemiesInWave);
        SpawnPowerup();
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<EnemyController>().Length;
        if (enemyCount == 0)
        {
            enemiesInWave++;
            Spawn(enemiesInWave);
            SpawnPowerup();
        }
    }

    void Spawn(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemy, GenerateSpawnPosition(), enemy.transform.rotation);
        }
    }

    void SpawnPowerup()
    {
        Instantiate(powerup, GenerateSpawnPosition(), powerup.transform.rotation);
    }

    private Vector3 GenerateSpawnPosition()
    {
        float posX = Random.Range(-spawnRange, spawnRange);
        float posZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(posX, 0.0f, posZ);

        return randomPos;
    }
}
