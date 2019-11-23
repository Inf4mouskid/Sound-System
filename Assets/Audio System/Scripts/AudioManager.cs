using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup[] AudioGroups;
    public Sound[] Sounds;

    public static AudioManager Instance;

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

        foreach (var Audio in Sounds)
        {
            Audio.source = gameObject.AddComponent<AudioSource>();
            Audio.source.clip = Audio.clip;
            if (Audio.AudioGroup == Sound.AudioType.Menu)
                Audio.source.outputAudioMixerGroup = AudioGroups[0];
            else if (Audio.AudioGroup == Sound.AudioType.Music)
                Audio.source.outputAudioMixerGroup = AudioGroups[1];
            else
                Audio.source.outputAudioMixerGroup = AudioGroups[2];
        }
    }

    void Update()
    {
        // Properties updatable in game
        foreach (var Audio in Sounds)
        {
            Audio.source.volume = Audio.volume;
            Audio.source.mute = Audio.Mute;
            Audio.source.loop = Audio.Loop;
            Audio.source.pitch = Audio.pitch;
        }
    }

    /// <summary>
    /// Plays an audio file by name. (in other scripts use 'FindObjectOfType')
    /// </summary>
    public void Play(string Name)
    {
        var Audio = Array.Find(Sounds, sound => sound.name == Name);
        if (Audio == null)
            return;
        Audio.source.Play();
    }

    #region Mute Audio
    /// <summary>
    /// Mutes all the audio in the game
    /// </summary>
    public void MuteAll()
    {
        foreach (var Audio in Sounds) Audio.Mute = !Audio.Mute;
    }

    /// <summary>
    /// Mutes all menu audio.
    /// </summary>
    public void MuteMenu()
    {
        foreach (var Audio in Sounds)
        {
            if (Audio.AudioGroup == Sound.AudioType.Menu)
                Audio.Mute = !Audio.Mute;
        }
    }

    /// <summary>
    /// Mutes all background music audio.
    /// </summary>
    public void MuteMusic()
    {
        foreach (var Audio in Sounds)
        {
            if (Audio.AudioGroup == Sound.AudioType.Music)
                Audio.Mute = !Audio.Mute;
        }
    }

    /// <summary>
    /// Mutes all background music audio.
    /// </summary>
    public void MuteSound()
    {
        foreach (var Audio in Sounds)
        {
            if (Audio.AudioGroup == Sound.AudioType.World)
                Audio.Mute = !Audio.Mute;
        }
    }
    #endregion

    #region Stop Audio
    ///<summary>
    /// Stops the selected audio from playing
    ///</summary>
    public void Stop(string Name)
    {
        var Audio = Array.Find(Sounds, sound => sound.name == Name);
        if (Audio == null)
            return;
        Audio.source.Stop();
    }

    /// <summary>
    /// Stops all menu audio.
    /// </summary>
    public void StopMenu()
    {
        foreach (var Audio in Sounds)
        {
            if (Audio.AudioGroup == Sound.AudioType.Menu)
                Audio.source.Stop();
        }
    }

    /// <summary>
    /// Stops all menu audio.
    /// </summary>
    public void StopMusic()
    {
        foreach (var Audio in Sounds)
        {
            if (Audio.AudioGroup == Sound.AudioType.Music)
                Audio.source.Stop();
        }
    }

    /// <summary>
    /// Stops all menu audio.
    /// </summary>
    public void StopSounds()
    {
        foreach (var Audio in Sounds)
        {
            if (Audio.AudioGroup == Sound.AudioType.World)
                Audio.source.Stop();
        }
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
    #endregion

    public string GetCurrentSong()
    {
        string AudioName = "";
        foreach (var Audio in Sounds)
        {
            if (Audio.source.outputAudioMixerGroup == AudioGroups[1] && Audio.source.isPlaying)
                AudioName = Audio.clip.name;
        }
        return AudioName;
    }
}
