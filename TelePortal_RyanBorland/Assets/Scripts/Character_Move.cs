using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Move : MonoBehaviour {

	public float walkSpeed = 6f;
	public float jumpSpeed = 4f;
	public float runSpeed = 12f;
	public float gravity = 9.8f;
	public bool useGravity = true;

	private Vector3 moveDirection = Vector3.zero;
	private CharacterController charController;

	// Use this for initialization
	void Start () 
	{
		//get the character controller
		charController = GetComponent<CharacterController> ();
		LockCursor ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		//is the character controller grounded?
		if(charController.isGrounded == true)
		{
			//set up movedirection with input from the horizontal and vertical axis
			moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

			//change the axis to local coordinates
			moveDirection = transform.TransformDirection(moveDirection);

			//apply speed
			moveDirection *= GetSpeed();

			//pressing jump?
			if(Input.GetButton("Jump"))
			{
				//add jump speed to moveDirection.y
				moveDirection.y += jumpSpeed;
			}
		}	
		//is char using gravity?
		if(useGravity == true)
		{
			//subtract gravity from movedirection.y accounting for frame rate independence
			moveDirection.y -= gravity * Time.deltaTime;
		}
		//call move method on character controller
		charController.Move(moveDirection * Time.deltaTime);

		//player pressing esc?
		if (Input.GetKeyDown (KeyCode.Escape)) 
		{
			//LockCursor()
			LockCursor();
		}
	}

	float GetSpeed()
	{
		//player pressing left shift?
		if (Input.GetKey (KeyCode.LeftShift) == true) 
		{
			//return runSpeed
			return runSpeed;
		}
		else
		{
			//return walkSpeed
			return walkSpeed;
		}
	}

	void LockCursor()
	{
		//is cursor locked
		if(Cursor.lockState == CursorLockMode.Locked)
		{
			//set it to not be locked
			Cursor.lockState = CursorLockMode.None;
		}
		else
		{
			//set it to locked
			Cursor.lockState = CursorLockMode.Locked;
		}
		//toggle cursor visibility
		Cursor.visible = !Cursor.visible;
	}
}
