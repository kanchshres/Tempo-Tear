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

        // Spawn Enemy
        GameObject enemy = Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation) as GameObject;
        enemy.GetComponent<Enemy>().enemyNum = spawnNumber;

        // Spawn appropriate slash patterns
        for (int i = 0; i < enemy.GetComponent<Enemy>().slashPatterns.Count; i++)
        {
            // Set up
            int slashType = enemy.GetComponent<Enemy>().slashPatterns[i];
            GameObject patternObject = enemy.GetComponent<GameObject>();
            
            // Checks if slash pattern is horizontal
            if (slashType == 1)
            {
                patternObject = Instantiate(slashPatterns.transform.GetChild(2).gameObject, enemy.transform);
            }
            // Checks if slash pattern is vertical
            else if (slashType == 2)
            {
                patternObject = Instantiate(slashPatterns.transform.GetChild(3).gameObject, enemy.transform);
            }
            // Checks if slash pattern is diagonal left
            else if (slashType == 3)
            {
                patternObject = Instantiate(slashPatterns.transform.GetChild(0).gameObject, enemy.transform);
            }
            // Checks if slash pattern is diagonal right
            else if (slashType == 4)
            {
                patternObject = Instantiate(slashPatterns.transform.GetChild(1).gameObject, enemy.transform);
            }

            // Keep track of pattern objects
            enemy.GetComponent<Enemy>().patternObjects.Add(patternObject);
        }
    }
}
