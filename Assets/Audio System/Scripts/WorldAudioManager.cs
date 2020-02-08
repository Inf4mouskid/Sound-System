using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class WorldAudioManager : MonoBehaviour
{
    public AudioMixerGroup World;
    public GameObject[] Appliances;

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
            if (item.GetComponent<AudioSource>() != null)
            {
                var Source = item.GetComponent<AudioSource>();
                Source.outputAudioMixerGroup = World;
            }
            else
            {
                var childSource = item.GetComponentInChildren<AudioSource>();
                childSource.outputAudioMixerGroup = World;
            }
        }
    }
}
