using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rhythm : MonoBehaviour
{
    AudioSource musicSource;
    [SerializeField] GameObject beatOrb;
    [SerializeField] GameObject dangerOrb;

    [SerializeField] int BPM = 60;
    [SerializeField] float speed = 60;
    [SerializeField] float firstBeatOffset;
    public float songPosBeat;
    float songPosSec;
    float dspTimeSong;
    float secPerBeat;
    int lastBeat;
    int health = 3;

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

        if (songPosBeat >= lastBeat + 1f && songPosBeat <= 58)
        {
            lastBeat++;
            int dangerOrbChance = Random.Range(1, 5);

            Debug.Log(dangerOrbChance);

            if (dangerOrbChance < 4)
            {
                var orbInstance = SpawnOrb(beatOrb);
                orbInstance.GetComponent<BeatOrb>().orb = BeatOrb.orbTypes.beat;
            }
            else
            {
                var orbInstance = SpawnOrb(dangerOrb);
                orbInstance.GetComponent<BeatOrb>().orb = BeatOrb.orbTypes.danger;
            }
        }
        else if (songPosBeat >= 62)
        {
            WinState();
        }
    }

    GameObject SpawnOrb(GameObject orbType)
    {
        var orb = Instantiate(orbType, new Vector2(-5, transform.position.y), Quaternion.identity);
        var orbCS = orb.GetComponent<BeatOrb>();
        orbCS.targetPos = (Vector2)transform.position;
        orbCS.thisBeat = songPosBeat;
        orbCS.rhythmCS = this;
        orbCS.speed = speed;

        return orb;
    }

    private void WinState()
    {
        Debug.Log("cool, you won <3");
    }

    public void RemoveHealth()
    {
        health--;

        if(health <= 0)
        {
            Debug.Log("skill diff");
        }
    }
}
