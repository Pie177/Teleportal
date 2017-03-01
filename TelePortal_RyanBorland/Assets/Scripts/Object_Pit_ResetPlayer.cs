using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Pit_ResetPlayer : MonoBehaviour {

	public Transform respawnPos;

	// Use this for initialization
	void OnTriggerEnter (Collider other) 
	{
		//collide with player?
		if(other.CompareTag("Player"))
			{
				//set players position to respawn position
				other.transform.position = respawnPos.position;
			}
	}
}
