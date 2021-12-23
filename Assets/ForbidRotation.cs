using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForbidRotation : MonoBehaviour
{
	public GameObject FollowCam;
	
	private void FixedUpdate()
	{
		FollowCam.transform.rotation = Quaternion.identity.normalized;
	}
}
