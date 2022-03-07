using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    // Health & Slash Variables
    private int maxHealth = 20;
    public int currentHealth;
    public int slashPattern;
    public int enemyNum;

    // Movement Variables
    public float beatTempo;
    private float speed;
    bool inRange = false;

    // Attack Variables
    public LayerMask playerLayer;
    public int numOfCollisions = 0;

    // Animator Variable
    public Animator animator;
    public char location = 'l';


    // Initialization
    void Awake()
    {
        // Set zombie's max health and slash pattern
        currentHealth = maxHealth;
        slashPattern = Random.Range(1, 5);

        // Set zombie's speed and location
        speed = beatTempo / 60f;
        if (transform.position.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            location = 'r';
        }
    }


    // Update is called once per frame
    void Update()
    {
        // Moves zombie
        if (0 < currentHealth && inRange == false)
        {
            transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position,
            speed * Time.deltaTime);
        }
    }


    /* Zombie attacks player */
    public void Attack()
    {
        animator.SetTrigger("Attack");
        ScoreSetter.multiplier = 1;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        numOfCollisions++;
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;
            Attack();
        }
    }
    /* Zombie attacks player */


    // Zombie takes damage
    public void TakeDamage(int damage, int cutType)
    {
        // Checks if cut type matches slash pattern
        if (cutType == slashPattern)
        {
            currentHealth -= damage;
            animator.SetTrigger("Hurt");
            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }


    // Zombie dies
    void Die()
    {
        // Disable enemy
        this.enabled = false;

        // Die animation
        animator.SetBool("IsDead", true);
        
        // Increase score
        ScoreSetter.score += 300 * ScoreSetter.multiplier;
        ScoreSetter.multiplier++;
    }


    // Deletes zombie from screen
    void Delete()
    {
        Destroy(gameObject);
    }
}
