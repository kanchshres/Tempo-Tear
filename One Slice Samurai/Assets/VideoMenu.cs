using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VideoMenu : MonoBehaviour
{
    // Variables
    Resolution[] resolutions;
    public TMPro.TMP_Dropdown resolutionDropdown;
    public TMPro.TMP_Dropdown graphicDropdown;

    // Start is called before the first frame update
    void Start()
    {
        // SetUp for 'ResolutionDropdown'
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int dropdownIndex = -1;
        int currentResolutionIndex = 0;

        for (int i = 0; i < resolutions.Length; i++)
        {
            if (resolutions[i].refreshRate == Screen.currentResolution.refreshRate)
            {
                string option = resolutions[i].width + " x " + resolutions[i].height;
                options.Add(option);
                dropdownIndex++;

                if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
                {
                    currentResolutionIndex = dropdownIndex;
                }
                Debug.Log("i:" + i);
                Debug.Log("dropdownindex:" + dropdownIndex);
                Debug.Log("currentresolutionindex: " + currentResolutionIndex);
            }

            
        } 
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        // SetUp for 'GraphicDropdown'
        /* INSERT */
    }

    // SetQuality is called when the 'ResolutionDropdown' is used
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, 
                                               Screen.fullScreen);
    }

    // SetQuality is called when the 'GraphicDropdown' is used
    public void SetQuality (int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    // SetFullscreen is called when the 'FullscreenToggle' is used
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}