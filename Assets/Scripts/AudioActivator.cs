using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioActivator : MonoBehaviour
{
    public InputField InputAlt;
    MusicAudioManager Music;
    AudioTransitions Player;
    float FadeRate = 0f;

    // Start is called before the first frame update
    void Start()
    {
        Music = FindObjectOfType<MusicAudioManager>();
        Player = FindObjectOfType<AudioTransitions>();
    }

    public void FadeTime(string Time)
    {
        FadeRate = Convert.ToSingle(Time);
    }

    public void SwapFade(string Song)
    {
        Player.CrossFade(Song, FadeRate);
    }
}
