using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeatIndicator : MonoBehaviour
{
    // Varibales needed
    public Slider slider;
    public EnemySpawn enemySpawnRef;
    private float startTime;
    private float endTime;
    private int sliderVal;

    // Start is called before the first frame update
    void Start()
    {
        slider.value = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if game is in unpaused state
       if (!PauseMenu.GameIsPaused)
        {
            slider.value += 0.0017f;
            sliderVal = (int)slider.value;
            if (sliderVal == 1)
            {
                slider.value = 0;
            }
        }
    }
}