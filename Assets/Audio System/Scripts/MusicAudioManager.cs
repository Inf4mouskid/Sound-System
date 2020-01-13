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
        var Audio = Array.Find(Themes, sound => sound.name == Name);
        if (Audio == null)
            return;
        Audio.source.Play();
    }

    /// <summary>
    /// Mutes all the audio in the game
    /// </summary>
    public void Mute()
    {
        foreach (var Audio in Themes) Audio.mute = !Audio.mute;
    }

    ///<summary>
    /// Stops an audio from playing
    ///</summary>
    public void Stop(string Name)
    {
        var Audio = Array.Find(Themes, sound => sound.name == Name);
        if (Audio == null)
            return;
        if (Audio.source.isPlaying)
            Audio.source.Stop();
    }

    ///<summary>
    /// Stops all audio from playing
    ///</summary>
    public void StopAll()
    {
        foreach (var Audio in Themes)
        {
            if (Audio.source.isPlaying)
                Audio.source.Stop();
        }
    }

    /// <summary>
    /// Gets the name of the song currently playing.
    /// </summary>
    public string GetCurrentSong()
    {
        string AudioName = "";
        foreach (var Audio in Themes)
        {
            if (Audio.source.isPlaying)
                AudioName = Audio.name;
        }
        return AudioName;
    }

    /// <summary>
    /// Gets the volume of the song currently playing.
    /// </summary>
    public float GetCurrentSongVolume()
    {
        float Volume = 0;
        foreach (var Audio in Themes)
        {
            if (Audio.source.isPlaying)
                Volume = Audio.volume;
        }
        return Volume;
    }

    /// <summary>
    /// Allows the audio to fade out for a transition
    /// </summary>
    public void SetFadeOutVolume(float Volume)
    {
        foreach (var Audio in Themes)
        {
            if (Audio.source.isPlaying)
                Audio.volume -= Volume;
        }
    }

    public void SetSourceVolume(float Volume)
    {
        foreach (var Audio in Themes)
        {
            if (Audio.source.isPlaying)
                Audio.volume = Volume;
        }
    }
}
