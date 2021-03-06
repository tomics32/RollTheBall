using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneController : MonoBehaviour
{
	[SerializeField] string levelName;
	public float transitionTime = 1f;

	
	public void RestartScene()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		Time.timeScale = 1f;
		Cursor.visible = false;
	}

	
	
	public void LoadLevel()
	{
		Time.timeScale = 1f;
		StartCoroutine(LoadLevelTransition());
		
	}
	public IEnumerator LoadLevelTransition()
	{
		yield return new WaitForSecondsRealtime(transitionTime);

		SceneManager.LoadScene(levelName);
	}


	public void ExitApplication()
	{
		Application.Quit();
	}

    
}
