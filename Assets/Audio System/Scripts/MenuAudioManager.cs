using System;
using UnityEngine;
using UnityEngine.Audio;

public class MenuAudioManager : MonoBehaviour
{
    [SerializeField] AudioMixerGroup Group = null;
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
            Audio.source.outputAudioMixerGroup = Group;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Properties updatable in game
        foreach (var Audio in MenuSounds)
        {
            Audio.source.volume = Audio.volume;
            Audio.source.pitch = Audio.pitch;
        }
    }

    /// <summary>
    /// Plays an audio file by name. (usage in other scripts -> 'FindObjectOfType')
    /// </summary>
    public void Play(string Name)
    {
        var Audio = Array.Find(MenuSounds, sound => sound.name == Name);
        if (Audio == null)
            return;
        Audio.source.Play();
    }

    ///<summary>
    /// Stops all audio from playing
    ///</summary>
    public void Stop()
    {
        foreach (var Audio in MenuSounds)
        {
            if (Audio.source.isPlaying)
                Audio.source.Stop();
        }
    }
}
