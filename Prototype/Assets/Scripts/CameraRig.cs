using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CameraRig : MonoBehaviour 
{

	public float dragSpeed = 0.75f;
	public float leftBound = -0.8f;
	public float rightBound = 2.8f;
	public float topBound = 3.7f;
	public float botBound = 0.6f;

	private Vector3 originalCameraPos;
	private Vector3 dragOrigin;

	public bool bodyFound = false;
	public bool knifeFound = false;
	public bool bodyEnhanced = false;
	public bool computerFound = false;
	public bool computerEnhanced = false;

	void Start()
	{
		originalCameraPos = transform.position;	
	}

	public void DragCheck()
	{
		if(Camera.main.orthographicSize != GetComponent<CameraZoom>().maxZoom)
		{

			if (Input.GetMouseButtonDown(0))
			{
				dragOrigin = Input.mousePosition;
				return;
			}

			if (!Input.GetMouseButton(0)) return;

			Vector3 cam_pos = this.gameObject.transform.position;

			Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);

			if ( cam_pos.x <= rightBound && cam_pos.x >= leftBound && cam_pos.y <= topBound && cam_pos.y >= botBound) 
			{
				Vector3 move = new Vector3 (pos.x * dragSpeed, pos.y * dragSpeed, 0f);
				transform.Translate (move, Space.World);  
			}

			RestrictCamera ();
		} else 
		{
			transform.position = originalCameraPos;
		}
	}

	void RestrictCamera()
	{
		Vector3 cam_pos = this.gameObject.transform.position;

		if (cam_pos.x > rightBound)
			this.gameObject.transform.position = new Vector3(rightBound, cam_pos.y, cam_pos.z);
		if (cam_pos.x < leftBound)
			this.gameObject.transform.position = new Vector3(leftBound, cam_pos.y, cam_pos.z);
		if (cam_pos.y > topBound)
			this.gameObject.transform.position = new Vector3(cam_pos.x, topBound, cam_pos.z);
		if (cam_pos.y < botBound)
			this.gameObject.transform.position = new Vector3(cam_pos.x, botBound, cam_pos.z);
	}

	public void Select()
	{	
		if( Input.GetMouseButtonDown(0) && !CheckMousePosition("Tool Panel") && !CheckMousePosition("Clue Panel") )
     	{
        	Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        	RaycastHit hit;
         
        	if( Physics.Raycast( ray, out hit, 100 ) )
        	{
            	GameObject item = hit.transform.gameObject;
            	// Debug.Log(item.tag);
            	switch(item.tag)
            	{
            		case "body":
            				bodyFound = true;
            				GameObject.Find("Clue1").GetComponent<Clue>().clueFound = true;
            			break;
            		case "knife":
            			if(Camera.main.orthographicSize == 0.3f)
            			{
      						knifeFound = true;
      						GameObject.Find("Clue2").GetComponent<Clue>().clueFound = true;
      					}
      					else
      					{
      						Debug.Log("maybe you should zoom in");
      					}
            			break;
            		case "laptop":
            			if(Camera.main.orthographicSize == 0.3f)
            			{
      						if(computerEnhanced)
      						{
      							computerFound = true;
      							GameObject.Find("Clue3").GetComponent<Clue>().clueFound = true;
      						}
      						else
      						{
      							Debug.Log("maybe you should enhance it");
      						}
      					}
      					else
      					{
      						Debug.Log("maybe you should zoom in");
      					}
            			break;
            		case "pixelate":
            			Debug.Log("Maybe you should enhance it");
            			break;
            		default:
            			return;
            	}        	
            }
     	}
	}

	public void Enhance()
	{	
		if( Input.GetMouseButtonDown(0) && !CheckMousePosition("Tool Panel") && !CheckMousePosition("Clue Panel") )
     	{
        	Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        	RaycastHit hit;
         
        	if( Physics.Raycast( ray, out hit, 100 ) )
        	{
            	GameObject item = hit.transform.gameObject;
            	// Debug.Log(item.tag);
            	switch(item.tag)
            	{
            		case "body":
            			break;
            		case "knife":
            			break;
            		case "laptop":
            			if(!computerEnhanced)
            			{	
            				if(Camera.main.orthographicSize == 0.3f)
            				{
	            				GameObject panel = GameObject.Find("Enhance Clue").transform.GetChild(0).gameObject;
		            			panel.transform.GetChild(1).GetChild(1).gameObject.GetComponent<Enhance>().enhanceObject = "laptop";
		            			panel.SetActive(true);
            				}
            				else
            				{
            					Debug.Log("maybe you should zoom in");
            				}
            			}
            			break;
            		case "pixelate":
	            		GameObject panel2 = GameObject.Find("Enhance Clue").transform.GetChild(0).gameObject;
	            		panel2.transform.GetChild(1).GetChild(1).gameObject.GetComponent<Enhance>().enhanceObject = "body";
	            		panel2.SetActive(true);
            			break;
            		default:
            			return;
            	}        	
            }
     	}
	}

	bool CheckMousePosition(string objectName)
	{
		Vector3[] corners = new Vector3[4];
		GameObject.Find(objectName).GetComponent<RectTransform>().GetWorldCorners(corners);
		Rect newRect = new Rect(corners[0], corners[2]-corners[0]);
        return newRect.Contains(Input.mousePosition);
	}
}
