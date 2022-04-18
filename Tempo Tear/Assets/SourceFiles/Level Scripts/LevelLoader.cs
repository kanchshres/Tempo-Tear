using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Transition Variables
    public Animator transition;
    public float transitionTime = 1f;


    // Starts transition
    public void LoadSelectedLevel(string level)
    {
        StartCoroutine(LoadLevel(level));
    }


    // Loads the new scene
    IEnumerator LoadLevel(string level)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(level);
    }
}
