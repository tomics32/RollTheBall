using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCountDown : MonoBehaviour
{
    [SerializeField] float startingTime = 3f;
    float currentTime = 0f;

    [SerializeField] ThirdPersonMovement thirdPersonMovement;
    public GameObject roundTimer;

    

    [SerializeField] GameObject[] numbers;
    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        StartCoroutine(Break());

        
    }


    IEnumerator Break()
    {      
        
        if (currentTime <= 3 && currentTime > 2)
        {
            numbers[0].SetActive(true);
        }
        else if (currentTime <= 2 && currentTime > 1)
        {
            numbers[0].SetActive(false);
            numbers[1].SetActive(true);
        }
        else if (currentTime <= 1 && currentTime > 0)
        {
            numbers[1].SetActive(false);
            numbers[2].SetActive(true);
        }
        else if (currentTime <= 0 && currentTime > -1)
        {
            numbers[2].SetActive(false);
            numbers[3].SetActive(true);

            roundTimer.SetActive(true);
            thirdPersonMovement.GetComponent<Rigidbody>().useGravity = true;
            thirdPersonMovement.GetComponent<ThirdPersonMovement>().enabled = true;
            yield return new WaitForSeconds(1);
            numbers[3].SetActive(false);
        }
    }
}
