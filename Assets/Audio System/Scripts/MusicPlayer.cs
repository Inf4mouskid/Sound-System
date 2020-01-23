using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    public TextMeshProUGUI DisplayText;
    public TMP_InputField Input;
    [Range(0.5f, 20f)] public float SecondsToFade = 1f;
    public static MusicPlayer Instance;

    void Awake()
    {
        // Keep the game object Active between scenes
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {
        var MusicManager = FindObjectOfType<MusicAudioManager>();
        if (DisplayText != null)
            DisplayText.text = MusicManager.GetCurrentSong();
    }

    ///<summary>
    /// Cuts to the next song to play.
    ///</summary>
    public void CutTransition()
    {
        var MusicManager = FindObjectOfType<MusicAudioManager>();
        MusicManager.StopAll();
        // Next song to play.
        MusicManager.Play(Input.text);
    }

    ///<summary>
    /// Cuts to the next song to play.
    ///</summary>
    public void CutTransition(string Name)
    {
        var MusicManager = FindObjectOfType<MusicAudioManager>();
        MusicManager.StopAll();
        // Next song to play.
        MusicManager.Play(Name);
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

    IEnumerator FadeOutAlgorithm()
    {
        var MusicManager = FindObjectOfType<MusicAudioManager>();
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

    IEnumerator FadeInAlgorithm()
    {
        var MusicManager = FindObjectOfType<MusicAudioManager>();
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
