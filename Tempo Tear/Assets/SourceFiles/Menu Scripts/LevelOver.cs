using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class LevelOver : MonoBehaviour
{
    // Score Variables
    public TMPro.TextMeshProUGUI finalScore;
    private int score = ScoreSetter.score;


    // Message Variables
    public GameObject winMessage;
    public GameObject loseMessage;
    public static bool win;


    // Initialization
    void Start()
    {
        // Check which message to display
        if (win == true)
        {
            winMessage.SetActive(true);
            loseMessage.SetActive(false);

        } else
        {
            loseMessage.SetActive(true);
            winMessage.SetActive(false);
        }

        // Display user's achieved score
        finalScore.SetText("Final score - " + score.ToString());
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

    // Moves to the "LevelSelect" scene
    public void levelSelect()
    {
        SceneManager.LoadScene("Menu");
    }
}
