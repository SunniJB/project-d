using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int activeSupect; //0 is shore, 1 is wizard, 2 is throckmorton
    [SerializeField] private Sprite[] portraits;
    [SerializeField] private GameObject mainPortrait, notepadPortrait;

    public TextMeshProUGUI motiveText, meansText, opportunityText;

    public static GameManager Instance;
    [SerializeField] private Suspect shore, wizard, throckmorton;
    [SerializeField] Dialogue dialogue;


    private void Start()
    {
        motiveText.text = meansText.text = opportunityText.text = "";
        Instance = this;
        dialogue.lines = shore.suspectIntroText;
    }
    public void Shore()
    {
        activeSupect = 0;
        Debug.Log("Shore is now selected");
        dialogue.lines = shore.suspectIntroText;
        dialogue.StartDialogue();
    }

    public void Wizard()
    {
        activeSupect = 1;
        dialogue.lines = wizard.suspectIntroText;
        Debug.Log("Wizard is now selected");
        dialogue.StartDialogue();
    }

    public void Throckmorton()
    {
        activeSupect = 2;
        dialogue.lines = throckmorton.suspectIntroText;
        Debug.Log("Throckmorton is now selected");
        dialogue.StartDialogue();
    }

    public void ChangePortrait()
    {
        mainPortrait.GetComponent<SpriteRenderer>().sprite = portraits[activeSupect]; 
        notepadPortrait.GetComponent<Image>().sprite = portraits[activeSupect];
    }
}
