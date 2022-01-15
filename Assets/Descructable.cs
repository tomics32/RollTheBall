using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Descructable : MonoBehaviour
{
	public GameObject destroyedVersion;

		
	private void OnTriggerEnter(Collider other)
	{
		Instantiate(destroyedVersion, transform.position, transform.rotation);
		Destroy(gameObject);
	}

}
