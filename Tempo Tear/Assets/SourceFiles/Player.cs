using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Health Variables
    int maxHealth = 70;
    int currentHealth;
    public HealthBar healthBar;
    int numOfCollisions;

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
        bool hitEnemy = false;

        // Detect enemies in range of slash
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        // Find corresponding enemies
        char enemyLoc = 'r';
        if (enemies.Length != 0)
        {
            Collider2D corEnemy = enemies[0];
            int corEnemyNum = 100;
            int enemyNum;
            foreach (Collider2D enemy in enemies)
            {
                // Checks if cut type corresponds to Zombie's slash pattern
                int cutRequired = enemy.GetComponent<Zombie>().slashPattern;
                if (cutType == cutRequired)
                {
                    hitEnemy = true;
                    enemyNum = enemy.GetComponent<Zombie>().enemyNum;
                    if (enemyNum < corEnemyNum)
                    {
                        corEnemy = enemy;
                        corEnemyNum = enemyNum;
                    }
                }
            }
            corEnemy.GetComponent<Zombie>().TakeDamage(attackDamage, cutType);
            enemyLoc = corEnemy.GetComponent<Zombie>().location;
            hitEnemy = true;
        }
        

        PlayAttackAnimation(enemyLoc);

        // Reset score if player did not hit any enemy
        if (hitEnemy == false)
        {
            ScoreSetter.multiplier = 1;
        }
    }


    // Play an attack animation
    void PlayAttackAnimation(char enemyLoc)
    {
        if (enemyLoc == 'l')
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
        ScoreSetter.multiplier = 1;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        // Play hurt animation
        if (animator.gameObject.activeSelf)
        {
            animator.SetTrigger("Hit");
            if (currentHealth <= 0)
            {
                Die();
            }
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


    // Determines whether or not player is hit
    void OnTriggerEnter2D(Collider2D collision)
    {
        numOfCollisions++;
        if (collision.gameObject.tag == "Enemy" && 2 == numOfCollisions)
        {
            TakeDamage(20);
            numOfCollisions = 0;
        }
    }
}