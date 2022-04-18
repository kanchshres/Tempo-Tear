using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    // Music Variables
    public AudioSource audioSource;
    public float startTime;
    public float endTime;
    public float pauseTime;

    // Level Variables
    public static int level;
    public bool previousState = false;

    // Start is called before the first frame update
    void Start()
    {
        // Setup Music
        audioSource.time = startTime;
        audioSource.Play();

        // Reset score
        ScoreSetter.score = 0;
        ScoreSetter.multiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if current game state is paused
        if (PauseMenu.GameIsPaused && PauseMenu.GameIsPaused != previousState)
        {
            pauseTime = audioSource.time;
            audioSource.Stop();
            previousState = PauseMenu.GameIsPaused;
        }
        // Check if current game state is unpaused
        else if (!PauseMenu.GameIsPaused && PauseMenu.GameIsPaused != previousState)
        {
            audioSource.Play();
            audioSource.time = pauseTime;
            previousState = PauseMenu.GameIsPaused;
        }

        // Check if level is completed
        if (audioSource.time > endTime)
        {
            audioSource.Stop();
            LevelOver.win = true;
            SceneManager.LoadScene("LevelOver");
        }

        // Check what level is currently being played
        if (SceneManager.GetActiveScene().name == "Level01")
        {
            level = 1;
        }
        else if (SceneManager.GetActiveScene().name == "Level02")
        {
            level = 2;
        }
        else if (SceneManager.GetActiveScene().name == "Level03")
        {
            level = 3;
        }
        else
        {
            level = 0;
        }
    }
}
