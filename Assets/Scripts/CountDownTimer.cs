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


	[SerializeField] Text countDownText;
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

			currentTime = 0;
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
