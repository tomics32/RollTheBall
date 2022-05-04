using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Globalization;

public class Dissolve : MonoBehaviour
{

    Animator anim;
    public GameObject levelCompletedMenu;
    [SerializeField] TextMeshProUGUI timeLeft;
    [SerializeField] Text countDownText;
    float timeToFloat;
    [SerializeField] float[] starTime;
    [SerializeField] Image[] stars;
    Color myColor = new Color32(255, 255, 255, 100);
    public bool isPaused = false;





    private void Start()
    {
        
        anim = gameObject.GetComponent<Animator>();
        myColor = Color.white;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        anim.Play("Dissolve");
        gameObject.GetComponent<AudioSource>().Play();
        Invoke("DelayedMenu", 1);
        timeLeft.text = countDownText.text;
        countDownText.gameObject.SetActive(false);
        timeToFloat = float.Parse(timeLeft.text, CultureInfo.InvariantCulture);

        

        if(timeToFloat >= starTime[1])
        {
            stars[2].GetComponent<Image>().color = myColor;
            stars[1].GetComponent<Image>().color = myColor;
            stars[0].GetComponent<Image>().color = myColor;

        }
        else if (timeToFloat >= starTime[0] && timeToFloat < starTime[1])
        {
            stars[1].GetComponent<Image>().color = myColor;
            stars[0].GetComponent<Image>().color = myColor;
        }
        else
        {
            stars[0].GetComponent<Image>().color = myColor;
        }
        isPaused = true;



    }
    public void DelayedMenu()
    {     
        levelCompletedMenu.SetActive(true);
        Time.timeScale = 0f;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
