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
			if(buttons[0].GetComponent<ToggleTool>().isOn == true)
				rig.DragCheck ();
			if(buttons[1].GetComponent<ToggleTool>().isOn == true)
				rig.GetComponent<CameraZoom>().Zoom();
			if(buttons[2].GetComponent<ToggleTool>().isOn == true)
				rig.Select();
			if(buttons[3].GetComponent<ToggleTool>().isOn == true)
				rig.Enhance();
		} else
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
