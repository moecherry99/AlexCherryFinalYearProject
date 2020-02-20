using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI reference

// Script for the Health Bar Functionality
// Reference : https://www.youtube.com/watch?v=BLfNP4Sc_iA

public class HealthBarScr : MonoBehaviour
{
    // slider reference
    public Slider slider;
    
    // set max health on slider to full value
    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // value of slider is the health of the player
    public void SetHealth(int health)
    {
        slider.value = health;
    }

    
}
