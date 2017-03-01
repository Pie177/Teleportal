using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Button_Press : MonoBehaviour {

	public GameObject doorToOpen;
	public Animator anim;
	public bool stayOpen;
	public PickupType type;

	private bool pressed = false;
	private GameObject myObj;

	// Update is called once per frame
	void Update () 
	{
		//is button pressed
		if(pressed == true)
		{
			//is object nul
			if(myObj == null)
			{
				//toggledoor
				ToggleDoor();
			}
		}
	}

	void ToggleDoor()
	{
        //set off the trigger named toggle on door animator
        doorToOpen.GetComponent<Animator>().SetTrigger("toggle");
		//set off the trigger named press on door animator
		anim.SetTrigger("press");
		//toggle the pressed variable
		pressed = !pressed;
	}

	void OnTriggerEnter(Collider other)
	{
        //did collide with carrayble
        if (other.CompareTag("Carryable") == true)
        {
            //do we have a pickup
            if (type != PickupType.NONE)
            {
                //is the other object the correct type
                if (other.GetComponent<Object_Carryable>().type == type)
                {
                    //set myobj to the thing collied with, toggledoor
                    myObj = other.gameObject;
                    ToggleDoor();
                }
            }
            else
            {
                //set myobj to the thing collied with, toggledoor
                myObj = other.gameObject;
                ToggleDoor();
            }
        }

        //did collide with player
        if (other.CompareTag("Player"))
        {
            //set myobj to the thing collied with, toggledoor
            myObj = other.gameObject;
            ToggleDoor();
        }
	}

	void OnTriggerExit(Collider other)
	{
		//we shouldn't stay open correct
		if(stayOpen == false)
		{
			//do we have a type and Player didn't step on us
			if (type != PickupType.NONE && other.CompareTag ("Player") == false && other.CompareTag("Untagged") == false)
            {
                //did the thing that left us have our type
                if (other.GetComponent<Object_Carryable> ().type == type) {
					//set myobj to null, toggledoor
					myObj = null;
					ToggleDoor ();
				}
			} 
			else if(other.CompareTag("Untagged") == false)
			{
				//set myobj to null, toggledoor
				myObj = null;
				ToggleDoor ();
			}

			if (other.CompareTag ("Player")) 
			{
				myObj = null;
				ToggleDoor ();
			}
		}
	}
}
