using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private const int xBound = 10;
    public int topBound = 15;
    public int bottomBound = 0;

    public float speed = 10f;
    public float turnSpeed = 5f;

    public int lives = 3;
    public int scores = 0;

    public float horizontalInput;
    private float verticalInput;

    public GameObject projectilePrefab;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -xBound || transform.position.x > xBound)
        {
            transform.position = new Vector3(transform.position.x < -xBound ? -xBound : xBound, 
                transform.position.y, transform.position.z);
        }

        if (transform.position.z < bottomBound || transform.position.z > topBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, 
                transform.position.z < bottomBound ? bottomBound : topBound);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * turnSpeed);

        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
        }
    }

    public void DecrementLive()
    {
        lives--;
        Debug.Log("Lives: " + lives);

        if (lives <= 0)
        {
            Destroy(gameObject, 0.1f);

            Debug.Log("Game Over.");
        }
    }

    public void IncrementScore()
    {
        scores++;

        Debug.Log("Scores: " + scores);
    }
}
