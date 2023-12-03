using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Choice : MonoBehaviour
{
    public bool unavailable, hasBeenRevealed;
    public int buttonNumber;
    [SerializeField] Notebook[] notebooks;

    private void Start()
    {
        if (unavailable)
        {
            Unavailable();
        }
    }

    public void OnClick()
    {
        hasBeenRevealed = true;
        notebooks[GameManager.Instance.activeSupect].RevealInformation(buttonNumber);
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
