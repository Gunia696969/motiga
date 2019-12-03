using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttons : MonoBehaviour
{
	public GameObject settings;
	public GameObject records;
	[System.Obsolete]
	public void StartGame()
    {
		Application.LoadLevel(1);  
    }

	public void Settings()
	{
		settings.SetActive(!settings.activeSelf);
	}


	public void Records()
	{
		records.SetActive(!records.activeSelf);
	}

	public void ExitGame()
    {
		Application.Quit();  
    }
}
