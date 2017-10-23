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
				GameManager.ins.rig.bodyFound = true;
        		GameObject.Find("Clue1").GetComponent<Clue>().clueFound = true;
                GameObject.Find("Clue1").GetComponent<Clue>().showPanel();
                GameManager.ins.textBoxManager.GetComponent<TextBoxManager>().StartEvent("selectBody");
				break;
			case "laptop":
				GameManager.ins.rig.computerEnhanced = true;
				GameManager.ins.rig.computerFound = true;
				GameObject.Find("Clue3").GetComponent<Clue>().clueFound = true;
				GameObject.Find("Clue3").GetComponent<Clue>().showPanel();
				GameManager.ins.textBoxManager.GetComponent<TextBoxManager>().StartEvent("selectLaptop");
				break;
			default:
				break;
		}
		transform.parent.parent.gameObject.SetActive(false);
	}
}
