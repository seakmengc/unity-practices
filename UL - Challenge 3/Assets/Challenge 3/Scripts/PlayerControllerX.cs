using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private Rigidbody playerRb;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;

    private (float, float) yBound = (1f, 15f);
    private float moveDownBy = 0.1f;

    public AudioClip boundingUpSound;


    // Start is called before the first frame update
    void Start()
    {
        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();
        playerRb = GetComponent<Rigidbody>();

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver)
        {
            return;
        }

        //Bound the ballon up a bit when it hit the ground
        if (transform.position.y < yBound.Item1)
        {
            playerRb.AddForce(Vector3.up, ForceMode.Impulse);
            playerAudio.PlayOneShot(boundingUpSound);
        }

        //Bound the ballon down a bit when it hit the top
        if (transform.position.y > yBound.Item2)
        {
            //If it's way too much high to the top, reset the velocity to stop the force from pushing up further
            if(transform.position.y - yBound.Item2 - 5 > 0)
            {
                playerRb.velocity = Vector3.zero;
            }

            transform.position = Vector3.MoveTowards(transform.position, new Vector3(transform.position.x, yBound.Item2, transform.position.z), moveDownBy);
            return;
        }

        // While space is pressed and player is low enough, float up
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerRb.AddForce(Vector3.up * floatForce, ForceMode.Impulse);
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
            Destroy(gameObject, 2f);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            Destroy(other.gameObject);

        }

    }

}
