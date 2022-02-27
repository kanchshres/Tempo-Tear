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
    private bool stopMoving;

    // Start is called before the first frame update
    void Start()
    {
        speed = beatTempo / 60f;
        // Flip zombie to correct position
        if (transform.position.x > 0)
        {
            spriterend.flipX = true;
        }
        else
        {
            spriterend.flipX = false;
        }
        stopMoving = false;
    }
    // Update is called once per frame
    void Update()
    {
        if (stopMoving == true)
        {
            Debug.Log("Attacking");
            Debug.Log(Time.time);
            Attack();
        }
        else
        {
            movement();
            //Debug.Log(GameObject.Find("Enemy").transform.position);
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
    }

    void Death()
    {
        Debug.Log("Death");
        animator.SetTrigger("Death");
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            stopMoving = true;
        }
    }

}