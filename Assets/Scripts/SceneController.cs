using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
	[SerializeField] string levelName;
    public void RestartScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1f;
		Cursor.visible = false;
	}

	public void LoadLevel()
	{
		SceneManager.LoadScene(levelName);
	}

	public void ResumeTime()
	{
		Time.timeScale = 1f;
	}
	public void ExitApplication()
	{
		Application.Quit();
	}
	
}
