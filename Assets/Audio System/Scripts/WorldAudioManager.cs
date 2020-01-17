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
    }

    // Start is called before the first frame update
    void Start()
    {
        foreach (var item in Appliances)
        {
            if (item.GetComponent<AudioSource>() != null)
                item.GetComponent<AudioSource>().outputAudioMixerGroup = World;
        }
    }
}
