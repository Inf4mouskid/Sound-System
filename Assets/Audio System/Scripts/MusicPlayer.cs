using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{
    AudioManager Manager = FindObjectOfType<AudioManager>();

    void Start()
    {
        if (Manager.isPlaying)
        {
            foreach (var Audio in Manager.Sounds)
            {
                if (Audio.AudioGroup.ToString() == "Music")
                    Manager.Stop("");
            }
        }
        Manager.Play("");
    }

    void transition()
    {
    }
}
