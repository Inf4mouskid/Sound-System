using UnityEngine;
using UnityEngine.Audio;

[RequireComponent(typeof(AudioSource))]
public class SwitchAudio : MonoBehaviour
{
    public AudioBank Bank;
    private int index = 0;
    private AudioSource Source;

    // Start is called before the first frame update
    void Start()
    {
        Source = GetComponent<AudioSource>();
        Source.clip = Bank.Clips[index];
    }

    ///<summary>
    /// Switches the clip in the audio 
    ///</summary>
    public void SwitchSound()
    {
        if (index < Bank.Clips.Length) index++;
        GetComponent<AudioSource>().clip = Bank.Clips[index];
    }

    ///<summary>
    /// Resets the audio index
    ///</summary>
    public void ResetIndex()
    {
        index = 0;
    }
}
