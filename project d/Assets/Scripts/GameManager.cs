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

    public TextMeshProUGUI motiveText, meansText, opportunityText, nameText;

    public static GameManager Instance;
    public Suspect shore, wizard, throckmorton;
    public Dialogue dialogue;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        motiveText.text = meansText.text = opportunityText.text = "";

        dialogue.lines = shore.suspectIntroText;
        dialogue.passphrase = shore.secretPassphrase;
    }
    public void Shore()
    {
        activeSupect = 0;
        nameText.text = "Ms. Shore";
        dialogue.lines = shore.suspectIntroText;
        dialogue.StartDialogue();
    }

    public void Wizard()
    {
        activeSupect = 1;
        dialogue.lines = wizard.suspectIntroText;
        nameText.text = "Mr Wizard";
        dialogue.StartDialogue();
    }

    public void Throckmorton()
    {
        activeSupect = 2;
        dialogue.lines = throckmorton.suspectIntroText;
        nameText.text = "Mrs. Throckmorton";
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

    public void UnlockableDialogue()
    {
        switch (activeSupect)
        {
            case 0:
                dialogue.lines = shore.unlockableDialogue;
                break;
            case 1:
                dialogue.lines = wizard.unlockableDialogue;
                break;
            case 2:
                dialogue.lines = throckmorton.unlockableDialogue;
                break;
            default:
                print("Error");
                break;
        }
        dialogue.StartDialogue();
    }
}
