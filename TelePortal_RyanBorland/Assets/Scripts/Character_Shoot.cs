using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_Shoot : MonoBehaviour {

	public GameObject teleportBall;
	public float shootForce = 10f;

	// Update is called once per frame
	void Update () {
		//press RMB?
		if(Input.GetMouseButtonDown(0))
		{
			//creat a ray that goes from camera position in the direction the camera is facing
			Ray rayOrigin = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

			// create new teleport ball
			GameObject tempBall = Instantiate(teleportBall, rayOrigin.origin, Quaternion.identity);

			// tell it to ignore player collider
			Physics.IgnoreCollision(tempBall.GetComponent<Collider>(), GetComponent<CharacterController>());

			//add impulse force to the ball, in the directino the camera is facing with added force
			tempBall.GetComponent<Rigidbody>().AddRelativeForce(rayOrigin.direction * shootForce, ForceMode.Impulse);

			//pass the player reference to the ball's teleport script
			tempBall.GetComponent<TeleportBall_TeleportPlayer>().player = this.gameObject;
		}
	}
}
