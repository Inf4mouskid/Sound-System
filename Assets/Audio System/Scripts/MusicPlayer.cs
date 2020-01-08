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
        var Manager = FindObjectOfType<AudioManager>();
        TMP_Text.text = Manager.GetCurrentSong();
        //text.text = Manager.GetCurrentSong();
    }

    ///<summary>
    /// Cuts to the next song to play.
    ///</summary>
    public void CutTransition(string Name)
    {
        var Manager = FindObjectOfType<AudioManager>();
        Manager.StopMusic();
        // Next song to play.
        Manager.Play(Name);
    }

    ///<summary>
    /// Fades to the next song to play.
    ///</summary>
    public void FadeOut()
    {
        var Manager = FindObjectOfType<AudioManager>();
        StartCoroutine(FadeOutAlgorithm());
    }

    IEnumerator FadeOutAlgorithm()
    {
        var Manager = FindObjectOfType<AudioManager>();
        while (Manager.GetCurrentSongVolume() > 0f)
        {
            Manager.SetFadeOutVolume(Time.deltaTime / SecondsToFade);
            yield return null;
            if (Manager.GetCurrentSongVolume() > 0f && Manager.GetCurrentSongVolume() < 0.001f)
                Manager.SetSourceVolume(0);
        }
        Manager.SetSourceVolume(1);
        Manager.StopMusic();
    }
}
