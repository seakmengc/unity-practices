using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float xRange = 10f;
    private float zRange = 10f;

    public int waveNumber = 1;

    // Start is called before the first frame update
    void Start()
    {
        SpawnNewEnemy(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        var enemyCount = FindObjectsOfType<Enemy>().Length;

        if(enemyCount == 0)
        {
            SpawnNewEnemy(++waveNumber);

            SpawnPowerup();
        }
    }

    void SpawnPowerup()
    {
        var powerupCount = GameObject.FindGameObjectsWithTag("Powerup").Length;
        if (powerupCount == 0)
        {
            Instantiate(powerupPrefab, GetRandomPosition(), powerupPrefab.transform.rotation);
        }
    }

    void SpawnNewEnemy(int count)
    {
        for (int i = 0; i < count; i++)
        {
            var spawnPos = GetRandomPosition();

            Instantiate(enemyPrefab, spawnPos, enemyPrefab.transform.rotation);
        }
    }

    Vector3 GetRandomPosition()
    {
        float xPos = Random.Range(xRange, -xRange);
        float zPos = Random.Range(zRange, -zRange);

        return new Vector3(xPos, enemyPrefab.transform.position.y, zPos);
    }
}
