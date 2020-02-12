using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioActivator : MonoBehaviour
{
    MusicAudioManager Music;
    MusicPlayer Player;

    // Start is called before the first frame update
    void Start()
    {
        Music = FindObjectOfType<MusicAudioManager>();
        Player = FindObjectOfType<MusicPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Player.FadeIn("Tense Theme", 5f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Player.FadeOut("Tense Theme", 5f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Player.FadeIn("Action Theme", 5f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            Player.FadeOut("Action Theme", 5f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            Player.CrossFade("Tense Theme", "Action Theme", 3f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Music.Stop();
        }
    }
}
