using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Menu : MonoBehaviour
{
    // Resolution Variables
    public TMPro.TMP_Dropdown resolutionsDropdown;
    Resolution[] screenResolutions;
    List<int> resolutionIndexes = new List<int>();

    // Graphic Variables
    public TMPro.TMP_Dropdown graphicsDropdown;

    // Audio Variables
    public AudioMixer audioMixer;

    // SceneLoader Variables
    public GameObject sceneLoader;

    // Initialization
    void Start()
    {
        // Resolutions setup
        screenResolutions = Screen.resolutions;
        resolutionsDropdown.ClearOptions();
        List<string> options = new List<string>();
        int count = 0;
        int currentResolutionIndex = 0;

        for (int i = 0; i < screenResolutions.Length; i++)
        {
            if (screenResolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                string option = screenResolutions[i].width + " x " + screenResolutions[i].height;
                options.Add(option);
                resolutionIndexes.Add(i);

                if (screenResolutions[i].width == Screen.currentResolution.width && 
                    screenResolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = count;
                }
                count++;
            }
        }

        resolutionsDropdown.AddOptions(options);
        resolutionsDropdown.value = currentResolutionIndex;
        resolutionsDropdown.RefreshShownValue();

        // Graphics setup
        QualitySettings.SetQualityLevel(2);
        graphicsDropdown.RefreshShownValue();
    }


    // Moves to the scene selected 
    public void playGame(string level)
    {
        sceneLoader.GetComponent<SceneLoader>().LoadSelectedScene(level);
    }


    // Moes to the "LevelSelect" scene
    public void play()
    {
        SceneManager.LoadScene("LevelSelect");
    }


    // Set game resolution
    public void setResolution(int resolutionIndex)
    {
        resolutionIndex = (int) resolutionIndexes[resolutionIndex];
        Resolution resolution = screenResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }


    // Toggle fullscreen mode
    public void setFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }


    // Set graphics quality
    public void setQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }


    // Set volumes
    public void setMasterVolume(float volume)
    {
        audioMixer.SetFloat("MasterVolume", volume);
    }
    public void setMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }
    public void setEffectsVolume(float volume)
    {
        audioMixer.SetFloat("EffectsVolume", volume);
    }


    // Quits application
    public void exitGame()
    {
        Application.Quit();
    }
}