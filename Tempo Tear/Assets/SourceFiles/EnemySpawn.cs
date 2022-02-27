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

    // Start is called before the first frame update
    void Start()
    {
        spawnNumber = 0;
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
        Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
    }
}
