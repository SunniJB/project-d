
using UnityEngine;

public class DialogueList : MonoBehaviour
{
    public static DialogueList Instance;
    public string[] suspectIntroText, whoAreYou, whereWereYou, howDoYouKnowVic;

    private void Start()
    {
        Instance = this;
    }
}
