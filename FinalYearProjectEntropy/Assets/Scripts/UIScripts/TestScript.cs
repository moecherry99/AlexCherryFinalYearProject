using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }
}
