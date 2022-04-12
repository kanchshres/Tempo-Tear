using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    // Moves to the scene selected 
    public void playGame(string level)
    {
        SceneManager.LoadScene(level);
    }

    public void backTo()
    {
        SceneManager.LoadScene("Menu");
    }
}
