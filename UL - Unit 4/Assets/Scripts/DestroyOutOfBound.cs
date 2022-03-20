using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    private float xRange = 10.5f;
    private float zRange = 10.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mathf.Abs(transform.position.x) > xRange || Mathf.Abs(transform.position.z) > zRange)
        {
            Destroy(gameObject);
        }
    }
}
