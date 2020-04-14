using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTransitions : MonoBehaviour
{
    const float MAX_VOL = 1f;
    const float MIN_VOL = 0f;
    private MusicManager Music;
    private float SecondsToFade = 0f;

    void Start()
    {
        Music = GetComponent<MusicManager>();
    }

    #region Effects
    ///<summary>
    /// Cuts to the next song to play.
    ///</summary>
    public void Cut(string Name)
    {
        Music.Stop();
        Music.Play(Name); // Next song to play.
    }

    ///<summary>
    /// Fades into the current song.
    ///</summary>
    public void FadeIn(string Name)
    {
        Music.Play(Name);
        StartCoroutine(FadeInAlgorithm(Name, SecondsToFade));
    }

    ///<summary>
    /// Fades out of the current song.
    ///</summary>
    public void FadeOut(string Name)
    {
        StartCoroutine(FadeOutAlgorithm(Name, SecondsToFade));
    }

    ///<summary>
    ///Cross fade between two themes.
    ///</summary>
    public void CrossFade(string Song)
    {
        var SongPlaying = Music.CurrentSong();
        FadeIn(Song);
        FadeOut(SongPlaying);
    }
    #endregion

    ///<summary>
    /// Randomly selects a song to play with fading.
    ///</summary>
    public void ShufflePlay()
    {
        int RandomIndexSelection = RandomIndex(); // picks a song by it's index
        string SongName = Music.GetSongByIndex(RandomIndexSelection); // Get's the name of a song
        while (SongName == Music.CurrentSong())
        {
            RandomIndexSelection = RandomIndex();
            SongName = Music.GetSongByIndex(RandomIndexSelection);
        }
        CrossFade(SongName);
    }

    ///<summary>
    /// Randomly selects a song to play with fading that isnt a specific theme
    ///</summary>
    public void ShufflePlay(string Theme)
    {
        int RandomIndexSelection = RandomIndex(); // picks a song by it's index
        string SongName = Music.GetSongByIndex(RandomIndexSelection); // Get's the name of a song
        while (SongName == Theme || SongName == Music.CurrentSong())
        {
            RandomIndexSelection = RandomIndex();
            SongName = Music.GetSongByIndex(RandomIndexSelection);
        }
        CrossFade(SongName);
    }

    ///<summary>
    /// Set the time it takes for the audio to fade in or out.
    ///</summary>
    public void SetFadeTime(float Time)
    {
        SecondsToFade = Time;
    }

    private int RandomIndex()
    {
        return UnityEngine.Random.Range(0, Music.Themes.Length);
    }

    // Algorithm used to make audio fade in.
    IEnumerator FadeInAlgorithm(string Name, float SecondsToFade)
    {
        Music.SetVolume(Name, MIN_VOL);
        while (Music.GetSongVolume(Name) < MAX_VOL)
        {
            yield return null;
            Music.VolumeUp(Name, Time.deltaTime / SecondsToFade);
            if (Music.GetSongVolume(Name) < MAX_VOL && Music.GetSongVolume(Name) > 0.95f)
                Music.SetVolume(Name, MAX_VOL);
        }
    }

    // Algorithm used to make audio fade out.
    IEnumerator FadeOutAlgorithm(string Name, float SecondsToFade)
    {
        // Safety check to make sure audio
        // smoothly transitions from Max volume to 
        if (Music.GetSongVolume(Name) < MAX_VOL) Music.SetVolume(Name, MAX_VOL);

        // 
        while (Music.GetSongVolume(Name) > 0.05f)
        {
            yield return null;
            Music.VolumeDown(Name, Time.deltaTime / SecondsToFade);
            if (Music.GetSongVolume(Name) > MIN_VOL && Music.GetSongVolume(Name) < 0.05f)
                Music.SetVolume(Name, MIN_VOL);
        }
        Music.SetVolume(Name, MAX_VOL);
        Music.Stop(Name);
    }
}
