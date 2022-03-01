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
    public Transform attackPoint;
    public float attackRange = 2f;
    public int attackDamage = 20;
    public LayerMask enemyLayer;

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
        // Determine if player is hit
        if (Input.GetMouseButtonDown(1))
        {
            TakeDamage(20);
        }
    }


    // Player slashes 
    public void Slash(int cutType)
    {
        // Detect enemies in range of slash
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        // Damage corresponding enemies
        int side = 0;
        foreach(Collider2D enemy in hitEnemies)
        {
            // Checks if cutType corresponds to Zombie's slash pattern
            int cutRequired = enemy.GetComponent<Zombie>().GetSlashPattern();
            cutType = cutRequired; // Temp
            if (cutType == cutRequired)
            {
                enemy.GetComponent<Zombie>().TakeDamage(attackDamage, cutType);
                side = enemy.GetComponent<Zombie>().GetLocation();
                break;
            }
        }

        // Play an attack animation
        if (side == 1)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            transform.position = new Vector3(-0.24f, transform.position.y, transform.position.z);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
            transform.position = new Vector3(.24f, transform.position.y, transform.position.z);
        }
        animator.SetTrigger("Slash");
    }


    // Draws Attack Range For Scene ONLY
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    // Player is hit
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        // Play hurt animation
        //animator.SetTrigger("Hit");
        animator.Play("Player_Block");

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
        //this.enabled = false;

        // Show game over screen
    }
}