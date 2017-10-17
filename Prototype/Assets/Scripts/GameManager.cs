using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{

	public static GameManager ins;

	public CameraRig rig;
	public GameObject[] buttons;

	// Very bad singleton
	void Awake()
	{
		ins = this;
	}

	void Update()
	{
		// if(Input.GetMouseButtonDown(1) && currentNode.GetComponent<Prop>() != null)
		// {
		// 	currentNode.GetComponent<Prop>().loc.Arrive();
		// }

		if (Input.GetKey(KeyCode.A))
		{
			Debug.Log (Camera.main.gameObject.transform.position);
		}

		if(buttons[0].GetComponent<ToggleTool>().isOn == true)
			rig.DragCheck ();

		if(buttons[1].GetComponent<ToggleTool>().isOn == true)
			rig.GetComponent<CameraZoom>().Zoom();
		if(buttons[2].GetComponent<ToggleTool>().isOn == true)
			rig.Select();
		if(buttons[3].GetComponent<ToggleTool>().isOn == true)
			rig.Enhance();

	}

	public void ToggleButtons(string toggleTag)
	{
		foreach(GameObject button in buttons)
		{
			//Debug.Log(button.tag);
			if(button.tag != toggleTag)
				button.GetComponent<ToggleTool>().isOn = false;
			else
				button.GetComponent<ToggleTool>().isOn = !button.GetComponent<ToggleTool>().isOn;
		}
	}


}
