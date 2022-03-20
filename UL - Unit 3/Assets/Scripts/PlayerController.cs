using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rigidbody;
    private Animator animator;

    private bool isOnGround = true;

    public bool isGameOver = false;
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;
    public AudioClip crashSound;
    public AudioClip jumpSound;

    private AudioSource soundPlayer;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = this.GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        soundPlayer = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameOver)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            rigidbody.AddForce(Vector3.up * 500, ForceMode.Impulse);
            isOnGround = false;

            animator.SetTrigger("Jump_trig");
            dirtParticle.Stop();
            soundPlayer.PlayOneShot(jumpSound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("On ground");
            isOnGround = true;
            dirtParticle.Play();
        }
        else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            isGameOver = true;

            animator.SetInteger("DeathType_int", 1);
            animator.SetBool("Death_b", true);
            explosionParticle.Play();
            dirtParticle.Stop();
            soundPlayer.PlayOneShot(crashSound);

            StartCoroutine("RestartGame");
        }
    }

    private IEnumerator RestartGame()
    {
        yield return new WaitForSeconds(3);

        SceneManager.LoadScene("Prototype 3");
    }
}
