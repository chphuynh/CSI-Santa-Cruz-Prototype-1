using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Clue : MonoBehaviour {

	public Sprite sprite;
	public bool clueFound = false; 
	private Image image;

	// Use this for initialization
	void Start () {
		image = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(clueFound)
		{
			if(image.sprite != sprite)
			{
				image.sprite = sprite;
			}
		}	
	}

	public void showPanel()
	{	
		if(clueFound)
		{
			GameObject cluePanel = GameObject.Find("Inspect Clue").transform.GetChild(0).gameObject;
			cluePanel.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = sprite;
			cluePanel.SetActive(true);
		}
	}
}
