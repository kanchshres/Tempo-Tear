using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    // Health & Slash Variables
    public int maxHealth = 20;
    public int currentHealth;
    public int slashPattern;

    // Attack Variables
    public int attackDamage = 20;
    public LayerMask playerLayer;

    // Animator Variable
    public Animator animator;

    // Initialization
    void Start()
    {
        // Set zombie's max health and slash pattern
        currentHealth = maxHealth;
        slashPattern = Random.Range(1, 4);
    }


    // Update is called once per frame
    void Update()
    {

    }


    // Zombie attacks player
    void Attack()
    {

    }


    // Gets the Zombie's specific slash pattern
    public int GetSlashPattern()
    {
        return slashPattern;
    }


    // Zombie takes damage
    public void TakeDamage(int damage, int cutType)
    {
        // Checks if cut type 
        if (cutType == slashPattern)
        {
            currentHealth -= damage;
            animator.SetTrigger("Hurt");
            if (currentHealth <= 0)
            {
                Die();
            }
        }
        ScoreSetter.score += 300 * ScoreSetter.multiplier;
        ScoreSetter.multiplier++;
    }


    // Zombie dies
    void Die()
    {
        // Die animation
        animator.SetBool("IsDead", true);

        // Disable enemy
        this.enabled = false;
    }


    // Deletes zombie from screen
    void Delete()
    {
        Destroy(gameObject);
    }
}
