using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class SoundManager : MonoBehaviour
{
    [SerializeField] private List<AudioClip> soundClips;
    private Dictionary<string, AudioClip> soundDictionary = new Dictionary<string, AudioClip>();
    [SerializeField] private AudioSource singleSounds, typingSound, backgroundMusic;
    [SerializeField] private AudioClip currentClip;
    public static SoundManager Instance;

    [SerializeField] Slider volumeSlider;

    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {

        foreach (var clip in soundClips)
        {
            soundDictionary[clip.name] = clip;
        }
    }

    public void PlaySound(string soundName)
    {
        if (soundDictionary.TryGetValue(soundName, out AudioClip clipToPlay))
        {
            singleSounds.clip = clipToPlay;
            singleSounds.Play();
        }
        else
        {
            Debug.LogWarning($"Sound with name {soundName} not found!");
        }
    }

    public void TypingSound()
    {
        typingSound.pitch = Random.Range(1f, 2f);
        typingSound.volume = Random.Range(0.5f, 1f);
        typingSound.Play();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
}