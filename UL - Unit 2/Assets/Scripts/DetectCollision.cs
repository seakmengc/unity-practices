using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            var player = other.gameObject.GetComponent<PlayerController>();
            player.DecrementLive();

            Destroy(gameObject, 0.1f);

        }
        else if (other.gameObject.tag == "Food")
        {
            gameObject.GetComponent<AnimalHunger>().Feed();

            Destroy(other.gameObject);
        }
    }
}
