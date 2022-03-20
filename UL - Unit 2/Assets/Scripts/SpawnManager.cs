using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private const int spawnDelay = 2;
    private const float spawnInterval = 1.5f;
    public GameObject[] animalPrefabs;

    private int xBound = 10;
    private (float, float) zBound = (5f, 15f);

    private int spawnZRange = 18;

    string[] functions = { "GetSpawnRandomAnimalFrontParams", "GetSpawnRandomAnimalLeftParams", "GetSpawnRandomAnimalRightParams" };

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Ticker", spawnDelay, spawnInterval);
    }

    private void Ticker()
    {
        string chosenFn = functions[Random.Range(0, functions.Length)];
        var method = this.GetType().GetMethod(chosenFn);
        
        (var spawnPosition, var spawnRotation) = ((Vector3, Quaternion)) method.Invoke(this, null);
        int ind = Random.Range(0, animalPrefabs.Length);

        SpawnRandomAnimal(ind, spawnPosition, spawnRotation);
    }

    private void SpawnRandomAnimal(int ind, Vector3 spawnPosition, Quaternion spawnRotation)
    {
        Instantiate(animalPrefabs[ind], spawnPosition, spawnRotation);
    }

    public (Vector3, Quaternion) GetSpawnRandomAnimalFrontParams()
    {
        return (new Vector3(Random.Range(-xBound, xBound), 0, spawnZRange), Quaternion.Euler(0, 180, 0));
    }

    public (Vector3, Quaternion) GetSpawnRandomAnimalLeftParams()
    {
        return (new Vector3(-xBound, 0, Random.Range(zBound.Item1, zBound.Item2)), Quaternion.Euler(0, 90, 0));
    }

    public (Vector3, Quaternion) GetSpawnRandomAnimalRightParams()
    {
        return (new Vector3(xBound, 0, Random.Range(zBound.Item1, zBound.Item2)), Quaternion.Euler(0, -90, 0));
    }
}
