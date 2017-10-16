using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleTool : MonoBehaviour {

	private Image image;
	public bool isOn = false;

	void Start()
	{
		image = GetComponent<Image>();
	}

	void Update()
	{
		Color cb = image.color;
		cb = isOn ? new Color(100.5f, 0.5f, 0.5f ) : new Color(1, 1, 1 );
		image.color = cb;
	}


}
