using UnityEngine;
using UnityEngine.UI;

public class AudioStart : MonoBehaviour
{
    [SerializeField] private float FadeTime = 2f;
    [SerializeField] private string SongName = null;
    [SerializeField] private Button PlayButton = null;
    private AudioTransitions Effects;

    // Start is called before the first frame update
    void Start()
    {
        Effects = FindObjectOfType<AudioTransitions>();
        if (PlayButton != null)
            PlayButton.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Effects.SecondsToFade = FadeTime;
        Effects.CrossFade(SongName);
    }

}
