using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        // Check if the "ESC" key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Check if game is in paused state
            if (GameIsPaused)
            {
                Resume();
            }
            // Check if game is in unpaused state
            else
            {
                Pause();
            }
        }
    }


    // Unpauses game and resumes play state
    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        pauseMenuUI.SetActive(false);
    }


    // Pauses game and ceases play state
    void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        pauseMenuUI.SetActive(true);
    }


    // Restarts the current level
    public void Retry()
    {
        Resume();
        if (Level.level == 1)
        {
            SceneManager.LoadScene("level01");
        }
        else if (Level.level == 2)
        {
            SceneManager.LoadScene("level01");
        }
        else if (Level.level == 3)
        {
            SceneManager.LoadScene("level03");
        }
    }


    // Exits the level to main menu
    public void QuitLevel()
    {
        Resume();
        SceneManager.LoadScene("Menu");
    }
}
