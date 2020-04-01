﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Script for navigating between scenes
// References : https://answers.unity.com/questions/994033/how-do-i-create-a-exitquit-button.html - quit application
public class MainMenu : MonoBehaviour
{
    public GameObject tipMenu;
    public GameObject mainMenu;

    public void MainGame()
    {
        // Load main game
        SceneManager.LoadScene("StarterScene");
    }

    public void QuitGame()
    {
        // load menu
        SceneManager.LoadScene("MainMenuScene");
    }

    public void ExitGame()
    {
        // quit application
        Application.Quit();
        Debug.Log("Quitting game");
    }

    public void ToTipMenu()
    {
        tipMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void ToMainMenu()
    {
        tipMenu.SetActive(false);
        mainMenu.SetActive(true);
    }
}
