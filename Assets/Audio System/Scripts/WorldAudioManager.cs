using System;
using UnityEngine;
using UnityEngine.Audio;

public class WorldAudioManager : MonoBehaviour
{
    [SerializeField, Range(0f, 1f)] private float InitialVolume = 1f;
    [SerializeField] private AudioMixerGroup Group = null;
    public Sound3D[] Audio;
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

    }

    // Update is called once per frame
    void Update()
    {

    }
}
