using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Variable for HealthBar
    public Slider slider;
    public GameObject fullHeart;
    public GameObject emptyHeart;


    // Sets player's max health
    public void SetMaxHealth(int health)
    {
        fullHeart.SetActive(true);
        emptyHeart.SetActive(false);

        slider.maxValue = health;
        slider.value = health;
    }

    // Sets player's health
    public void SetHealth (int health)
    {
        slider.value = health;
        if (slider.value <= 0)
        {
            fullHeart.SetActive(false);
            emptyHeart.SetActive(true);
        }
    }
}
