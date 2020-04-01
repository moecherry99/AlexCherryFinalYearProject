using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // UI reference

// Script for the Health Bar Functionality
// Reference : https://www.youtube.com/watch?v=BLfNP4Sc_iA

public class EnemyHealthScript : MonoBehaviour
{
    // slider reference
    public Slider slider;
    public PlayerHealthScript max;
    public static float maxHp;
    public Test max1;
    void Start()
    {
       // max1 = GetComponent<Test>();
        // not sure if this is necessary, but it works
       // maxHp = max1.maxHealth;
    }

    public void Update()
    {
        // added to accommodate for health changing after leveling up
        if (maxHp >= slider.maxValue)
        {
            slider.maxValue = maxHp;
            SetHealth(max1.currentHealth);
            SetMaxHealth(max1.maxHealth);
        }
    }

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
