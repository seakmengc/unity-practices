using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    private PlayerController playerController;

    private Vector3 spawnPos = new Vector3(20, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();

        Invoke("SpawnObstacle", 2f);
    }

    void SpawnObstacle()
    {
        if(playerController.isGameOver)
        {
            return;
        }

        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        Invoke("SpawnObstacle", 3f);
    }
}
