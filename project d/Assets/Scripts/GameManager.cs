using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool gameIsPaused;
    [SerializeField] GameObject pausePanel;

    public int activeSupect; //0 is shore, 1 is wizard, 2 is throckmorton
    [SerializeField] private Sprite[] portraits;
    [SerializeField] private GameObject mainPortrait;

    public TextMeshProUGUI nameText, notebookName, accusationName;

    public static GameManager Instance;
    public Suspect shore, wizard, throckmorton;
    public Dialogue dialogue;

    public GameObject generalNotebook;

    public Boxes[] wizardBoxes;
    public bool fadeOutMusic;
    [SerializeField] private AudioSource backgroundMusicSource;
    public GameObject winPanel, losePanel;


    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        notebookName.text = "Ms. Shore";
        dialogue.lines = shore.suspectIntroText;
        dialogue.passphrase = shore.secretPassphrase;
    }

    private void Update()
    {
        if (generalNotebook.activeInHierarchy)
        {
            Time.timeScale = 0f;
        } else if (generalNotebook.activeInHierarchy == false)
        {
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }

        accusationName.text = nameText.text + "?";

        if (fadeOutMusic)
        {
            if (backgroundMusicSource.volume > 0)
            {
                backgroundMusicSource.volume -= Time.deltaTime * 1 / 3f;
            }
            if (backgroundMusicSource.volume <= 0)
            {
                fadeOutMusic = false;
            }
        }
    }
    public void PauseGame()
    {
        if (gameIsPaused)
        {
            pausePanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(false);
        }
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
        notebookName.text = nameText.text;
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

    public void CheckIfWon()
    {
        int correctBoxes = 0;
        fadeOutMusic = true;

        if (activeSupect == 1)
        {
            foreach (var box in wizardBoxes)
            {
                if (box.GetComponent<Boxes>().hasTheRightInfo)
                {
                    correctBoxes += 1;
                }
            }
            if (correctBoxes == 3)
            {
                Win();
            } else
            {
                Lose();
            }
        } else
        {
            Lose();
        }
    }

    public void Win()
    {
        Debug.Log("Player won!");
        SoundManager.Instance.PlaySound("Success");
        winPanel.SetActive(true);
    }
    public void Lose()
    {
        SoundManager.Instance.PlaySound("Error");
        Debug.Log("Player lost!");
        losePanel.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
