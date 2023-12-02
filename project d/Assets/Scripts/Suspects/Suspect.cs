using TMPro;
using UnityEngine;

public class Suspect : MonoBehaviour
{
    public string motive, means, opportunity;
    public string[] suspectIntroText, whoAreYou, howDoYouKnowVic, whereWereYou, unlockableDialogue;
    public bool dialogueUnlocked;

    public GameObject unlockableButton;
    public string unlockedQuestion, secretPassphrase;

    public AudioSource backgroundMusicSource;
    public void OnSuspectChanged()
    {
        backgroundMusicSource.pitch = 1.0f;

        GameManager.Instance.dialogue.passphrase = secretPassphrase;

        if (dialogueUnlocked)
        {
            unlockableButton.GetComponent<Choice>().Available();
            unlockableButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = unlockedQuestion;
        }
        else
        {
            unlockableButton.GetComponent<Choice>().Unavailable();
            unlockableButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = "[Unavailable]";
        }
    }

    public virtual void UnlockDialogue()
    {
        if (dialogueUnlocked)
        {
            unlockableButton.GetComponent<Choice>().Available();
            unlockableButton.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = unlockedQuestion;
        }
    }
}
