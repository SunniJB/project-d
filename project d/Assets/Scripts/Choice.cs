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
    private void Update()
    {

    }

    public void Unavailable()
    {
        gameObject.GetComponent<Button>().interactable = false;
        gameObject.GetComponent<Image>().color = Color.gray;
    }
}
