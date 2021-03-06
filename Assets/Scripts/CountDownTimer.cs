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
	public bool isLessThanFive = false;
	public GameObject inGameMusic;
	

	[SerializeField] Text countDownText;

	List<GameObject> objectsInScene = new List<GameObject>();

	Animator anim;

	private void Start()
	{
		currentTime = startingTime;
		anim = gameObject.GetComponent<Animator>();
		

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
					inGameMusic.GetComponent<AudioSource>().Pause();
					Time.timeScale = 0f;
					Cursor.visible = true;
					Cursor.lockState = CursorLockMode.None;
					
				}
			}

			currentTime = 0;
		}

		if (currentTime <= 10 && currentTime > 5)
		{
			countDownText.color = Color.yellow;
		}
		else if (currentTime <= 5 && isLessThanFive == false)
		{
			countDownText.color = Color.red;
			countDownText.transform.position = countDownText.transform.position + new Vector3(886, -100, 0);
			countDownText.fontSize = 150;
			countDownText.fontStyle = FontStyle.Bold;
			isLessThanFive = true;
		}
		else if (currentTime <= 5)
		{
			anim.Play("BiggerSmaller");
		}

	}
}
