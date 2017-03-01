using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character_CarryObject : MonoBehaviour {

	public float distance;
	public float smooth;
	public LayerMask playerLayer;
	public GameObject mainCamera;

	private bool isCarrying;
	private GameObject carriedObject;

	// Use this for initialization
	void Start () 
	{
		//set the camera variable to stor the main camera
		mainCamera = Camera.main.gameObject;
	}
	
	// Update is called once per frame
	void Update () 
	{
		//is the player carrying anything
		if (isCarrying == true) {
			//Carry(carriedObject)
			Carry (carriedObject);
			CheckDrop ();
		} 
		else 
		{
			//Pickup
			Pickup ();
		}
		//drawpickup
		DrawPickup();
	}

	void RotateObject()
	{
		//rotate to 5, 10, 5
	}

	void Carry(GameObject objToCarry)
	{
		//is object null
		if(objToCarry == null)
		{
			//set is carrying to false and leave
			isCarrying = false;
			return;
		}

		//set position of object to infront of the camera and smooth the movement
		objToCarry.transform.position = Vector3.Lerp(objToCarry.transform.position, (mainCamera.transform.position + mainCamera.transform.forward * distance ), Time.deltaTime * smooth);
		//set rotation of the object to quaternion identiy
		objToCarry.transform.rotation = Quaternion.identity;
	}

	void Pickup()
	{
		//was e pressed
		if (Input.GetKeyDown (KeyCode.E)) {
			//creat ray starting at camera
			Ray ray = new Ray (mainCamera.transform.position, mainCamera.transform.forward);
			//creat a raycasthit to store the info
			RaycastHit hit;
		
			//did we hit an object
			if (Physics.Raycast (ray, out hit, 10, ~playerLayer)) 
			{
				if (hit.transform.CompareTag ("Carryable") == true) {
					//set is carrying to true, assign the object carried to carriedObject
					isCarrying = true;
					carriedObject = hit.transform.gameObject;
					//turn off gravity
					hit.transform.GetComponent<Rigidbody> ().useGravity = false;
					//start timer on the Object_Carryable component
					hit.transform.GetComponent<Object_Carryable> ().StartTimer ();
				}
			}
		}
	}

	void CheckDrop()
	{
		//was e pressed
		if(Input.GetKeyDown(KeyCode.E))
		{
			//drop object
			DropObject ();
		}
	}

	void DropObject()
	{
		//set iscarying to false
		isCarrying = false;
		//turn gravity on for the object
		carriedObject.GetComponent<Rigidbody>().useGravity = true;
		//set carried object to null
		carriedObject = null;
	}

	void DrawPickup()
	{
		//create a ray
		Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);
		//create a raycasthit to store info
		RaycastHit hit;
		//did we hit and object
		if (Physics.Raycast (ray, out hit, 10, ~playerLayer)) {
			//did we hit a carryable object
			if (hit.transform.CompareTag ("Carryable") == true) {
				//draw green ray
				Debug.DrawRay (ray.origin, ray.direction * 10f, Color.green);
			} 
			else 
			{
				//draw yellow ray
				Debug.DrawRay (ray.origin, ray.direction * 10f, Color.yellow);
			}
		} 
		else 
		{
			//draw a red ray
			Debug.DrawRay (ray.origin, ray.direction * 10f, Color.red);
		}
	}
}
