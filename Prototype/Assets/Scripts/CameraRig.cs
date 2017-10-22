using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRig : MonoBehaviour 
{

	public float dragSpeed = 0.75f;
	public float leftBound = -0.8f;
	public float rightBound = 2.8f;
	public float topBound = 3.7f;
	public float botBound = 0.6f;

    public int scrollDistance = 5; 
    public float scrollSpeed;

	public bool bodyFound = false;
	public bool knifeFound = false;
	public bool bodyEnhanced = false;
	public bool computerFound = false;
	public bool computerEnhanced = false;

	public void Select()
	{	
        if( Input.GetMouseButtonDown(0) && !CheckMousePosition("Clue Panel") && !CheckMousePosition("Inspect Clue Panel") )
     	{
        	Ray ray = Camera.main.ScreenPointToRay( Input.mousePosition );
        	RaycastHit hit;
         
        	if( Physics.Raycast( ray, out hit, 100 ) )
        	{
            	GameObject item = hit.transform.gameObject;
            	switch(item.tag)
            	{
            		case "body":
        				bodyFound = true;
        				GameObject.Find("Clue1").GetComponent<Clue>().clueFound = true;
                        GameObject.Find("Clue1").GetComponent<Clue>().showPanel();
                        GameManager.ins.textBoxManager.GetComponent<TextBoxManager>().StartEvent("selectBody");
            			break;
            		case "knife":
            			if(Camera.main.orthographicSize == 0.3f)
            			{
                            GameManager.ins.textBoxManager.GetComponent<TextBoxManager>().StartEvent("selectKnife");
              			    knifeFound = true;
  						    GameObject.Find("Clue2").GetComponent<Clue>().clueFound = true;
                            GameObject.Find("Clue2").GetComponent<Clue>().showPanel();
      					}
    					else
    					{
                            GameManager.ins.textBoxManager.GetComponent<TextBoxManager>().StartEvent("zoomKnife");
    					}
            			break;
            		case "laptop":
            			if(Camera.main.orthographicSize == 0.3f)
            			{
    						if(computerEnhanced)
    						{
    							computerFound = true;
    							GameObject.Find("Clue3").GetComponent<Clue>().clueFound = true;
                                GameObject.Find("Clue3").GetComponent<Clue>().showPanel();
                                GameManager.ins.textBoxManager.GetComponent<TextBoxManager>().StartEvent("selectLaptop");
    						}
    						else
    						{
                                GameManager.ins.textBoxManager.GetComponent<TextBoxManager>().StartEvent("selectLaptopNoEnhance");
    						}
  					    }
    					else
    					{
                            GameManager.ins.textBoxManager.GetComponent<TextBoxManager>().StartEvent("zoomLaptop");
    					}
            			break;
            		case "pixelate":
                        GameManager.ins.textBoxManager.GetComponent<TextBoxManager>().StartEvent("selectPixelate");
            			break;
            		default:
            			return;
            	}        	
            }
     	}
	}

    public void EdgeMove()
    {
        if(Camera.main.orthographicSize != GetComponent<CameraZoom>().maxZoom)
        {
            float mousePosX = Input.mousePosition.x; 
            float mousePosY = Input.mousePosition.y; 
            if (mousePosX < scrollDistance && transform.position.x > leftBound) 
            { 
                transform.Translate(Vector3.right * -scrollSpeed * Time.deltaTime, Space.World); 
            } 

            if (mousePosX >= Screen.width - scrollDistance  && transform.position.x < rightBound) 
            { 
                transform.Translate(Vector3.right * scrollSpeed * Time.deltaTime, Space.World); 
            }

            if (mousePosY < scrollDistance  && transform.position.y > botBound) 
            { 
                transform.Translate(Vector3.up * -scrollSpeed * Time.deltaTime, Space.World); 
            } 

            if (mousePosY >= Screen.height - scrollDistance  && transform.position.y < topBound) 
            { 
                transform.Translate(Vector3.up * scrollSpeed * Time.deltaTime, Space.World); 
            }
        }
    }

	public void Enhance()
	{	
		if( Input.GetMouseButtonDown(1) && !CheckMousePosition("Clue Panel") )
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
                                GameManager.ins.textBoxManager.GetComponent<TextBoxManager>().StartEvent("zoomLaptop");
            				}
            			}
                        else
                        {
                            GameManager.ins.textBoxManager.GetComponent<TextBoxManager>().StartEvent("enhancedLaptop");
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
        if(GameObject.Find(objectName) == null) 
            return false;

		Vector3[] corners = new Vector3[4];
		GameObject.Find(objectName).GetComponent<RectTransform>().GetWorldCorners(corners);
		Rect newRect = new Rect(corners[0], corners[2]-corners[0]);
        return newRect.Contains(Input.mousePosition);
	}
}
