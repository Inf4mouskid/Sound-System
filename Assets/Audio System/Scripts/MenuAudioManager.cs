using System;
using UnityEngine;
using UnityEngine.Audio;

public class MenuAudioManager : MonoBehaviour
{
    public AudioMixerGroup MenuGroup;
    public Sound[] MenuSounds;

    public static MenuAudioManager Instance;

    // Use this for initialization
    void Awake()
    {
        // Keep the game object Active between scenes
        if (Instance != null) Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        foreach (var Audio in MenuSounds)
        {
            Audio.source = gameObject.AddComponent<AudioSource>();
            Audio.source.clip = Audio.clip;
            Audio.source.outputAudioMixerGroup = MenuGroup;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Properties updatable in game
        foreach (var Audio in MenuSounds)
        {
            Audio.source.volume = Audio.volume;
            Audio.source.mute = Audio.mute;
            Audio.source.loop = Audio.loop;
            Audio.source.pitch = Audio.pitch;
        }
    }

    /// <summary>
    /// Plays an audio file by name. (in other scripts use 'FindObjectOfType')
    /// </summary>
    public void Play(string Name)
    {
        var Audio = Array.Find(MenuSounds, sound => sound.name == Name);
        if (Audio == null)
            return;
        Audio.source.Play();
    }

    /// <summary>
    /// Mutes all the audio in the game
    /// </summary>
    public void MuteAll()
    {
        foreach (var Audio in MenuSounds) Audio.mute = !Audio.mute;
    }

    ///<summary>
    /// Stops all audio from playing
    ///</summary>
    public void StopAll()
    {
        foreach (var Audio in MenuSounds)
        {
            if (Audio.source.isPlaying)
                Audio.source.Stop();
        }
    }
}
