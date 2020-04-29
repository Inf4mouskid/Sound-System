using UnityEngine;
using UnityEngine.UI;

public class AudioStart : MonoBehaviour
{
    public Button PlayButton = null;
    private AudioTransitions Effects;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = PlayButton.GetComponent<Button>();
        Effects = FindObjectOfType<AudioTransitions>();
        btn.onClick.AddListener(TaskOnClick);
    }

    void TaskOnClick()
    {
        Effects.SecondsToFade = 2f;
        Effects.CrossFade("Action Theme");
    }

}
