﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextBoxTrigger : MonoBehaviour {

    public TextAsset textFile;
    //public string textBoxManager;
    public GameObject manager;
    // Use this for initialization
    void Start () {
		//manager = GameObject.Find(textBoxManager);
        //gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.N))
        {
            manager.SetActive(true);
            manager.GetComponent<TextBoxManager>().setText(textFile);
            manager.GetComponent<TextBoxManager>().StartDialogue();
        }
    }
}
