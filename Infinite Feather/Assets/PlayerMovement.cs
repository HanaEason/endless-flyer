using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//resource: https://www.youtube.com/watch?v=_QajrabyTJc&ab_channel=Brackeys remove later
public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    
    public float speed = 12f;

    // Update is called once per frame
    void Update()
    {
        float x =  Input.GetAxis("Horizontal");
        float z =  Input.GetAxis("Vertical");
        
        // create a transformation vector to move the player
        Vector3 move = transform.right * x + transform.forward * z;
        
        // move the player
        controller.Move(move * speed * Time.deltaTime); // deltaTime makes it frame rate independent
    }
}
