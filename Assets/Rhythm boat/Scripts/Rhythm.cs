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
            lastBeat++;
            var r_Orb = Instantiate(beatOrb, new Vector2(5, transform.position.y), Quaternion.identity);
            var r_OrbCS = r_Orb.GetComponent<beatOrb>();
            r_OrbCS.targetPos = transform.position;
            r_OrbCS.thisBeat = songPosBeat;
            r_OrbCS.rhythmCS = this;

            var l_Orb = Instantiate(beatOrb, new Vector2(-5, transform.position.y), Quaternion.identity);
            var l_OrbCS = l_Orb.GetComponent<beatOrb>();
            l_OrbCS.targetPos = transform.position;
            l_OrbCS.thisBeat = songPosBeat;
            l_OrbCS.rhythmCS = this;

        }
    }
}
