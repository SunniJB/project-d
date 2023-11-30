using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public bool unavailable;

    private void Start()
    {
        if (unavailable)
        {
            Unavailable();
        }
    }

    public void Unavailable()
    {
        gameObject.GetComponent<Button>().interactable = false;
        gameObject.GetComponent<Image>().color = Color.gray;
    }

    public void Available()
    {
        gameObject.GetComponent<Button>().interactable = true;
        gameObject.GetComponent<Image>().color = Color.white;
    }
}
