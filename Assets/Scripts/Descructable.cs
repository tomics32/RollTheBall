using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Descructable : MonoBehaviour
{
	
	public GameObject destroyedVersion;
	float volume = 0.4f;

	
	

	
	void Start()
	{
		
	}

	private void OnTriggerEnter(Collider other)
	{
		gameObject.GetComponent<MeshRenderer>().enabled = false;
		gameObject.GetComponent<MeshCollider>().enabled = false;
		gameObject.GetComponent<Animator>().enabled = false;


		gameObject.GetComponent<AudioSource>().Play();
		Instantiate(destroyedVersion, transform.position, transform.rotation);
		
	}

}
