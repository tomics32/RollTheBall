using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;
using UnityEngine.SceneManagement;

public class CountDownTimer : MonoBehaviour
{
    float currentTime = 0f;
    [SerializeField]float startingTime = 10f;
	CultureInfo culture = CultureInfo.CreateSpecificCulture("en-us");
	public bool isPaused = false;

	[SerializeField] Text countDownText;

	List<GameObject> objectsInScene = new List<GameObject>();


	

	private void Start()
	{
		
		currentTime = startingTime;
		
	}

	private void Update()
	{
		currentTime -= 1 * Time.deltaTime;
		countDownText.text = currentTime.ToString("0.0", culture);

		if(currentTime <= 0)
		{
			foreach (GameObject go in Resources.FindObjectsOfTypeAll(typeof(GameObject)) as GameObject[])
			 {
				if (go.name.Equals("GameOver") && go.activeSelf == false)
				{
					go.SetActive(true);
					Time.timeScale = 0f;
					Cursor.visible = true;
					Cursor.lockState = CursorLockMode.None;

				}
			}

			currentTime = 0;
		}

		if(currentTime <= 10 && currentTime > 5)
		{
			countDownText.color = Color.yellow;
		}
		else if (currentTime <= 5)
		{
			countDownText.color = Color.red;
		}
	}
}
