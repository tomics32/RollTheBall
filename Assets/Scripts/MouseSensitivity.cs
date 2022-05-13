using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class MouseSensitivity : MonoBehaviour
{
   
    private void Awake()
    {
        if (PlayerPrefs.HasKey("Sensitivity"))
        {
            gameObject.GetComponent<CinemachineFreeLook>().m_YAxis.m_MaxSpeed = PlayerPrefs.GetFloat("Sensitivity") / 2.5f;
            gameObject.GetComponent<CinemachineFreeLook>().m_XAxis.m_MaxSpeed = PlayerPrefs.GetFloat("Sensitivity") * 40;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
