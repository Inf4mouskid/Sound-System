using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioActivator : MonoBehaviour
{
    public float FadeTime = 5f;
    MusicAudioManager Music;
    AudioTransitions Player;

    // Start is called before the first frame update
    void Start()
    {
        Music = FindObjectOfType<MusicAudioManager>();
        Player = FindObjectOfType<AudioTransitions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Player.FadeIn("Tense Theme", FadeTime);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Player.CrossFade("Action Theme", FadeTime);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Player.CrossFade("Love Theme", FadeTime);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Player.CrossFade("Horror Theme", FadeTime);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Music.Stop();
        }
    }
}
