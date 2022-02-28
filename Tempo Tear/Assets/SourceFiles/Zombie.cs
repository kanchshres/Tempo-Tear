using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    // Health Variables
    public int maxHealth = 20;
    public int currentHealth;

    // Attack Variables
    public LayerMask playerLayer;

    // Animator Variable
    public Animator animator;

    // Initialization
    void Start()
    {
        // Set zombie's max health
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {


    }

    // Zombie takes damage
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
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
    }
    void Delete()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            TakeDamage(20);
        }
    }
}
