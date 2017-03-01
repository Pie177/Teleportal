using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_Platform_Move : MonoBehaviour {

	public float moveSpeed;
	public Vector3 direction;
	public float travelDistance;

	private Vector3 startPos;
	private Vector3 posOne;
	private Vector3 posTwo;
	private float startTime;
	private bool goingToOne = true;

	// Use this for initialization
	void Start () 
	{
        //set start time to current time
        startTime = Time.time;
        //set start pos to current pos
        startPos = transform.position;
        //set posOne to startPost + direction* travelDistance
        posOne = startPos + direction * travelDistance;
        //set posOne to startPost - direction* travelDistance
        posTwo = startPos - direction * travelDistance;
	}
	
	// Update is called once per frame
	void Update () 
	{
        //calculate how far obj has traveled
        float disCovered = (Time.time - startTime) * moveSpeed;

        //calc what % through the journy
        float fracJourney = disCovered / travelDistance;

        //100%?
        if (fracJourney > 1)
        {
            //toggle goingToOne
            goingToOne = !goingToOne;
            //set startTime to current time
            startTime = Time.time;
            //set % through journey to 0
            disCovered = 0f;
            fracJourney = 0f;
        }
        //going to loc one?
        if (goingToOne)
        {
            //move smoothly to posOne
            transform.position = Vector3.Lerp(posTwo, posOne, fracJourney);
        }
        else
        {
            //move smoothly to posTwo
            transform.position = Vector3.Lerp(posOne, posTwo, fracJourney);
        }
	}

	void OnDrawGizmos()
	{
        //set color to red
        Gizmos.color = Color.red;
        //is startPos 0
        if (startPos == Vector3.zero)
        {
            //draw line from current position += direction * distance
            Gizmos.DrawLine(transform.position, transform.position + direction * travelDistance);
            Gizmos.DrawLine(transform.position, transform.position - direction * travelDistance);
        }
        else
        {
            //draw line from start position += direction * distance
            Gizmos.DrawLine(startPos, startPos + direction * travelDistance);
            Gizmos.DrawLine(startPos, startPos - direction * travelDistance);
        }
    }
}
