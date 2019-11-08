using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    public AudioMixer Mixer;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Adjust the volume of the game.
    /// </summary>
    public void Volume(float Vol)
    {
        //Mixer.SetFloat("MasterVol", Mathf.Log10(Vol) * LOG_FORMAT);
        Mixer.SetFloat("MasterVol", Vol);
    }

    /// <summary>
    /// Adjust the volume of the game.
    /// </summary>
    public void MenuVolume(float Vol)
    {
        // Mixer.SetFloat("MenuVol", Mathf.Log10(Vol) * LOG_FORMAT);
        Mixer.SetFloat("MenuVol", Vol);
    }

    /// <summary>
    /// Adjust the volume of the game.
    /// </summary>
    public void MusicVolume(float Vol)
    {
        // Mixer.SetFloat("MusicVol", Mathf.Log10(Vol) * LOG_FORMAT);
        Mixer.SetFloat("MusicVol", Vol);
    }

    /// <summary>
    /// Adjust the volume of the game.
    /// </summary>
    public void SoundVolume(float Vol)
    {
        // Mixer.SetFloat("SoundVol", Mathf.Log10(Vol) * LOG_FORMAT);
        Mixer.SetFloat("SoundVol", Vol);
    }
}
