using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class StartMenu : MonoBehaviour
{
    [SerializeField] Slider volumeSlider;
    [SerializeField] VideoPlayer player;

    private void Start()
    {
        gameObject.GetComponent<Animator>().enabled = false;
        player.Prepare();
    }
    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }

    public void PlayCutscene()
    {
        gameObject.GetComponent<Animator>().enabled = true;
    }
    public void PlayVideo()
    {
        player.Play();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
