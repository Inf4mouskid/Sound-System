using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{
    public Text text;
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
        text.text = Manager.GetCurrentSong().ToString();
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
    /// Cuts to the next song to play.
    ///</summary>
    public void FadeTransition(string Name)
    {
        var Manager = FindObjectOfType<AudioManager>();
        Manager.StopMusic();
        // Next song to play.
        Manager.Play(Name);
    }
}
