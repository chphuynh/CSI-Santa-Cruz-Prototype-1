using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextBoxManager : MonoBehaviour
{
    public GameObject textBox;
    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine;
    public int endAtLine;
    //public PlayerController player;

    // Use this for initialization
    void Start()
    {
        while (textFile == null)
        {
            continue;
        }
        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }
        if (endAtLine == 0)
        {
            endAtLine = textLines.Length - 1;
        }
    }

    void Update()
    {
        theText.text = textLines[currentLine];
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentLine += 1;
        }
        if (currentLine > endAtLine)
        {
            textBox.SetActive(false);
            currentLine = endAtLine;
        }
    }

    void setText(TextAsset text_file)
    {
        this.textFile = text_file;
    }
}