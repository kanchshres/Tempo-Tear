using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slashes : MonoBehaviour
{
    private Vector3 starting;
    // Start is called before the first frame update
    void Start()
    {
        if (transform.position.x > 0)
        {
            starting = new Vector3(transform.position.x - 1.2f, -1f, 0f);
        }
        else
        {
            starting = new Vector3(transform.position.x + 1.2f, -1f, 0f);
        }
        
        transform.position = starting;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
