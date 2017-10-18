using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolveButton : MonoBehaviour
{
    public GameObject finalScreen;
    public GameObject endScreen;
    public void checkClues()
    {
        //Debug.Log("ay");
        //finalScreen = GameObject.Find("Final Screen Container").transform.GetChild(0).gameObject;
        //finalScreen.SetActive(true);
        if (GameManager.ins.rig.bodyFound && GameManager.ins.rig.knifeFound && GameManager.ins.rig.computerFound)
        {
            finalScreen = GameObject.Find("Final Screen Container").transform.GetChild(0).gameObject;
            finalScreen.SetActive(true);
        }
        else
        {
            //error message
        }
    }

    public void displayEndScreen()
    {
        Debug.Log("ay");
        endScreen = GameObject.Find("End Screen Container").transform.GetChild(0).gameObject;
        endScreen.SetActive(true);
    }
}