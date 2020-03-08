using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Script for movement
// Reference : https://www.youtube.com/watch?v=_QajrabyTJc&t=324s

public class PlayerMovement : MonoBehaviour
{
    // character controller
    public CharacterController controller;

    // set speed/gravity/jump settings, can be done in editor if necessary
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 2.6f;

    // variables for ground check
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    // bool check for grounded (if land on ground layer, will allow to jump again
    bool isGrounded;
    Vector3 velocity;

    
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

        // multiply move speed by jump speed to get proper gravity options
        controller.Move(move * speed * Time.deltaTime);
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        // velocity
        controller.Move(velocity * Time.deltaTime);

    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("NPC"))
        {
            Debug.Log("Player interacted");
        }
    }

}
