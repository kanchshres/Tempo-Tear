using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    // Animator Variable
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Determine if player is attacking
        if (Input.GetMouseButtonDown(0))
        {
            Slash();
        }

        // Determine if player is hit
        if (Input.GetMouseButtonDown(1))
        {
            Hit();
        }

    }

    // 
    void Slash()
    {
        // Play an attack animation
        animator.SetTrigger("Slash");

        // Detect enemies corresponding to slash

        // Damage them

    }

    void Hit()
    {
        // Play a hit animation
        animator.SetTrigger("Hit");
    }
}
