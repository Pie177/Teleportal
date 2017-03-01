using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
	NONE,
	GREEN,
	BLUE,
	RED,
	YELLOW
}

public class Object_Carryable : MonoBehaviour {

	public PickupType type;
	public float despawnTime;

	public void StartTimer () 
	{
		//is there a despawn time?
		if (despawnTime >= 0) 
		{
			//destroy object 
			Destroy (this.gameObject, despawnTime);
		}
	}

}
