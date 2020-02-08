using UnityEngine.Audio;
using UnityEngine;

[CreateAssetMenu(fileName = "Bank", menuName = "Audio Group")]
public class AudioBank : ScriptableObject
{
    public AudioClip[] Clips;
}
