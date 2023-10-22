using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

//resource: https://www.youtube.com/watch?v=_QajrabyTJc&ab_channel=Brackeys remove later
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    public float speed = 12f;
    public float gravity = -19.0f;
    public float jumpHeight = 3.0f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity; //keeps track of the velocity of the player
    bool isOnGround;

    // Update is called once per frame
    void Update()
    {

        //Make a sphere that checks to see if the player is making contact with the ground
        isOnGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isOnGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x =  Input.GetAxis("Horizontal");
        float z =  Input.GetAxis("Vertical");
        
        // create a transformation vector to move the player
        Vector3 move = transform.right * x + transform.forward * z;
        
        // move the player
        controller.Move(move * speed * Time.deltaTime); // deltaTime makes it frame rate independent

        if(Input.GetButtonDown("Jump") && isOnGround)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        //update the velocity to be effected by gravity
        velocity.y += gravity * Time.deltaTime; 

        //apply gravity changes
        controller.Move(velocity * Time.deltaTime);
    }
}
