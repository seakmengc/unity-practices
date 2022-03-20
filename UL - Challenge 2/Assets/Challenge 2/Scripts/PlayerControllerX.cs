using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public GameObject dogPrefab;
    private float nextSpawn = 0.0f;
    private float spawnRate = 0.5f;

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time);
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;
            Instantiate(dogPrefab, dogPrefab.transform.position, dogPrefab.transform.rotation);
        }
    }
}
