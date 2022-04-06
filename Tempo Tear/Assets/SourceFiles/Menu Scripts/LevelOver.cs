using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelOver : MonoBehaviour
{
    // Text Object
    public TMPro.TextMeshProUGUI textMeshH;
    private int score = ScoreSetter.score;


    // Initialization
    void Start()
    {
        // Display user's achieved score
        textMeshH.SetText("Final score - " + score.ToString());

        // Reset score
        ScoreSetter.score = 0;
        ScoreSetter.multiplier = 1;
    }

    // Moves to the scene that was just played
    public void retry()
    {
        if (Level.level == 1)
        {
            SceneManager.LoadScene("Level01");
        } 
        else if (Level.level == 2)
        {
            SceneManager.LoadScene("Level02");
        }
        else if (Level.level == 3)
        {
            SceneManager.LoadScene("Level03");
        }
            
    }

    // Moves to the "Menu" scene
    public void mainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
