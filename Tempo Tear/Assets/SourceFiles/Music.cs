using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource audioSource;
    public float startTime;
    public float endTime;

    // Start is called before the first frame update
    void Start()
    {
        audioSource.time = startTime;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(audioSource.time);
        if (audioSource.time > endTime)
        {
            audioSource.Stop();
        }
    }
}
