using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Player HP
    public int maxHealth = 100;
    int currentHealth;
    
    // Animator Variable
    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }


    // Update is called once per frame
    void Update()
    {
        // Determine if player is attacking
        if (Input.GetMouseButtonDown(0))
        {
            Slash();
        }

        // Determine if player is hit
        if (Input.GetMouseButtonDown(1))
        {
            Hit();
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


    // Player takes damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

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
