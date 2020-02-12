using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    private MusicAudioManager MusicManager;
    public static MusicPlayer Instance;

    void Awake()
    {
        // Keep the game object Active between scenes
        if (Instance != null) Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        MusicManager = FindObjectOfType<MusicAudioManager>();
    }

    ///<summary>
    /// Cuts to the next song to play.
    ///</summary>
    public void CutTransition(string Name)
    {
        MusicManager.Stop();
        MusicManager.Play(Name); // Next song to play.
    }

    ///<summary>
    /// Fades into the current song.
    ///</summary>
    public void FadeIn(string Name, float SecondsToFade)
    {
        MusicManager.Play(Name);
        StartCoroutine(FadeInAlgorithm(Name, SecondsToFade));
    }

    ///<summary>
    /// Fades out of the current song.
    ///</summary>
    public void FadeOut(string Name, float SecondsToFade)
    {
        StartCoroutine(FadeOutAlgorithm(Name, SecondsToFade));
    }

    ///<summary>
    ///Cross fade between to themes.
    ///</summary>
    public void CrossFade(string Song1, string Song2, float SecondsToFade)
    {
        FadeIn(Song2, SecondsToFade);
        FadeOut(Song1, SecondsToFade);
    }

    // Algorithm used to make audio fade in.
    IEnumerator FadeInAlgorithm(string Name, float SecondsToFade)
    {
        MusicManager.SetVolume(Name, 0f);
        while (MusicManager.GetSongVolume(Name) < 1f)
        {
            MusicManager.VolumeUp(Name, Time.deltaTime / SecondsToFade);
            yield return null;
            if (MusicManager.GetSongVolume(Name) < 1f && MusicManager.GetSongVolume(Name) > 0.99f)
                MusicManager.SetVolume(Name, 1f);
        }
    }

    // Algorithm used to make audio fade out.
    IEnumerator FadeOutAlgorithm(string Name, float SecondsToFade)
    {
        while (MusicManager.GetSongVolume(Name) > 0.01f)
        {
            MusicManager.VolumeDown(Name, Time.deltaTime / SecondsToFade);
            yield return null;
            if (MusicManager.GetSongVolume(Name) > 0f && MusicManager.GetSongVolume(Name) < 0.01f)
                MusicManager.SetVolume(Name, 0f);
        }
        MusicManager.SetVolume(Name, 1f);
        MusicManager.Stop(Name);
    }
}
