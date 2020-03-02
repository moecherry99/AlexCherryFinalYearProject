using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference : https://www.youtube.com/watch?v=_QajrabyTJc&t=324s
// https://answers.unity.com/questions/1227628/changing-camera-background-color.html - change camera background when on low health
// Script used for looking around with the first person character
public class MouseLook : MonoBehaviour
{

    public PlayerHealthScript currentHealth;
    public Color red = Color.red;
    public Color blue = Color.blue;
    Camera cam;

    // Change speed of sensitivity
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        // Locks Cursor to middle of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        // change colour of camera to alert player they are on low health
        if(PlayerHealthScript.currentHealth <= 100)
        {
            cam.backgroundColor = red;
        }
        else
        {
            cam.backgroundColor = blue;
        }

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // disables rotation to wrong side (locks on 180 degrees up and down)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // rotates when you move mouse
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }
}
