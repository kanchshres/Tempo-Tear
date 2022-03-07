using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    // Spawn Variables
    public AudioSource audioSource;
    public Transform[] spawnPoints;
    public float[] spawnTimes;
    private int spawnNumber;

    // Enemy Variables
    public GameObject[] enemyPrefabs;
    public GameObject slashPatterns;

    // Testing Variables
    public bool testing;
    public int testNumber;


    // Initialization
    void Start()
    {
        spawnNumber = 0;

        /// Test Code
        if (testing == true)
        {
            spawnNumber = testNumber;
            audioSource.time = spawnTimes[spawnNumber];
        }
    }


    // Update is called once per frame
    void Update()
    {
        // Checks when to to spawn enemies
        if (audioSource.time > spawnTimes[spawnNumber])
        {
            spawnNumber += 1;
            Spawn();
        }
    }


    // Spawn enemies
    void Spawn()
    {   
        // Set up
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);

        /// Test code
        if (testing == true)
        {
            Instantiate(enemyPrefabs[randEnemy], spawnPoints[1].position, transform.rotation);
        }
        /// Real code
        else
        {
            // Spawn Zombie
            GameObject zombie = Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation) as GameObject;
            int slashType = zombie.GetComponent<Zombie>().slashPattern;
            zombie.GetComponent<Zombie>().enemyNum = spawnNumber;

            // Checks if slash pattern is horizontal
            if (slashType == 1)
            {
                Instantiate(slashPatterns.transform.GetChild(2).gameObject, zombie.transform);
            }
            // Checks if slash pattern is vertical
            else if (slashType == 2)
            {
                Instantiate(slashPatterns.transform.GetChild(3).gameObject, zombie.transform);
            }
            // Checks if slash pattern is diagonal left
            else if (slashType == 3)
            {
                Instantiate(slashPatterns.transform.GetChild(0).gameObject, zombie.transform);
            }
            // Checks if slash pattern is diagonal right
            else if (slashType == 4)
            {
                Instantiate(slashPatterns.transform.GetChild(1).gameObject, zombie.transform);
            }
        }
    }
}
