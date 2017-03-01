using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_DangerousWall : MonoBehaviour {

	public Transform respawnPos;
	public Vector3 direction;
	public float speed;

	private Vector3 startPos;

	// Use this for initialization
	void Start () {
        //set start position to current position
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //move in directiong factoring frame rate and speed
        transform.Translate(direction * Time.deltaTime * speed);
	}

	void OnTriggerEnter(Collider other)
	{
        //collide with player
        if (other.CompareTag("Player"))
        {
            //set player position to respawnpos, set my position to start pos
            other.transform.position = respawnPos.position;
            transform.position = startPos;
        }
	}
}
