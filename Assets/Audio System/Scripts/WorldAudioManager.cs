using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WorldAudioManager : MonoBehaviour
{
    public AudioMixerGroup Group;
    public List<AudioSource> Sources;
    AudioSource Source;
    string AudioTag = "Audio";
    bool IsMute = false;

    public static WorldAudioManager Instance;

    void Awake()
    {

        // Keep the game object Active between scenes
        if (Instance != null) Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // Sets the values for each audio sources
    }

    void Update()
    {

    }
}
