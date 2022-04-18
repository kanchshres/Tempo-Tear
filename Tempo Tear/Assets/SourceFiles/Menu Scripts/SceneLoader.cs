using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // Transition Variables
    public Animator transition;
    public float transitionTime = 1f;


    // Starts transition
    public void LoadSelectedScene(string scene)
    {
        StartCoroutine(LoadScene(scene));
    }


    // Loads the new scene
    IEnumerator LoadScene(string scene)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(scene);
    }
}
