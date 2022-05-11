using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class SignalController : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject objectToDeactivate;

    [SerializeField] private PlayableDirector _introCutscene = null;
    [SerializeField] private double _introSkipTime = 369f;
    void Start()
    {
        
    }

    public void ActivateObject()
    {
        objectToActivate.SetActive(true);
    }

    public void DisactivateObject()
    {
        objectToDeactivate.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _introCutscene.time = _introSkipTime;
        }
    }
}
