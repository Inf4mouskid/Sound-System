using System;
using UnityEngine;
using UnityEngine.Audio;

public class WorldAudioManager : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float InitialVolume = 1f;
    [SerializeField] private AudioMixerGroup Group = null;
    public Sound3D[] AudioClips;
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
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var AudioClip in AudioClips)
        { 
            AudioClip.volume = InitialVolume;
            AudioClip.source.outputAudioMixerGroup = Group;
            var ObjectAudio = AudioClip.WorldObject.GetComponent<AudioSource>();
            if (ObjectAudio != null) AudioClip.WorldObject.AddComponent<AudioSource>();
            ObjectAudio = AudioClip.source;
        }
    }
}
