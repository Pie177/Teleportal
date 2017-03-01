using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_CarryableSpawner : MonoBehaviour {

	public List<GameObject> spawnedObjects = new List<GameObject>();
	public GameObject toSpawn;
	public float timeToSpawn;
	public float despawnTime;
	public bool startImmediate = false;

	private bool canSpawn;

	// Use this for initialization
	void Start () 
	{
        //call the spawnobject method every timetospawn seconds
        InvokeRepeating("SpawnObj", timeToSpawn, timeToSpawn);
	}
	
	void SpawnObj () 
	{
        //set canSpawn to true
        canSpawn = true;
        //loop through all objects in the list
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            //object null?
            if (spawnedObjects[i] == null)
            {
                //remove object from list, decrease i
                spawnedObjects.Remove(spawnedObjects[i]);
                i--;
            }
        }
        //loop through all objects in the list
        for (int i = 0; i < spawnedObjects.Count; i++)
        {
            //check the distance of the object spawned
            float distaceObjs = Vector3.Distance(transform.position, spawnedObjects[i].transform.position);
            //object close?
            if (distaceObjs < 2)
            {
                //set canSpawn to false and stop loop
                canSpawn = false;
                break;
            }
        }
        if(canSpawn)
        {
            //creat appropriate obj
            GameObject tempObj = Instantiate(toSpawn, transform.position, Quaternion.identity);

            //add to list
            spawnedObjects.Add(tempObj);

            //should obj despawn?
            if (despawnTime >= 0)
            {
                //should despawn timer start?
                if (startImmediate == true)
                {
                    //destroy after time
                    Destroy(tempObj, despawnTime);
                }
                else
                {
                    //tell carryable objects when to despawn
                    tempObj.GetComponent<Object_Carryable>().despawnTime = despawnTime;
                }
            }
        }

  	}

	void OnTriggerEnter(Collider other)
	{
		
	}

	void OnTriggerExit(Collider other)
	{
		
	}
}
