using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhythm : MonoBehaviour
{
    AudioSource musicSource;

    [SerializeField] int BPM = 60;
    [SerializeField] float firstBeatOffset;
    float songPosBeat;
    float songPosSec;
    float dspTimeSong;
    float secPerBeat;
    int lastBeat;

    void Start()
    {
        musicSource = GetComponent<AudioSource>();

        secPerBeat = 60f / BPM;

        dspTimeSong = (float)AudioSettings.dspTime;

        musicSource.Play();
    }

    void Update()
    {
        songPosSec = (float)(AudioSettings.dspTime - dspTimeSong - firstBeatOffset);

        songPosBeat = songPosSec / secPerBeat;

        if(songPosBeat >= lastBeat +1f)
        {
            lastBeat++;
            Debug.Log("untz");
        }
    }
}
