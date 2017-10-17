using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour 
{
	public float normal = 2.3f;
	public float smooth = 5f;
	public float maxZoom = 2.3f;
	public float minZoom = 0.3f;
	public float zoomSpeed = 0.1f;

	// private float zoom;
	private Vector3 originalCameraPos;

	void Start()
	{
		//zoom = normal;
		originalCameraPos = transform.position;	
	}

	public void Zoom()
	{
		if(!CheckMousePosition("Tool Panel") && !CheckMousePosition("Clue Panel"))
		{
			if (Input.GetMouseButtonDown(0) && Camera.main.orthographicSize > minZoom)
			{
				//zoom -= zoomSpeed;6
				ZoomOrthoCamera(Camera.main.ScreenToWorldPoint(Input.mousePosition), zoomSpeed);
			}

			if (Camera.main.orthographicSize == maxZoom)
			{
				transform.position = originalCameraPos;
			} else if (Input.GetMouseButtonDown(1) && Camera.main.orthographicSize < maxZoom)
			{
				// 	zoom += zoomSpeed;
				ZoomOrthoCamera(Camera.main.ScreenToWorldPoint(Input.mousePosition), -zoomSpeed);
				if (Camera.main.orthographicSize == maxZoom)
				{
					transform.position = originalCameraPos;
				}
			} 
		}
	}

	void ZoomOrthoCamera(Vector3 zoomTowards, float amount)
     {
         // Calculate how much we will have to move towards the zoomTowards position
         float multiplier = (1.0f / Camera.main.orthographicSize * amount);
 
         // Move camera
         transform.position += (zoomTowards - transform.position) * multiplier; 
 
         // Zoom camera
         Camera.main.orthographicSize -= amount;
 
         // Limit zoom
         Camera.main.orthographicSize = Mathf.Clamp(Camera.main.orthographicSize, minZoom, maxZoom);
     }

    bool CheckMousePosition(string objectName)
	{
		Vector3[] corners = new Vector3[4];
		GameObject.Find(objectName).GetComponent<RectTransform>().GetWorldCorners(corners);
		Rect newRect = new Rect(corners[0], corners[2]-corners[0]);
        return newRect.Contains(Input.mousePosition);
	}

}
