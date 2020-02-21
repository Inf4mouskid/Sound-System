using UnityEngine;
using UnityEngine.Audio;

public class VolumeController : MonoBehaviour
{
    const int LOG_FORMAT = 65;
    [SerializeField] AudioMixer Mixer;

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
    /// Adjust the volume of the game.
    /// </summary>
    public void Volume(float Vol)
    {
        // Debug.Log("Volume: " + Mathf.Log10(Vol) * LOG_FORMAT);
        // Mixer.SetFloat("MasterVol", Mathf.Log10(Vol) * LOG_FORMAT);
        Mixer.SetFloat("MasterVol", Vol);
    }

    /// <summary>
    /// Adjust the volume of the game.
    /// </summary>
    public void MenuVolume(float Vol)
    {
        // Debug.Log("Menu: " + Mathf.Log10(Vol) * LOG_FORMAT);
        // Mixer.SetFloat("MenuVol", Mathf.Log10(Vol) * LOG_FORMAT);
        Mixer.SetFloat("MenuVol", Vol);
    }

    /// <summary>
    /// Adjust the volume of the game.
    /// </summary>
    public void MusicVolume(float Vol)
    {
        // Debug.Log("Music: " + Mathf.Log10(Vol) * LOG_FORMAT);
        // Mixer.SetFloat("MusicVol", Mathf.Log10(Vol) * LOG_FORMAT);
        Mixer.SetFloat("MusicVol", Vol);
    }

    /// <summary>
    /// Adjust the volume of the game.
    /// </summary>
    public void SoundVolume(float Vol)
    {
        // Debug.Log("Sound: " + Mathf.Log10(Vol) * LOG_FORMAT);
        // Mixer.SetFloat("SoundVol", Mathf.Log10(Vol) * LOG_FORMAT);
        Mixer.SetFloat("SoundVol", Vol);
    }
}
