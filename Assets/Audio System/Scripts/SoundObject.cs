using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[CreateAssetMenu(menuName = "Audio Collection", fileName = "Sound Collection")]
public class SoundObject : ScriptableObject
{
    public AudioMixerGroup Group;
    public Sound[] SoundFiles;
}
