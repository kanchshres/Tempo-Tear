using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Health Variables
    public int maxHealth = 70;
    int currentHealth;
    public HealthBar healthBar;
    
    // Attack Variables
    public LayerMask enemyLayers;

    // Animator Variable
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        // Set player's max health
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }


    // Update is called once per frame
    void Update()
    {
        // Determine if player is slashing
        if (Input.GetMouseButtonDown(0))
        {
            Slash();
        }

        // Determine if player is hit
        if (Input.GetMouseButtonDown(1))
        {
            TakeDamage(20);
        }

    }


    // Player slashes 
    void Slash()
    {
        // Play an attack animation
        animator.SetTrigger("Slash");

        // Detect enemies corresponding to slash


        // Damage corresponding enemies

    }


    // Player is hit
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        // Play hurt animation
        animator.SetTrigger("Hit");

        if (currentHealth <= 0)
        {
            Die();
        }
    }


    // Player dies
    void Die()
    {
        // Play die animation

        // Disable controls

        // Show game over screen
    }
}
