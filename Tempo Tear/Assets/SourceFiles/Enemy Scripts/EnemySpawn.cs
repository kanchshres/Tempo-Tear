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
    private GameObject enemy;
    private bool prevIsSkeleton;
    private int prevSpawnPoint;

    // Indicator Variables
    public GameObject[] indicatorPrefabs;
    public Transform[] indicatorSpawnPoints;

    // Testing Variables
    public bool testing;
    public int testNumber;


    // Initialization
    void Start()
    {
        spawnNumber = 0;
    }


    /// Test code
    void testcode()
    {
        spawnNumber = testNumber;
        audioSource.time = spawnTimes[spawnNumber];
        testing = false;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks when to to spawn enemies
        if (audioSource.time > spawnTimes[spawnNumber])
        {
            float difference = spawnTimes[spawnNumber + 1] - spawnTimes[spawnNumber];
            spawnNumber += 1;

            Spawn(difference);
        }

        /// For testing purposes
        if (testing == true)
        {
            testcode();
        }
    }


    // Spawn enemies
    void Spawn(float difference)
    {   
        // Set up
        int randEnemy = 0;
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        GameObject indicatorObject;
        
        // Check if skeleton should be spawned
        if (difference <= .3f && !prevIsSkeleton && Level.level == 2)
        {
            randEnemy = 1;
            prevSpawnPoint = randSpawnPoint;
        }

        // Special case for skeleton spawn
        if (prevIsSkeleton)
        {
            indicatorObject = Instantiate(indicatorPrefabs[prevSpawnPoint], indicatorSpawnPoints[prevSpawnPoint].position, transform.rotation);
            enemy.GetComponent<Enemy>().indicatorObjects.Add(indicatorObject);
            prevIsSkeleton = false;
        } 
        // Regular case
        else
        {
            // Spawn Enemy
            enemy = Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
            enemy.GetComponent<Enemy>().enemyNum = spawnNumber;
            indicatorObject = Instantiate(indicatorPrefabs[randSpawnPoint], indicatorSpawnPoints[randSpawnPoint].position, transform.rotation);

            // Set up for special case
            if (randEnemy == 1)
            {
                prevIsSkeleton = true;
            }
        
            // Spawn appropriate slash patterns
            for (int i = 0; i < enemy.GetComponent<Enemy>().slashPatterns.Count; i++)
            {
                // Set up
                int slashType = enemy.GetComponent<Enemy>().slashPatterns[i];
                GameObject patternObject = enemy.GetComponent<GameObject>();

                // Checks if slash pattern is horizontal
                if (slashType == 1)
                {
                    patternObject = Instantiate(slashPatterns.transform.GetChild(0).gameObject, enemy.transform);
                }
                // Checks if slash pattern is vertical
                else if (slashType == 2)
                {
                    patternObject = Instantiate(slashPatterns.transform.GetChild(1).gameObject, enemy.transform);
                }
                // Checks if slash pattern is diagonal left
                else if (slashType == 3)
                {
                    patternObject = Instantiate(slashPatterns.transform.GetChild(2).gameObject, enemy.transform);
                }
                // Checks if slash pattern is diagonal right
                else if (slashType == 4)
                {
                    patternObject = Instantiate(slashPatterns.transform.GetChild(3).gameObject, enemy.transform);
                }

                // Keep track of pattern and indicator objects
                enemy.GetComponent<Enemy>().patternObjects.Add(patternObject);
            }
            enemy.GetComponent<Enemy>().indicatorObjects.Add(indicatorObject);
        }
    }
}
