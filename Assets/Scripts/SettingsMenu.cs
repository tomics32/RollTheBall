using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
	public AudioMixer audioMixer;

	public Dropdown resolutionDropdown;

	Resolution[] resolutions;

	private void Start()
	{
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
	public void SetVolume(float volume)
	{
		audioMixer.SetFloat("volume", volume);
	}



	public void SetQuality(int qualityIndex)
	{
		QualitySettings.SetQualityLevel(qualityIndex);
	}

	public void SetFullScreen(bool isFullscreen)
	{
		Screen.fullScreen = isFullscreen;
	}
}
