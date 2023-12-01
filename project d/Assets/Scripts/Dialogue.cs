using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public static Dialogue Instance;

    public TextMeshProUGUI textComponent;
    public string[] lines;
    [SerializeField] char[] forbiddenCharacters = { '<', '>', '/' };
    public float textSpeed;

    private int index;
    public string passphrase;

    public GameObject choicesPanel;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        textComponent.text = string.Empty;
        GameManager.Instance.Shore();
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
            if (lines[index] == passphrase) //can use a secret passphrase like this to make stuff happen after completed dialogue
            {
                if (GameManager.Instance.activeSupect == 0)
                {
                    GameManager.Instance.shore.dialogueUnlocked = true;
                    GameManager.Instance.shore.UnlockDialogue();
                }
                if (GameManager.Instance.activeSupect == 1)
                {
                    GameManager.Instance.wizard.dialogueUnlocked = true;
                    GameManager.Instance.wizard.UnlockDialogue();
                }
                if (GameManager.Instance.activeSupect == 2)
                {
                    GameManager.Instance.throckmorton.dialogueUnlocked = true;
                    GameManager.Instance.throckmorton.UnlockDialogue();
                }
            }
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
