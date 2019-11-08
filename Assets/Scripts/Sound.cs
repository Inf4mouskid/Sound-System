using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    [Header("Data")]

    [Tooltip("Name of the sound for referrence")]
    public string name; // Name of the sound

    [Tooltip("Audio clip for use in the game")]
    public AudioClip clip; // Sound file

    [Tooltip("Add and audio mixer channel to control the in-game Volume")]
    public AudioMixerGroup AudioGroup;

    [Header("Attributes")]

    [Tooltip("Adjust the volume of the Audio")]
    [Range(0f, 1f)]
    public float volume = 1f; // Set the volume of the audio

    [Tooltip("Adjust the pitch of the Audio")]
    [Range(0.1f, 3f)]
    public float pitch = 1f; // Set the pitch of the audio

    [Tooltip("Determines whther the Audio is 2D or 3D")]
    [Range(0f, 1f)]
    public float spacialBlend; // Set the spacial area of the audio

    [Tooltip("Set whether or not the audio is muted")]
    public bool Mute; // Mute the audio

    [Tooltip("Set whether or not the audio is looping")]
    public bool Loop; // Sets whether or the audio should loop

    [HideInInspector] public AudioSource source;
}
