using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the Character Stats page
// Reference : https://www.youtube.com/watch?v=aN11LnlF89I
public class MenuManager : MonoBehaviour
{

    // game object options menu
    public GameObject optionsMenu;

    // referencing player health 
    public PlayerHealthScript playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if press C
        if(Input.GetKeyDown(KeyCode.C))
        {
            // always sets to opposite (true or false)
            optionsMenu.gameObject.SetActive(!optionsMenu.gameObject.activeSelf);
        }
        
    }
}
