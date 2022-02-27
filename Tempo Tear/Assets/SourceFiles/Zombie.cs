using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    // Health Variables
    public int maxHealth = 20;
    int currentHealth;

    // Attack Variables
    public LayerMask playerLayer;

    // Animator Variable
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        // Set zombie's max health
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Determine if player is in range of attack

    }

    // Zombie takes damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        // Play hurt animation
        animator.SetTrigger("Hurt");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Die animation
        animator.SetBool("IsDead", true);

        // Disable enemy
        this.enabled = false;
        GetComponent<Zombie>().enabled = false;
    }
}
