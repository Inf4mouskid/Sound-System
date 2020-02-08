using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    public TextMeshProUGUI DisplayText;
    [Range(0.5f, 20f)] public float SecondsToFade = 1f;
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

    void Update()
    {
        //Displays the current song being played
        if (DisplayText != null)
            DisplayText.text = MusicManager.GetCurrentSong();
    }

    ///<summary>
    /// Cuts to the next song to play.
    ///</summary>
    public void CutTransition(string Name)
    {
        MusicManager.StopAll();
        MusicManager.Play(Name); // Next song to play.
    }

    ///<summary>
    /// Fades out of the current song.
    ///</summary>
    public void FadeOut()
    {
        StartCoroutine(FadeOutAlgorithm());
    }

    ///<summary>
    /// Fades into the current song.
    ///</summary>
    public void FadeIn()
    {
        StartCoroutine(FadeInAlgorithm());
    }

    // Algorithm used to make audio fade out.
    IEnumerator FadeOutAlgorithm()
    {
        while (MusicManager.GetCurrentSongVolume() > 0f)
        {
            MusicManager.SetFadeOutVolume(Time.deltaTime / SecondsToFade);
            yield return null;
            if (MusicManager.GetCurrentSongVolume() > 0f && MusicManager.GetCurrentSongVolume() < 0.001f)
                MusicManager.SetSourceVolume(0);
        }
        MusicManager.SetSourceVolume(1);
        MusicManager.StopAll();
    }

    // Algorithm used to make audio fade in.
    IEnumerator FadeInAlgorithm()
    {
        MusicManager.SetSourceVolume(0);
        while (MusicManager.GetCurrentSongVolume() < 1f)
        {
            MusicManager.SetFadeInVolume(Time.deltaTime / SecondsToFade);
            yield return null;
            if (MusicManager.GetCurrentSongVolume() < 1f && MusicManager.GetCurrentSongVolume() > 0.99f)
                MusicManager.SetSourceVolume(1);
        }
    }

    IEnumerator CrossFadeAlgorithm()
    {
        MusicManager.SetSourceVolume(0);
        while (MusicManager.GetCurrentSongVolume() < 1f)
        {
            MusicManager.SetFadeInVolume(Time.deltaTime / SecondsToFade);
            yield return null;
            if (MusicManager.GetCurrentSongVolume() < 1f && MusicManager.GetCurrentSongVolume() > 0.99f)
                MusicManager.SetSourceVolume(1);
        }
    }
}
