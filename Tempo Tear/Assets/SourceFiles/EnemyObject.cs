using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    public float beatTempo;
    private float speed;

    // Animator Variable
    public Animator animator;
    public SpriteRenderer spriterend;
    public Blade blade;
    public Zombie zombie;
    private bool spawnedLeft;

    // Start is called before the first frame update
    void Start()
    {
        speed = beatTempo / 60f;
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        Physics2D.IgnoreCollision(player.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        // Flip zombie to correct position
        if (transform.position.x > 0)
        {
            spriterend.flipX = true;
            spawnedLeft = false;
            }
        else
        {
            spriterend.flipX = false;
            spawnedLeft = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (zombie.currentHealth > 0)
        {
            if ((transform.position.x >= -0.8471791 && spawnedLeft == true) || (transform.position.x <= 0.85 && spawnedLeft == false))
            {
                Attack();
            }

            else
            {
                movement();
                //Debug.Log(GameObject.Find("Enemy").transform.position);
            }
        }

        // Check if enemy is in range of 
    }

    void movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position,
        speed * Time.deltaTime);
    }

    // Attack player
    void Attack()
    {
        animator.SetTrigger("Attack");
        ScoreSetter.multiplier = 1; 
    }

    void Death()
    {
        animator.SetTrigger("Death");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        
    }
}