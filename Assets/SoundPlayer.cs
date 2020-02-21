using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayer : MonoBehaviour
{
    private AudioTransitions AudioEffects;

    // Start is called before the first frame update
    void Start()
    {
        AudioEffects = FindObjectOfType<AudioTransitions>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            AudioEffects.Cut("Tense Theme");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            AudioEffects.CrossFade("Action Theme", 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            AudioEffects.Cut("Tense Theme");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            AudioEffects.Cut("Tense Theme");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            AudioEffects.Cut("Tense Theme");
        }
    }
}
