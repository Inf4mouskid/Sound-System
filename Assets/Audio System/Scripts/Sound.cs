using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    [Header("Data")]

    [Tooltip("Name of the sound.")]
    public string name; // Name of the sound

    [Tooltip("Sound file to play in game")]
    public AudioClip clip; // Sound file to play

    [Tooltip("Set the audio mixer channel to control the in-game Volume.")]
    public AudioMixerGroup AudioGroup; // Mixer group used to control the volume

    [Header("Attributes")]

    [Tooltip("Adjust the volume of the Audio.")]
    [Range(0f, 1f)]
    public float volume = 1f; // Set the volume of the audio

    [Tooltip("Adjust the pitch of the Audio.")]
    [Range(0.1f, 3f)]
    public float pitch = 1f; // Set the pitch of the audio
    
    [Tooltip("Set whether or not the audio is muted.")]
    public bool mute; // Sets whether or the audio should loop

    [Tooltip("Set whether or not the audio is looping.")]
    public bool loop; // Sets whether or the audio should loop

    [HideInInspector] public AudioSource source;
}
