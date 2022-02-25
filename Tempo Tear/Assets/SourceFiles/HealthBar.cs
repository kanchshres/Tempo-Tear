using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    // Variable for HealthBar
    public Slider slider;

    // Sets player's max health
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // Sets player's health
    public void SetHealth (int health)
    {
        slider.value = health;
    }
}
