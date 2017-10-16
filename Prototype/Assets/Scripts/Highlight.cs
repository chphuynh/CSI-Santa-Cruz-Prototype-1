using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Highlight : MonoBehaviour {

	private Material material;
	private Color normalColor;
	private Color highlightColor;
	private bool touching;
	private float interval;
	public float highlightLevel = 3.0f;

	// Use this for initialization
	void Start () 
	{
		material = GetComponent<MeshRenderer>().material;

		normalColor = material.color;
		highlightColor = new Color(normalColor.r * highlightLevel, normalColor.g * highlightLevel, normalColor.b * highlightLevel);
	}
	

	void Update()
	{
		if(touching)
		{
			interval += Time.deltaTime;
			material.color = Color.Lerp(normalColor, highlightColor, interval);
		}

		if(Input.GetMouseButtonUp(0) && touching)
		{
			touching = false;
			material.color = normalColor;
		}
	}

	void OnMouseDown()
	{
		touching = true;
		interval = 0f;
	}
}
