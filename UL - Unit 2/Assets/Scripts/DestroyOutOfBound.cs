using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    public int topBound = 20;

    public int bottomBound = -5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < bottomBound || transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
    }
}
