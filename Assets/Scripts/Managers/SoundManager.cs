using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public static class SoundManager
{
    // Put names of sounds here with comma afterwards ex: ass,
    public enum Sound
    {

    }

    public static void PlaySound(Sound sound)
    {
        GameObject soundGameObject = new GameObject("Sound");
        AudioSource aS = soundGameObject.AddComponent<AudioSource>();
        aS.outputAudioMixerGroup = (Resources.Load("MainMixer") as AudioMixer).FindMatchingGroups("SFX")[0];
        aS.PlayOneShot(GetAudioClip(sound));
    }

    private static AudioClip GetAudioClip(Sound sound)
    {
        foreach(GameAssets.SoundAudioClip soundAudioClip in GameAssets.i.soundAudioClipArray)
        {
            if (soundAudioClip.sound == sound)
            {
                return soundAudioClip.audioClip;
            }
        }
        Debug.LogError("Sound " + sound + " not found!");
        return null;      
    }
}
