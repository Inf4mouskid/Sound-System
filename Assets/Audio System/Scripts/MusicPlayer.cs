using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using TMPro;

public class MusicPlayer : MonoBehaviour
{
    public TextMeshProUGUI TMP_Text;
    [Range(0.1f, 20f)] public float SecondsToFade = 1f;
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
        TMP_Text.text = MusicManager.GetCurrentSong();
        //text.text = Manager.GetCurrentSong();
    }

    ///<summary>
    /// Cuts to the next song to play.
    ///</summary>
    public void CutTransition(string Name)
    {
        var MusicManager = FindObjectOfType<MusicAudioManager>();
        MusicManager.Stop();
        // Next song to play.
        MusicManager.Play(Name);
    }

    ///<summary>
    /// Fades to the next song to play.
    ///</summary>
    public void FadeOut()
    {
        var MusicManager = FindObjectOfType<MusicAudioManager>();
        StartCoroutine(FadeOutAlgorithm());
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
        MusicManager.Stop();
    }
}
