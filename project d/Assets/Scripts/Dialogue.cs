using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public static Dialogue Instance;

    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;

    public GameObject choicesPanel;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        textComponent.text = string.Empty;
        StartDialogue();
        choicesPanel.SetActive(false);
    }

    public void StartDialogue()
    {
        textComponent.text = string.Empty;
        index = 0;
        choicesPanel.SetActive(false);
        StartCoroutine(TypeLine());
    }
    public void ContinueDialogue()
    {
        if (textComponent.text == lines[index])
        {
            NextLine();
        }
        else
        {
            StopAllCoroutines();
            textComponent.text = lines[index];
        }
    }
    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine (TypeLine());
        } else
        {
            choicesPanel.SetActive(true);
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            SoundManager.Instance.TypingSound();
            yield return new WaitForSeconds(textSpeed);
        }
    }
}
