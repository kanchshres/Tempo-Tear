using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    // Health Variables
    private int maxHealth = 20;

    // Enemy Variable
    public Enemy enemy;
    private int enemyLevel = 1;


    // Initialization
    void Awake()
    {
        // Set zombie's max health and slash pattern
        enemy.currentHealth = maxHealth;
        enemy.enemyType = enemyLevel;
        
        List<int> slashPatterns = new List<int>();
        int pattern = Random.Range(1, 5);
        slashPatterns.Add(pattern);
        
        enemy.slashPatterns = slashPatterns;
    }
}
