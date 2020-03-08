using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for the NPC interaction
// Reference : https://gamedev.stackexchange.com/questions/146544/help-with-ontriggerentered-canvas-ui



public class NPCScript : MonoBehaviour
{

    PlayerHealthScript teleport;
    public GameObject dialogBox;
    public GameObject player;
    public GameObject movePlayer;

    public bool active = false;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        movePlayer = GameObject.FindWithTag("Respawn2");
    }

    
    void Update()
    {
        if (active == true)
        {

            if (Input.GetKeyDown(KeyCode.Y))
            {
                Debug.Log("Moving");
                Move();
                active = false;

            }
            
        }
    }

     void OnTriggerEnter (Collider col)   
    {

        if (col.gameObject.tag == "Player")
        { 
            Debug.Log("Player interacted");
            dialogBox.SetActive(true);
            active = true;
           
        }
    }

    void OnTriggerExit(Collider col)
    {

        if (col.gameObject.tag == "Player")
        {
            Debug.Log("Player stopped interacting");
            dialogBox.SetActive(false);
        }
    }

    public void Move()
    {
        
        player.transform.rotation = movePlayer.transform.rotation;
        player.transform.position = movePlayer.transform.position;
    }
}
