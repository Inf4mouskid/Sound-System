using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongTime : MonoBehaviour
{
    [SerializeField] private Text TextObject;
    private MusicManager Music;
    private int SongLength = 0;
    private int PlayTime = 0;
    private int Seconds = 0;
    private int Minutes = 0;

    // Start is called before the first frame update
    void Start()
    {
        Music = FindObjectOfType<MusicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        SongLength = (int)Music.CurrentSongLength();
        PlayTime = (int)Music.CurrentTime();
        ShowPlayTime();
    }

    void ShowPlayTime()
    {
        Seconds = PlayTime % 60;
        Minutes = (PlayTime / 60) % 60;
        //TextObject.text = Minutes + ":" + Seconds.ToString("D2");
        TextObject.text = "<b>" + Minutes + ":" + Seconds.ToString("D2") + "</b> / " + ((SongLength / 60) % 60) + ":" + (SongLength % 60).ToString("D2");
    }
}
