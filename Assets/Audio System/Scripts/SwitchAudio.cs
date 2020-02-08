using UnityEngine;

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

    public void SwitchSound()
    {
        if (index < Bank.Clips.Length) index++;
        GetComponent<AudioSource>().clip = Bank.Clips[index];
    }

    public void ResetIndex()
    {
        index = 0;
    }
}
