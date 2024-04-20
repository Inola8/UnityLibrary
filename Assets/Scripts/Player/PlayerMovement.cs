using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    private float speed = 10f;
    private float dashSpeed = 5f;
    private float gravity = -18f;
    private float jumpHeight = 3f;

    public Transform groundCheck;
    private float groundDistance = 0.4f;
    public LayerMask groundMask;

    private bool isGrounded;
    Vector3 velocity;


    void Update()
    {
        Movement();
        Dash();
        Jumping();
    }

    private void Movement()
    {
        // Define the input values
        float xMove = Input.GetAxis("Horizontal");
        float zMove = Input.GetAxis("Vertical");

        // Make Vector3 for moving in all directions
        Vector3 movement = transform.right * xMove + transform.forward * zMove;
        controller.Move(movement * speed * Time.deltaTime);
    }

    private void Dash()
    {
        // When LeftShift is pressed, add dashing speed to the movement speed
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed += dashSpeed;
            Debug.Log("dash = " + speed);
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed -= dashSpeed;
            Debug.Log("dash = " + speed);
        }
    }

    private void Jumping() // And falling
    {
        // Make a groundcheck so the velocity wont buildup 
        // isGrounded is true when the player is standing on the ground (by checking if the groundCheck Transform is in contact with the groundMask)
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0f)
        {
            // Put it slightly under zero so the player will be forced on the ground
            velocity.y = -2f;
        }

        // Check if the jump key is pressed and if the player is standing on the ground, then apply jumping physics to the y velocity
        if (Input.GetButton("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // Add my own gravity to the velocity so falling will be more natural
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
