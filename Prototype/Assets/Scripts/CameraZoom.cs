using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour 
{
	public int normal = 60;
	public float smooth = 5;
	public int maxZoom = 10;

	private int zoom = 60;

	public void Zoom()
	{
		if (Input.GetKey(KeyCode.Mouse0))
		{
			zoom -= 2;
		}

		if (Input.GetKey(KeyCode.Mouse1))
		{
			zoom += 2;
		}

		if(zoom < maxZoom) zoom = maxZoom;

		if(zoom > normal ) zoom = normal;

		Camera.main.fieldOfView = Mathf.Lerp(Camera.main.fieldOfView, zoom, Time.deltaTime * smooth);


	}

}
