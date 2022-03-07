using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObject : MonoBehaviour
{
    // Movement Variables
    public float beatTempo;
    private float speed;
    bool inRange = false;

    // Animator Variable
    public Animator animator;
    public Zombie zombie;
    private bool spawnedLeft;
    char location = 'l';


    // Start is called before the first frame update
    void Start()
    {
        speed = beatTempo / 60f;

        // Flip zombie to correct orientation
        if (transform.position.x > 0)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
            location = 'r';
        }

        //GetComponent<Zombie>().SetLocation(location);
    }


    // Update is called once per frame
    void Update()
    {
        if (0 < zombie.currentHealth && inRange == false)
        {
            movement();
        }
    }


    // Moves the enemy towards the player
    void movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, GameObject.Find("Player").transform.position,
        speed * Time.deltaTime);
    }

    // Determines if enemy can attack player
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            inRange = true;
            zombie.Attack();
        }
    }
}