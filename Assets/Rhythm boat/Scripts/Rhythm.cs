using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhythm : MonoBehaviour
{
    AudioSource musicSource;
    [SerializeField] GameObject beatOrb;

    [SerializeField] int BPM = 60;
    [SerializeField] float firstBeatOffset;
    public float songPosBeat;
    float songPosSec;
    float dspTimeSong;
    float secPerBeat;
    int lastBeat;

    float[] notes;
    int nextIndex = 0;

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
            Debug.Log("beat");
            lastBeat++;
            var orb = Instantiate(beatOrb, new Vector2(-5, transform.position.y), Quaternion.identity);
            var orbCS = orb.GetComponent<beatOrb>();
            orbCS.targetPos = transform.position;
            orbCS.thisBeat = songPosBeat;
            orbCS.rhythmCS = this;
        }
    }
}
