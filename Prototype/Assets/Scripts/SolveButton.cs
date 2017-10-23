using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SolveButton : MonoBehaviour
{
    public GameObject finalScreen;
    public GameObject endScreen;
    public Text textBox;

    private TextAsset textFile;
    
    public void checkClues()
    {
        if (GameManager.ins.rig.bodyFound && GameManager.ins.rig.knifeFound && GameManager.ins.rig.computerFound)
        {
            finalScreen = GameObject.Find("Final Screen Container").transform.GetChild(0).gameObject;
            finalScreen.SetActive(true);
        }
        else
        {
            GameManager.ins.textBoxManager.GetComponent<TextBoxManager>().StartEvent("moreClues");
        }
    }

    public void displayEndScreen(string clueNumber)
    {
        endScreen = GameObject.Find("End Screen Container").transform.GetChild(0).gameObject;
        endScreen.SetActive(true);
        switch(clueNumber)
        {
            case "clue1":
                textFile = Resources.Load("Text/clue1") as TextAsset;
                break;
            case "clue2":
                textFile = Resources.Load("Text/clue2") as TextAsset;
                break;
            case "clue3":
                textFile = Resources.Load("Text/clue3") as TextAsset;
                break;
            default:
                break;
        }
        textBox = GameObject.Find("End Message").GetComponent<UnityEngine.UI.Text>();
        textBox.text = textFile.text;
        StartCoroutine(TypeSentence(textBox.text));

    }

    IEnumerator TypeSentence(string sentence)
    {
        textBox.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            textBox.text += letter;
            yield return null;
        }
    }
}