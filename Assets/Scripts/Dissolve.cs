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
    public GameObject gameCamera;
    MenuPause menuPause;
    public bool isPaused = false;
    public GameObject pauseMenu;
    public GameObject ball;




    private void Start()
    {
        
        menuPause = pauseMenu.GetComponent<MenuPause>();
        

        anim = gameObject.GetComponent<Animator>();
        myColor = Color.white;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        anim.Play("Dissolve");
        gameObject.GetComponent<AudioSource>().Play();
        StartCoroutine(DelayedMenu());
        timeLeft.text = countDownText.text;
        countDownText.gameObject.SetActive(false);
        timeToFloat = float.Parse(timeLeft.text, CultureInfo.InvariantCulture);
        gameCamera.SetActive(false);
        



        if (timeToFloat >= starTime[1])
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
        



    }
    public IEnumerator DelayedMenu()
    {
        yield return new WaitForSecondsRealtime(1);
        levelCompletedMenu.SetActive(true);
        ball.GetComponent<Rigidbody>().isKinematic = true;
        menuPause.GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        isPaused = true;
    }
}
