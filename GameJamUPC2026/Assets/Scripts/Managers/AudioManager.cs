using System.Collections.Generic;
using UnityEngine;

public enum GameSounds
{
    MainTheme
}

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource audioSource;

    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();
    public Dictionary<GameSounds, AudioClip> clipList = new Dictionary<GameSounds, AudioClip> { };

    private void Awake()
    {
        Instance = this;
        audioSource = GetComponent<AudioSource>();

        clipList.Add(GameSounds.MainTheme, audioClips[0]);
    }
    public void PlaySound(AudioClip clip, GameSounds sound)
    {
        if (Instance.clipList.TryGetValue(sound, out clip))
        {
            audioSource.clip = clip;
            audioSource.Play();
        }
    }
}