using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
	public AudioMixer audioMixer;

	public Dropdown resolutionDropdown;

	public Button[] optionsSet;


	Resolution[] resolutions;
	public Slider[] masterSlider;
	public Slider mouseSensSlider;
	public Dropdown qualityGraphics;

	private void Start()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
		if (PlayerPrefs.HasKey("Sensitivity"))
        {
			mouseSensSlider.value = PlayerPrefs.GetFloat("Sensitivity");
        }
		qualityGraphics.value = QualitySettings.GetQualityLevel();

		masterSlider[0].value = PlayerPrefs.GetFloat("MasterVolume", 0.75f);
		masterSlider[1].value = PlayerPrefs.GetFloat("MusicVolume", 0.75f);
		masterSlider[2].value = PlayerPrefs.GetFloat("EffectsVolume", 0.75f);

		resolutions = Screen.resolutions;

		resolutionDropdown.ClearOptions();

		List<string> options = new List<string>();

		int currentResolutionIndex = 0;
		for(int i = 0; i <resolutions.Length; i++)
		{
			
				string option = resolutions[i].width + " x " + resolutions[i].height + "  @" + resolutions[i].refreshRate + "hz";

				options.Add(option);
			

			if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height ==
				Screen.currentResolution.height && resolutions[i].refreshRate
				== Screen.currentResolution.refreshRate)
			{
				currentResolutionIndex = i;
			}
		}
		
		resolutionDropdown.AddOptions(options);
		resolutionDropdown.value = currentResolutionIndex;
		resolutionDropdown.RefreshShownValue();
	}

	private void Update()
	{
		SetResolution2();
	}
	public void SetResolution(int resolutionIndex)
	{
		Resolution resolution = resolutions[resolutionIndex]; 
		Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
	}

	public void SetResolution2()
	{
		if (Input.GetKeyDown(KeyCode.O))
		{
			Screen.SetResolution(1920, 1080, Screen.fullScreen);
		}
	}
	public void SetMasterVolume(float volume)
	{
		audioMixer.SetFloat("generalVol", Mathf.Log10(volume) * 20);
		PlayerPrefs.SetFloat("MasterVolume", volume);
	}

	public void SetMusicVolume(float volume)
	{
		audioMixer.SetFloat("musicVol", Mathf.Log10(volume) * 20);
		PlayerPrefs.SetFloat("MusicVolume", volume);
	}

	public void SetEffectsVolume(float volume)
	{
		audioMixer.SetFloat("effectsVol", Mathf.Log10(volume) * 20);
		PlayerPrefs.SetFloat("EffectsVolume", volume);
	}



	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
		PlayerPrefs.SetInt("GraphicsQuality", qualityIndex);
		
	}

	public void SetFullScreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}

	public void DisableOptions()
    {
		for (int i = 0; i < optionsSet.Length; i++)
        {
			if (optionsSet[i].interactable == true)
			{
				optionsSet[i].interactable = false;
			}
			else if (optionsSet[i].interactable == false)
            {
				optionsSet[i].interactable = true;
            }
        }
		
	}

	public void SetMouseSensitivity(float val)
    {
		

		PlayerPrefs.SetFloat("Sensitivity", val);
		Debug.Log(val);
    }
}
