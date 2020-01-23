using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(AudioSource))]
public class SwitchAudio : MonoBehaviour
{
    public AudioClip[] clips;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SwitchSounds(clips[0]));
    }

    public void PlaySwitchingAudio()
    {
        StartCoroutine(SwitchSounds(clips[1]));
    }

    IEnumerator SwitchSounds(AudioClip Clip)
    {
        var Audio = GetComponent<AudioSource>();
        Audio.clip = Clip;
        Audio.Play();
        Debug.Log(Audio.clip.length);
        yield return new WaitForSeconds(Audio.clip.length);
    }
}
