using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongDisplay : MonoBehaviour
{
    private Text TextObject = null;
    private MusicManager Music;

    // Start is called before the first frame update
    void Start()
    {
        Music = FindFirstObjectByType<MusicManager>();
        TextObject = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        TextObject.text = Music.CurrentSong();
    }
}
