using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public Sound[] Sounds;

    // Use this for initialization
    void Awake()
    {
        // Keep the game object Active between scenes
        DontDestroyOnLoad(gameObject);

        foreach (var Audio in Sounds)
        {
            Audio.source = gameObject.AddComponent<AudioSource>();
            Audio.source.clip = Audio.clip;
            Audio.source.outputAudioMixerGroup = Audio.AudioGroup;
            Audio.source.volume = Audio.volume;
            Audio.source.loop = Audio.Loop;
        }
    }

    void Update()
    {
        // Properties updatable in game
        foreach (var Audio in Sounds)
        {
            Audio.source.mute = Audio.Mute;
            Audio.source.pitch = Audio.pitch;
        }
    }

    /// <summary>
    /// Plays an audio file by name. (in other scripts use 'FindObjectOfType')
    /// </summary>
    public void Play(string Name)
    {
        var s = Array.Find(Sounds, sound => sound.name == Name);
        if (s == null)
            return;
        s.source.Play();
    }

    /// <summary>
    /// Mutes a specific piece of audio
    /// </summary>
    public void Mute(string Name)
    {
        var s = Array.Find(Sounds, sound => sound.name == Name);
        if (s == null)
            return;
        s.Mute = !s.Mute;
    }

    /// <summary>
    /// Mutes all the audio in the game
    /// </summary>
    public void MuteAll()
    {
        foreach (var s in Sounds) s.Mute = !s.Mute;
    }

    ///<summary>
    /// Stops the selected audio from playing
    ///</summary>
    public void Stop(string Name)
    {
        var s = Array.Find(Sounds, sound => sound.name == Name);
        if (s == null)
            return;
        s.source.Stop();
    }

    ///<summary>
    /// Stops all audio from playing
    ///</summary>
    public void StopAll()
    {
        foreach (var Audio in Sounds)
        {
            if (Audio.source.isPlaying)
                Audio.source.Stop();
        }
    }
}
