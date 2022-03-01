using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slashes : MonoBehaviour
{
    private Vector3 starting;
    // Start is called before the first frame update
    void Start()
    {
        starting = new Vector3(transform.position.x + 1.2f, 1f, transform.position.z);
        transform.position = starting;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
