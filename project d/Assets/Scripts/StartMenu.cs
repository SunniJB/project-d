using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class StartMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] VidPlayer player;
    [SerializeField] GameObject startPanel, skipButton;

    private void Start()
    {

    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void PlayCutscene()
    {
        startPanel.SetActive(false);
        gameObject.GetComponent<AudioSource>().enabled = false;
        skipButton.SetActive(true);
        player.PlayVideo();
        StartCoroutine(WaitForVideoEnd());
    }

    IEnumerator WaitForVideoEnd()
    {
        yield return new WaitForSeconds(40);
        StartGame();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
