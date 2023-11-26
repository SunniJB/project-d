using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suspect : MonoBehaviour
{
    public string motive, means, opportunity;
    public string[] suspectIntroText, whoAreYou, whereWereYou, howDoYouKnowVic;

    public void OnSuspectChanged()
    {
        GameManager.Instance.motiveText.text = motive;
        GameManager.Instance.meansText.text = means;
        GameManager.Instance.opportunityText.text = opportunity;
    }

    public void WhoAreYou()
    {

    }
}
