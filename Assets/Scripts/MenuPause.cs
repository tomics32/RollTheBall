using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuPause : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PauseMenuUI;
    public GameObject Ball;
    public GameObject Camera;
    public GameObject CountDown;
    public GameObject inGameMusic;
    public GameObject RollingSound;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                RollingSound.GetComponent<AudioSource>().Pause();
                inGameMusic.GetComponent<AudioSource>().Pause();
                Pause();
            }
        }
    }
    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        RollingSound.GetComponent<AudioSource>().Play();
        inGameMusic.GetComponent<AudioSource>().Play();
        Cursor.visible = false;
    }
    void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
        Cursor.visible = false;
        GameIsPaused = false;
    }
    public void LoadMenu()
    {
        GameIsPaused = false;
        Time.timeScale = 1f;
        Ball.GetComponent<Rigidbody>().isKinematic = true;
        Camera.SetActive(false);
        CountDown.SetActive(false);
    }

    public void Quit()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
