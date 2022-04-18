using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    // Health Variable
    private int maxHealth = 40;

    // Enemy Variable
    public Enemy enemy;
    private int enemyLevel = 2;

    // Initialization
    void Awake()
    {
        // Set skeleton's max health and slash pattern
        enemy.currentHealth = maxHealth;
        enemy.enemyType = enemyLevel;

        List<int> slashPatterns = new List<int>();
        for (int i = 0; i < enemyLevel; i++)
        {
            int pattern = Random.Range(1, 5);
            slashPatterns.Add(pattern);
        }

        enemy.slashPatterns = slashPatterns;
    }
}
