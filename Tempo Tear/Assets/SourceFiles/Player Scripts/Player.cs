using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Health Variables
    private int maxHealth = 70;
    private int currentHealth;
    public HealthBar healthBar;

    // Attack Variables
    public Transform attackPoint;
    public float attackRange = 2f;
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
    }


    // Orientates player to enemy's location
    void OrientatePlayer(char enemyLoc)
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
    }


    // Player slashes 
    public void Slash(int cutType)
    {
        bool hitEnemy = false;

        // Detect enemies in range of slash
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        char enemyLoc = 'r';
        if (enemies.Length != 0)
        {
            // Find corresponding enemy
            Collider2D corEnemy = enemies[0];
            int corEnemyNum = 100;
            int enemyNum;
            foreach (Collider2D enemy in enemies)
            {
                for (int i = 0; i < enemy.GetComponent<Enemy>().slashPatterns.Count; i++)
                {
                    // Checks if cut type corresponds to at least one of Enemy's slash patterns
                    int slashPattern = enemy.GetComponent<Enemy>().slashPatterns[i];
                    int cutRequired = slashPattern;
                    if (cutType == cutRequired)
                    {
                        enemyNum = enemy.GetComponent<Enemy>().enemyNum;
                        if (enemyNum < corEnemyNum && enemy.GetComponent<Enemy>().isDead == false)
                        {
                            corEnemy = enemy;
                            corEnemyNum = enemyNum;
                            hitEnemy = true;
                        }
                        break;
                    }
                }
            }
            // Damage corresponding enemy
            corEnemy.GetComponent<Enemy>().TakeDamage(20, cutType);
            enemyLoc = corEnemy.GetComponent<Enemy>().location;
        }
        
        // Play attack animation
        OrientatePlayer(enemyLoc);
        animator.SetTrigger("Slash");

        // Reset score if player did not hit any enemy
        if (hitEnemy == false)
        {
            ScoreSetter.multiplier = 1;
        }
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


    /* Player is hit */
    public void TakeDamage(int damage, char enemyLoc)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        // Play hurt animation
        if (animator.gameObject.activeSelf)
        {
            OrientatePlayer(enemyLoc);
            animator.SetTrigger("Hit");
            if (currentHealth <= 0)
            {
                Die();
            }
        }

        ScoreSetter.multiplier = 1;
    }

    // Determines whether or not player is hit
    void OnTriggerEnter2D(Collider2D collision)
    {
        int enemyCollisions = collision.gameObject.GetComponent<Enemy>().numOfCollisions;
        if (collision.gameObject.tag == "Enemy" && enemyCollisions == 2)
        {
            char enemyLoc = collision.gameObject.GetComponent<Enemy>().location;
            TakeDamage(20, enemyLoc);
        }
    }
    /* Player is hit */

    // Player dies
    void Die()
    {
        // Play die animation

        // Disable controls
        //this.enabled = false;

        // Show game over screen
    }


}