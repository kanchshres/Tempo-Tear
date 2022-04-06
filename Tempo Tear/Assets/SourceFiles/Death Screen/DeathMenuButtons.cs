using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class DeathMenuButtons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // Moves to the "Level 1" scene
    public void retry()
    {
        SceneManager.LoadScene("Level01");
    }

    // Moves to the main menu scene
    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
