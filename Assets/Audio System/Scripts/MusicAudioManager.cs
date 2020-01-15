using System;
using UnityEngine;
using UnityEngine.Audio;

public class MusicAudioManager : MonoBehaviour
{
    public AudioMixerGroup MusicGroup;
    public Sound[] Themes;

    public static MusicAudioManager Instance;

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

        foreach (var Theme in Themes)
        {
            Theme.source = gameObject.AddComponent<AudioSource>();
            Theme.source.clip = Theme.clip;
            Theme.source.outputAudioMixerGroup = MusicGroup;
            Theme.source.playOnAwake = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Properties updatable in game
        foreach (var Theme in Themes)
        {
            Theme.source.volume = Theme.volume;
            Theme.source.mute = Theme.mute;
            Theme.source.loop = Theme.loop;
            Theme.source.pitch = Theme.pitch;
        }
    }

    /// <summary>
    /// Plays an audio file by name. (in other scripts use 'FindObjectOfType')
    /// </summary>
    public void Play(string Name)
    {
        var Theme = Array.Find(Themes, sound => sound.name == Name);
        if (Theme == null)
            return;
        Theme.source.Play();
    }

    /// <summary>
    /// Mutes all the audio in the game
    /// </summary>
    public void Mute()
    {
        foreach (var Theme in Themes) Theme.mute = !Theme.mute;
    }

    ///<summary>
    /// Stops an audio from playing
    ///</summary>
    public void Stop(string Name)
    {
        var Theme = Array.Find(Themes, sound => sound.name == Name);
        if (Theme == null)
            return;
        if (Theme.source.isPlaying)
            Theme.source.Stop();
    }

    ///<summary>
    /// Stops all audio from playing
    ///</summary>
    public void StopAll()
    {
        foreach (var Theme in Themes)
        {
            if (Theme.source.isPlaying)
                Theme.source.Stop();
        }
    }

    /// <summary>
    /// Gets the name of the song currently playing.
    /// </summary>
    public string GetCurrentSong()
    {
        string AudioName = "";
        foreach (var Theme in Themes)
        {
            if (Theme.source.isPlaying)
                AudioName = Theme.name;
        }
        return AudioName;
    }

    /// <summary>
    /// Gets the volume of the song currently playing.
    /// </summary>
    public float GetCurrentSongVolume()
    {
        float Volume = 0;
        foreach (var Theme in Themes)
        {
            if (Theme.source.isPlaying)
                Volume = Theme.volume;
        }
        return Volume;
    }

    /// <summary>
    /// Allows the audio to fade out for a transition
    /// </summary>
    public void SetFadeOutVolume(float Volume)
    {
        foreach (var Theme in Themes)
        {
            if (Theme.source.isPlaying)
                Theme.volume -= Volume;
        }
    }

    /// <summary>
    /// Allows the audio to fade out for a transition
    /// </summary>
    public void SetFadeInVolume(float Volume)
    {
        foreach (var Theme in Themes)
        {
            if (Theme.source.isPlaying)
                Theme.volume += Volume;
        }
    }

    public void SetSourceVolume(float Volume)
    {
        foreach (var Theme in Themes)
        {
            if (Theme.source.isPlaying)
                Theme.volume = Volume;
        }
    }
}
