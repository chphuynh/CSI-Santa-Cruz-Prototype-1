using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enhance : MonoBehaviour {

	public string enhanceObject;

	void Start()
	{
		enhanceObject = "";
	}

	public void CompleteEnhance()
	{
		switch(enhanceObject)
		{
			case "body":
				GameManager.ins.rig.bodyEnhanced = true;
				GameObject.Find("Pixelate Body").SetActive(false);
				GameObject.Find("body").GetComponent<CapsuleCollider>().enabled = true;
				break;
			case "laptop":
				GameManager.ins.rig.computerEnhanced = true;
				break;
			default:
				break;
		}
		transform.parent.parent.gameObject.SetActive(false);
	}
}
