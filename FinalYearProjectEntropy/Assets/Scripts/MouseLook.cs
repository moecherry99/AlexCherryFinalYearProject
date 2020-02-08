using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Reference : https://www.youtube.com/watch?v=_QajrabyTJc&t=324s
// Script used for looking around with the first person character
public class MouseLook : MonoBehaviour
{

    // Change speed of sensitivity
    public float mouseSensitivity = 100f;

    public Transform playerBody;

    float xRotation = 0f;
    // Start is called before the first frame update
    void Start()
    {
        // Locks Cursor to middle of screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
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
