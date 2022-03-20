using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + new Vector3(0, 10, -20);

        //transform.RotateAround(transform.position, Vector3.up * Time.deltaTime, player.transform.localRotation.y);
        transform.LookAt(player.transform, player.transform.position);
        transform.Translate(Vector3.right * Time.deltaTime);
    }
}
