using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Notebook : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    [SerializeField] GameObject[] shoreInfoPieces, wizardInfoPieces, throckmortonInfoPieces;

    private void Start()
    {
        gameManager = GameManager.Instance;
    }

    public void RevealInformation(int button)
    {
        if (gameManager.activeSupect == 0)
        {
            shoreInfoPieces[button].gameObject.SetActive(true);
        }

        if (gameManager.activeSupect == 1)
        {
            wizardInfoPieces[button].gameObject.SetActive(true);
        }

        if (gameManager.activeSupect == 2)
        {
            throckmortonInfoPieces[button].gameObject.SetActive(true);
        }
    }
}
