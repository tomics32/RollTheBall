using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    public GameObject ball;
    public bool speedBool;
    
    private void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (speedBool == true)
        {
            ball.GetComponent<ThirdPersonMovement>().speed = 30;
            ball.GetComponent<ThirdPersonMovement>().jumpForce = 20;
        }
        else if (speedBool == false)
        {
            ball.GetComponent<ThirdPersonMovement>().speed = 10;
            ball.GetComponent<ThirdPersonMovement>().jumpForce = 10;
        }
    }
}
