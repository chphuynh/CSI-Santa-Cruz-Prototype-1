using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{

	public static GameManager ins;

	public CameraRig rig;
	public GameObject[] buttons;
	public GameObject textBoxManager;
	public float scrollSpeed;

	public bool enableControl = true;

	// Very bad singleton
	void Awake()
	{
		ins = this;
	}

	void Update()
	{
		if (Input.GetKey("escape"))
            Application.Quit();

		if(enableControl)
		{	
			if(GameObject.Find("Inspect Clue Panel") == null && GameObject.Find("Enhance Panel") == null && GameObject.Find("Help Panel") == null)
			{
				rig.EdgeMove();
				rig.GetComponent<CameraZoom>().Zoom();
				rig.Select();
				rig.Enhance();
			}	
		} 
		else
		{
			if(Input.anyKeyDown)
				textBoxManager.GetComponent<TextBoxManager>().DisplayNextLine();
		}
	}

	public void ToggleButtons(string toggleTag)
	{
		foreach(GameObject button in buttons)
		{
			if(button.tag != toggleTag)
				button.GetComponent<ToggleTool>().isOn = false;
			else
				button.GetComponent<ToggleTool>().isOn = !button.GetComponent<ToggleTool>().isOn;
		}
	}


}
