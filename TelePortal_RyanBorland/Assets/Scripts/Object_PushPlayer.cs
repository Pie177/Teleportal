using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_PushPlayer : MonoBehaviour {

	public Vector3 forceDirection;
	public float pushSpeed;

	void OnTriggerEnter(Collider other)
	{
		//collide with player?
		if (other.CompareTag ("Player")) 
		{
            //turn off player gravity
            //character move, usegravity
            other.GetComponent<Character_Move>().useGravity = false;
        }

    }

	void OnTriggerStay(Collider other)
	{
		//collide with player?
        if(other.CompareTag("Player"))
        {
            //move player in force direction, accountinf for pushSpeed and frame rate independence
            other.GetComponent<CharacterController>().Move(forceDirection * pushSpeed * Time.deltaTime);
        }
    }

	void OnTriggerExit(Collider other)
	{
        //collide with player?
        if (other.CompareTag("Player"))
        {
            //turn on player gravity
            //character move, usegravity
            other.GetComponent<Character_Move>().useGravity = true;
        }
    }

	void OnDrawGizmos()
	{
        //set color to cyan
        Gizmos.color = Color.cyan;
        //draw ray from current position
        Gizmos.DrawRay(transform.position, forceDirection);
	}
}
