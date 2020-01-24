using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WorldAudioManager : MonoBehaviour
{
    public AudioMixerGroup World;
    public GameObject[] Appliances;
    public Sound[] sounds;

    public static WorldAudioManager Instance;

    void Awake()
    {
        if (Instance != null)
            Destroy(gameObject);
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        // Sets the values for each audio sources
        foreach (var item in Appliances)
        {
            foreach (var Audio in sounds)
            {
                Audio.source = item.AddComponent<AudioSource>();
                Audio.source.clip = Audio.clip;
                Audio.source.outputAudioMixerGroup = World;
                Audio.SpacialBlend = 1;
                Audio.source.spatialBlend = Audio.SpacialBlend;
            }
        }
    }
}
