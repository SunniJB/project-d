using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int activeSupect; //0 is shore, 1 is wizard, 2 is throckmorton


    public void Shore()
    {
        Debug.Log("Shoer is now selected");
    }

    public void Wizard()
    {
        Debug.Log("Wizard is now selected");
    }

    public void Throckmorton()
    {
        Debug.Log("Throckmorton is now selected");
    }
}
