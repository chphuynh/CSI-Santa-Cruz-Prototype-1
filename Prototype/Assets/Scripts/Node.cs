using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Node : MonoBehaviour 
{

	public Transform cameraPosition;
	public List<Node> reachableNodes = new List<Node>();

	[HideInInspector]
	public Collider col;


	// Use this for initialization
	void Start () 
	{
		col = GetComponent<Collider>();
	}

	void OnMouseDown()
	{
		Arrive();
	}

	public void Arrive()
	{
		// Leave existing current Node
		if(GameManager.ins.currentNode != null) GameManager.ins.currentNode.Leave();

		// Set current Node
		GameManager.ins.currentNode = this;
		
		// Move Camera
		Camera.main.transform.position = cameraPosition.position;
		Camera.main.transform.rotation = cameraPosition.rotation;

		// Turn off current collider
		if(col != null) col.enabled = false;

		// Turn on colliders of reachable Nodes
		foreach(Node node in reachableNodes)
		{
			if(node.col != null) node.col.enabled = true;
		}

	}

	public void Leave()
	{
		// Turn off colliders of reachable Nodes
		foreach(Node node in reachableNodes)
		{
			if(node.col != null) node.col.enabled = false;
		}
	}

}
