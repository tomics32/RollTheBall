using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{

    Animator anim;
  

    private void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }
    private void OnTriggerEnter(Collider other)
    {
        anim.Play("Dissolve");
        gameObject.GetComponent<AudioSource>().Play();
    }
}
