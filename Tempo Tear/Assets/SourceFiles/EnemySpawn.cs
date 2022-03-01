using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public AudioSource audioSource;
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;
    public GameObject slashPatterns;

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
            GameObject zombie = Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation) as GameObject;
            int slashType = zombie.GetComponent<Zombie>().GetSlashPattern();
            Debug.Log(slashType);
            if (slashType == 1)
            {
                Instantiate(slashPatterns.transform.GetChild(2).gameObject, zombie.transform);
            }

            else if (slashType == 2)
            {
                Instantiate(slashPatterns.transform.GetChild(3).gameObject, zombie.transform);
            }
            else if (slashType == 3)
            {
                Instantiate(slashPatterns.transform.GetChild(0).gameObject, zombie.transform);
            }
            else if (slashType == 4)
            {
                Instantiate(slashPatterns.transform.GetChild(1).gameObject, zombie.transform);
            }
        }
    }
}
