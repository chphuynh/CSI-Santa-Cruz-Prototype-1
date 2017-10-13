using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour 
{
	public int normal = 60;
	public float smooth = 5;
	private int zoom = 60;

	void Update()
	{
		if(Input.GetKey("z"))
		{
			if(zoom < normal) zoom += 1;
		} 
		else if (Input.GetKey("x"))
		{
			if(zoom > 1) zoom -= 1;
		}

		if(zoom != normal)
		{
			Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoom, Time.deltaTime * smooth);
		}

	}

}
