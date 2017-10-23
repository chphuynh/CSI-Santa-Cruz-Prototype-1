using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelpButton : MonoBehaviour {

	public void Help()
	{
		GameObject panel = GameObject.Find("Help Menu").transform.GetChild(0).gameObject;

		if(panel.activeSelf)
			panel.SetActive(false);
		else
			panel.SetActive(true);
	}
}
