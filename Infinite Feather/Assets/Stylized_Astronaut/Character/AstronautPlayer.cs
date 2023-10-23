using UnityEngine;
using System.Collections;

namespace AstronautPlayer
{

	public class AstronautPlayer : MonoBehaviour {

		private Animator anim;
		private CharacterController controller;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		public float gravity = -20.0f;
        public float jumpHeight = 3.0f;
        
        Vector3 velocity; //keeps track of the velocity of the player
        
        //debugging
        public bool isOnGround;

        void Start () {
			controller = GetComponent <CharacterController>();
			anim = gameObject.GetComponentInChildren<Animator>();
		}

        void Update (){
    
	        //If the player is on the ground, reset the velocity
	        if (controller.isGrounded && velocity.y < 0)
	        {
		        velocity.y = -2f;
	        }

	        isOnGround = controller.isGrounded;  // Update debug variable
    
	        Vector3 moveDirection = Vector3.zero;
	        moveDirection = transform.forward * (Input.GetAxis("Vertical") * speed);
    
	        // Combine vertical and gravity movement
	        velocity.y += gravity * Time.deltaTime;
	        moveDirection.y = velocity.y;
    
	        controller.Move(moveDirection * Time.deltaTime);  // Single move call

	        // Check if grounded right after the move call to update status for the next frame
	        isOnGround = controller.isGrounded;  
    
	        if (Input.GetKey("w")) {
		        anim.SetInteger("AnimationPar", 1);
	        } else {
		        anim.SetInteger("AnimationPar", 0);
	        }

	        float turn = Input.GetAxis("Horizontal");
	        transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);

	        // Perform jump after the move to ensure isGrounded is updated
	        if (Input.GetButtonDown("Jump") && controller.isGrounded)
	        {
		        print("JUMPED!!!");
		        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
	        }
        }

	}
}
