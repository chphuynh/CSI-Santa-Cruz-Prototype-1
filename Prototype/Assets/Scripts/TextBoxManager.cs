using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextBoxManager : MonoBehaviour
{
    public GameObject textBox;
    public Text theText;

    public TextAsset textFile;
    public Queue<string> textLines;

    // Use this for initialization
    void Start()
    {
        textLines = new Queue<string>();
        StartDialogue();
    }

    void StartDialogue()
    {
        if (textFile != null)
        {
            foreach(string line in textFile.text.Split('\n'))
            {
                textLines.Enqueue(line);
            }

            DisplayNextLine();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            DisplayNextLine();
        }
    }

    void DisplayNextLine()
    {
        if(textLines.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = textLines.Dequeue();
        theText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    void EndDialogue()
    {
        textBox.SetActive(false);
    }

    IEnumerator TypeSentence(string sentence)
    {
        theText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            theText.text += letter;
            yield return null;
        }
    }

    void setText(TextAsset text_file)
    {
        this.textFile = text_file;
    }
}