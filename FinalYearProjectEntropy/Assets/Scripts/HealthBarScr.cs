﻿using System.Collections;
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
    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    // value of slider is the health of the player
    public void SetHealth(float health)
    {
        slider.value = health;
    }

    
}
