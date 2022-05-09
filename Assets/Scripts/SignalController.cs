using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignalController : MonoBehaviour
{
    public GameObject objectToActivate;
    void Start()
    {
        
    }

    public void activateObject()
    {
        objectToActivate.SetActive(true);
    }
}
