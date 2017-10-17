using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CloseButton : MonoBehaviour {

	void Start()
	{

	}

	public void closeWindow()
	{
		transform.parent.gameObject.SetActive(false);
	}
}
