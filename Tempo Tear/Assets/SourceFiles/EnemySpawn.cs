using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public AudioSource audioSource;
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public SpriteRenderer spriterend;
    public float[] spawnTimes;
    private int spawnNumber;
    public bool testing;
    public int testNumber;


    // Start is called before the first frame update
    void Start()
    {
        spawnNumber = 0;
        if (testing == true)
        {
            spawnNumber = testNumber;
            audioSource.time = spawnTimes[spawnNumber];
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(audioSource.time);
        if (audioSource.time > spawnTimes[spawnNumber])
        {
            // Debug.Log(audioSource.time);
            Spawn();
            spawnNumber += 1;
        }
    }


    void Spawn()
    {   
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        if (testing == true)
        {
            Instantiate(enemyPrefabs[randEnemy], spawnPoints[1].position, transform.rotation);
        }
        else
        {
            Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
        }
    }
}
