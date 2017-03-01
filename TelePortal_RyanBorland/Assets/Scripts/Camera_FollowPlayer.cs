using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_FollowPlayer : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () 
	{
		//set offest to the difference in camera position to the player position
		offset = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () 
	{
		//set position to players position + offset
		transform.position = player.transform.position + offset;
	}
}
