using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Object_Portal_ChangeScenes : MonoBehaviour {

	public string sceneToLoad;

	void OnTriggerEnter (Collider other)
    {
        if (other.CompareTag("Player"))
        {
            //tell scene manager to load sceneToLoad
            SceneManager.LoadScene(sceneToLoad);
        }
	}
}
