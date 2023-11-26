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
    public Dialogue dialogue;


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

    public void WhoAreYou()
    {
        switch (activeSupect)
        {
            case 0:
                dialogue.lines = shore.whoAreYou;
                break;
            case 1:
                dialogue.lines = wizard.whoAreYou;
                break;
            case 2:
                dialogue.lines = throckmorton.whoAreYou;
                break;
            default:
                print("Error");
                break;
        }

        dialogue.StartDialogue();
    }

    public void WhereWereYou()
    {
        switch (activeSupect)
        {
            case 0:
                dialogue.lines = shore.whereWereYou;
                break;
            case 1:
                dialogue.lines = wizard.whereWereYou;
                break;
            case 2:
                dialogue.lines = throckmorton.whereWereYou;
                break;
            default:
                print("Error");
                break;
        }
        dialogue.StartDialogue();
    }

    public void HowDoYouKnowVic()
    {
        switch (activeSupect)
        {
            case 0:
                dialogue.lines = shore.howDoYouKnowVic;
                break;
            case 1:
                dialogue.lines = wizard.howDoYouKnowVic;
                break;
            case 2:
                dialogue.lines = throckmorton.howDoYouKnowVic;
                break;
            default:
                print("Error");
                break;
        }
        dialogue.StartDialogue();
    }
}
