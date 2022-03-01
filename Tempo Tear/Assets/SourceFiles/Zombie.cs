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
    public Player player;
    public int attackDamage = 20;
    public LayerMask playerLayer;
    bool isAttacking = false;

    // Animator Variable
    public Animator animator;

    // Location Variable
    int location;

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


    // Gets the Zombie's location of leftside or rightside
    public int GetLocation()
    {
        return location;
    }


    // Gets the Zombie's specific slash pattern
    public int GetSlashPattern()
    {
        return slashPattern;
    }


    // Zombie attacks player
    public void Attack()
    {
        animator.SetTrigger("Attack");
        player.TakeDamage(attackDamage);
    }


    // Sets the Zombie's location of leftside or rightside
    public void SetLocation(int side)
    {
        location = side;
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
