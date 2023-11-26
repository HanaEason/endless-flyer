using UnityEngine;

namespace Stylized_Astronaut.Character
{

	public class AstronautPlayer : MonoBehaviour {

		private Animator _anim;
		private CharacterController _controller;

		private CameraSwitcher _cameraSwitcher;

		public float speed = 600.0f;
		public float turnSpeed = 400.0f;
		public float gravity = -20.0f;
        public float jumpHeight = 3.0f;
        
        Vector3 velocity; //keeps track of the velocity of the player
        
        //debugging
        public bool isOnGround;
        private static readonly int AnimationPar = Animator.StringToHash("AnimationPar");

        void Start () {
			if (_cameraSwitcher == null)
			{
				_cameraSwitcher = FindObjectOfType<CameraSwitcher>();
			}
			_controller = GetComponent <CharacterController>();
			_anim = gameObject.GetComponentInChildren<Animator>();
		}

        void Update (){
    
	        if (PauseManager.IsPaused)
	        {
		        return;
	        }
	        
	        //If the player is on the ground, reset the velocity
	        if (_controller.isGrounded && velocity.y < 0)
	        {
		        velocity.y = -2f;
	        }

	        isOnGround = _controller.isGrounded;  // Update debug variable
    
	        Vector3 moveDirection = Vector3.zero;
			float horizontal = Input.GetAxis("Horizontal");
			float vertical = Input.GetAxis("Vertical");
			moveDirection = transform.forward * vertical;

            if (_cameraSwitcher.isFirstPerson)
            {
				moveDirection += (transform.right * horizontal);
            }

            //apply the speed onto the movmenet
            moveDirection *= speed;
    
	        // Combine vertical and gravity movement
	        velocity.y += gravity * Time.deltaTime;
	        moveDirection.y = velocity.y;
    
	        _controller.Move(moveDirection * Time.deltaTime);

	        // Check if grounded right after the move call to update status for the next frame
	        isOnGround = _controller.isGrounded;  
    
	        if (Input.GetKey("w")) {
		        _anim.SetInteger(AnimationPar, 1);
	        } else {
		        _anim.SetInteger(AnimationPar, 0);
	        }

			//only if the player is in third person, rotate when there is horizontal movement
			if (!_cameraSwitcher.isFirstPerson)
			{
                transform.Rotate(0, horizontal * turnSpeed * Time.deltaTime, 0);
            }

	        // Perform jump after the move to ensure isGrounded is updated
	        if (Input.GetButtonDown("Jump") && _controller.isGrounded && !PauseManager.IsPaused)
	        {
		        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
	        }
        }

	}
}
