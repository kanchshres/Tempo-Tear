using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // PlayGame is called once the 'PlayButton' is pressed
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    // QuitGame is called once the 'ExitButton' is pressed
    public void ExitGame()
    {
        Application.Quit();
    }
}