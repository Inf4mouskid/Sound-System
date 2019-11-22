using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    void Start()
    {
        if (FindObjectOfType<AudioManager>().isPlaying)
        {
            foreach (var s in FindObjectOfType<AudioManager>().Sounds)
            {
                if (s.AudioGroup.ToString() == "Music")
                    FindObjectOfType<AudioManager>().Stop("");
            }
        }
        FindObjectOfType<AudioManager>().Play("");
    }
}
