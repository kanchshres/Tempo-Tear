using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    // Pause Variables
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // SceneLoader Variables
    public GameObject sceneLoader;


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
        GameIsPaused = false;
        Time.timeScale = 1f;
        pauseMenuUI.SetActive(false);
    }


    // Pauses game and ceases play state
    void Pause()
    {
        GameIsPaused = true;
        Time.timeScale = 0f;
        pauseMenuUI.SetActive(true);
    }


    // Restarts the current level
    public void Retry()
    {
        if (Level.level == 1)
        {
            //sceneLoader.GetComponent<SceneLoader>().LoadSelectedScene("level01");
            SceneManager.LoadScene("level01");
        }
        else if (Level.level == 2)
        {
            //sceneLoader.GetComponent<SceneLoader>().LoadSelectedScene("level02");
            SceneManager.LoadScene("level02");
        }
        else if (Level.level == 3)
        {
            //sceneLoader.GetComponent<SceneLoader>().LoadSelectedScene("level03");
            SceneManager.LoadScene("level03");
        }
        Resume();
    }


    // Exits the level to main menu
    public void QuitLevel()
    {
        //sceneLoader.GetComponent<SceneLoader>().LoadSelectedScene("Menu");
        SceneManager.LoadScene("Menu");
        Resume();
    }
}
