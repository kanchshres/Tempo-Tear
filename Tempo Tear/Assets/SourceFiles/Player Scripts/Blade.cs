using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    // Trail Variables
    public GameObject trailPrefab;
    GameObject currentTrail;

    // Blade Variables 
    Rigidbody2D rigidBody;
    Camera cam;
    bool isSlashing = false;
    Vector2 previousPosition;

    // Cutting Variables
    public int cutType = 0;
    float minSlashMagnitude = 1.5f;
    List<Vector2> positions = new List<Vector2>();

    // Player Variables
    public Player player;


    // Initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        trailPrefab.GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if game is in unpaused state
        if (!PauseMenu.GameIsPaused)
        {
            // Checks if user is trying to slash
            if (Input.GetMouseButtonDown(0))
            {
                StartSlashing();
            }
            // Checks if user is not trying to slash
            else if (Input.GetMouseButtonUp(0))
            {
                if (positions.Count != 0)
                {
                    StopSlashing();
                }
            }

            // Checks if user is slashing
            if (isSlashing)
            {
                UpdateBlade();
            }
        } 
    }

    // Update blade
    void UpdateBlade()
    {
        Vector2 newPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        rigidBody.position = newPosition;
        positions.Add(newPosition);
    }


    // Enable slashing
    void StartSlashing()
    {
        positions.Clear();
        isSlashing = true;
        rigidBody.position = cam.ScreenToWorldPoint(Input.mousePosition);
        transform.position = rigidBody.position;
        previousPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        currentTrail = Instantiate(trailPrefab, transform);
    }


    // Disable slashing
    void StopSlashing()
    {
        // Consider player slash with specific slash type
        SlashType();
        if (cutType != 0)
        {
            player.Slash(cutType);
        }

        positions.Clear();
        isSlashing = false;
        currentTrail.transform.SetParent(null);
        Destroy(currentTrail, .5f);
    }


    // Determines the slash type
    void SlashType()
    {
        float xMagnitude = positions[positions.Count - 1].x - positions[0].x;
        float yMagnitude = positions[positions.Count - 1].y - positions[0].y;

        // Check if slash magnitude is sufficient
        if (minSlashMagnitude < Mathf.Abs(xMagnitude) || minSlashMagnitude < Mathf.Abs(yMagnitude))
        {
            // Check if slash is horizontal
            if (Mathf.Abs(yMagnitude) < 1)
            {
                cutType = 1;
            }
            // Checks if slash is vertical
            else if ((Mathf.Abs(xMagnitude) < 1))
            {
                cutType = 2;
            }
            // Checks if slash is diagonal
            else
            {
                // Checks if slash is diagonal left
                if ((xMagnitude < 0 && yMagnitude < 0) || (0 < xMagnitude && 0 < yMagnitude))
                {
                    cutType = 3;
                }
                // Checks if slash is diagonal right
                else
                {
                    cutType = 4;
                }
            }
        }
        else
        {
            cutType = 0;
        }
    }
}