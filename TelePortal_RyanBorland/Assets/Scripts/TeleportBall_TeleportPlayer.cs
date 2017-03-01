using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportBall_TeleportPlayer : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () 
	{
		//destroy this object after three seconds
		Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision other) 
	{
		//collided with a wall?
		if(other.transform.CompareTag("Wall"))
		{
			//teleport player to current position + 1 unit infront of where the collision happened
			player.transform.position = transform.position + other.contacts[0].normal * 1f; 
		}
		//Destory this object
		Destroy(gameObject);
	}
}
