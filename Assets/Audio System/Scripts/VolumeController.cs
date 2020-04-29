using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    const int LOG_FORMAT = 20;
    [SerializeField] AudioMixer Mixer = null;

    public static VolumeController Instance;

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

    /// <summary>
    /// Adjust the Master volume of the game.
    /// </summary>
    public void Volume(float Vol)
    {
        Mixer.SetFloat("MasterVol", Mathf.Log10(Vol) * LOG_FORMAT);
    }

    /// <summary>
    /// Adjust the volume of the menu sounds.
    /// </summary>
    public void MenuVolume(float Vol)
    {
        Mixer.SetFloat("MenuVol", Mathf.Log10(Vol) * LOG_FORMAT);
    }

    /// <summary>
    /// Adjust the volume of the music.
    /// </summary>
    public void MusicVolume(float Vol)
    {
        Mixer.SetFloat("MusicVol", Mathf.Log10(Vol) * LOG_FORMAT);
    }

    /// <summary>
    /// Adjust the volume of the world sound FX.
    /// </summary>
    public void SoundVolume(float Vol)
    {
        Mixer.SetFloat("SoundVol", Mathf.Log10(Vol) * LOG_FORMAT);
    }
}
