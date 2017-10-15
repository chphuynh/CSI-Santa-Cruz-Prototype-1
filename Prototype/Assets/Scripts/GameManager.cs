using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour 
{

	public static GameManager ins;

	[HideInInspector]
	public bool zoomTool;
	public bool panTool;

	[HideInInspector]
	public Node currentNode;

	public CameraRig rig;

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

		rig.DragCheck ();

	}



}
