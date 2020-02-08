using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for movement
// Reference : https://www.youtube.com/watch?v=_QajrabyTJc&t=324s

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    // set speed
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    // variables for ground check
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;



    bool isGrounded;
    Vector3 velocity;

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // ground check to reset velocity
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        // creates movement based on direction you are facing with mouse look script
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;


        controller.Move(move * speed * Time.deltaTime);
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);

    }
}
