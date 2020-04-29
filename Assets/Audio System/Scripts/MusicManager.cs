using System;
using UnityEngine;
using UnityEngine.Audio;

public class MusicManager : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float InitialVolume = 1f;
    [SerializeField, Range(0.1f, 3f)] private float InitialPitch = 1f;
    [SerializeField] private AudioMixerGroup Group = null;
    public Sound[] Themes;

    public static MusicManager Instance;

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
            Theme.source.outputAudioMixerGroup = Group;
            Theme.source.loop = Theme.loop;
            Theme.source.playOnAwake = false;
            Theme.volume = InitialVolume;
            Theme.pitch = InitialPitch;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Properties updatable in game
        foreach (var Theme in Themes)
        {
            Theme.source.volume = Theme.volume;
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

    ///<summary>
    /// Stops all audio from playing
    ///</summary>
    public void Stop()
    {
        foreach (var Theme in Themes)
        {
            if (Theme.source.isPlaying)
                Theme.source.Stop();
        }
    }

    ///<summary>
    /// Stops a specific song from playing
    ///</summary>
    public void Stop(string Name)
    {
        var Theme = Array.Find(Themes, sound => sound.name == Name);
        if (Theme == null)
            return;
        Theme.source.Stop();
    }

    ///<summary>
    /// Randomly selects a song to play
    ///</summary>
    public void ShufflePlay()
    {
        Stop();
        var RandomIndexSelection = UnityEngine.Random.Range(0, Themes.Length);
        Themes[RandomIndexSelection].source.Play();
    }

    ///<summary>
    /// Randomly selects a song to play that isn't a specified theme
    ///</summary>
    public void ShufflePlay(string MainTheme)
    {
        Stop();
        var RandomIndexSelection = UnityEngine.Random.Range(0, Themes.Length);
        bool MainThemeCheck = Themes[RandomIndexSelection].name.Equals(MainTheme);
        if (MainThemeCheck)
            ShufflePlay(MainTheme);
        Themes[RandomIndexSelection].source.Play();
    }

    ///<summary>
    /// Returns the specified songs volume (Read only)
    ///</summary>
    public float GetSongVolume(string Name)
    {
        float Volume = 0;
        var Theme = Array.Find(Themes, sound => sound.name == Name);
        if (Theme != null)
            Volume = Theme.volume;
        return Volume;
    }

    ///<summary>
    /// Returns the name of the song currently playing. (Read only)
    ///</summary>
    public string CurrentSong()
    {
        string Name = null;
        foreach (var Theme in Themes)
        {
            if (Theme.source.isPlaying)
                Name = Theme.name;
        }
        return Name;
    }

    ///<summary>
    /// Gets a song by it's index (Return string)
    ///</summary>
    public string GetSongByIndex(int Index)
    {
        string SongName = null;
        SongName = Themes[Index].name;
        return SongName;
    }

    ///<summary>
    /// Allows a specific peice of audio to go up in volume.
    ///</summary>
    public void VolumeUp(string Name, float Volume)
    {
        var Theme = Array.Find(Themes, sound => sound.name == Name);
        if (Theme != null)
            Theme.volume += Volume;
    }

    ///<summary>
    /// Allows a specific peice of audio to go down in volume.
    ///</summary>
    public void VolumeDown(string Name, float Volume)
    {
        var Theme = Array.Find(Themes, sound => sound.name == Name);
        if (Theme != null)
            Theme.volume -= Volume;
    }

    ///<summary>
    /// Sets the volume of a specific theme.
    ///</summary>
    public void SetVolume(string Name, float Vol)
    {
        var Theme = Array.Find(Themes, sound => sound.name == Name);
        if (Theme == null)
            return;
        Theme.volume = Vol;
    }
}
