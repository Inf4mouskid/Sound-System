using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTransitions : MonoBehaviour
{
    MusicManager Music;
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
        var RandomIndexSelection = UnityEngine.Random.Range(0, Music.Themes.Length);
        var SongName = Music.GetSongIndex(RandomIndexSelection);
        CrossFade(SongName);
    }

    ///<summary>
    /// Randomly selects a song to play with fading that isnt a specific theme
    ///</summary>
    public void ShufflePlay(string Theme)
    {
        var RandomIndexSelection = UnityEngine.Random.Range(0, Music.Themes.Length);
        var RandomTheme = Music.Themes[RandomIndexSelection].name;
        if (RandomTheme == Theme)
        {
            Debug.Log(Theme + " (Should not be played!)");
            ShufflePlay(Theme);
        }
        var SongName = Music.GetSongIndex(RandomIndexSelection);
        CrossFade(SongName);
    }

    public void SetFadeTime(float Time)
    {
        SecondsToFade = Time;
    }

    // Algorithm used to make audio fade in.
    IEnumerator FadeInAlgorithm(string Name, float SecondsToFade)
    {
        Music.SetVolume(Name, 0f);
        while (Music.GetSongVolume(Name) < 1f)
        {
            Music.VolumeUp(Name, Time.deltaTime / SecondsToFade);
            yield return null;
            if (Music.GetSongVolume(Name) < 1f && Music.GetSongVolume(Name) > 0.95f)
                Music.SetVolume(Name, 1f);
        }
    }

    // Algorithm used to make audio fade out.
    IEnumerator FadeOutAlgorithm(string Name, float SecondsToFade)
    {
        while (Music.GetSongVolume(Name) > 0.05f)
        {
            Music.VolumeDown(Name, Time.deltaTime / SecondsToFade);
            yield return null;
            if (Music.GetSongVolume(Name) > 0f && Music.GetSongVolume(Name) < 0.05f)
                Music.SetVolume(Name, 0f);
        }
        Music.SetVolume(Name, 1f);
        Music.Stop(Name);
    }
}
