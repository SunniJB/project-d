using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class notebookButton : MonoBehaviour
{
    private GameManager gameManager;
    [SerializeField] GameObject[] notebooks;
    private void Start()
    {
        gameManager = GameManager.Instance;
    }
    public void OnClick()
    {
        notebooks[gameManager.activeSupect].SetActive(true);
        SoundManager.Instance.PlaySound("bookFlip");
    }
}
