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

    // SceneLoader Variables
    public GameObject sceneLoader;

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
        finalScore.SetText("FINAL SCORE\n" + score.ToString());
    }

    // Moves to the scene that was just played
    public void retry()
    {
        if (Level.level == 1)
        {
            sceneLoader.GetComponent<SceneLoader>().LoadSelectedScene("level01");
            //SceneManager.LoadScene("level01");
        }
        else if (Level.level == 2)
        {
            sceneLoader.GetComponent<SceneLoader>().LoadSelectedScene("level02");
            //SceneManager.LoadScene("level02");
        }
        else if (Level.level == 3)
        {
            sceneLoader.GetComponent<SceneLoader>().LoadSelectedScene("level03");
            //SceneManager.LoadScene("level03");
        }

    }

    // Moves to the "LevelSelect" scene
    public void levelSelect()
    {
        sceneLoader.GetComponent<SceneLoader>().LoadSelectedScene("Menu");
        //SceneManager.LoadScene("Menu");
    }
}
