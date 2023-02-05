using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class themeSongCS : MonoBehaviour
{
    themeSongCS[] musicPlayer;

    private void Awake()
    {
        musicPlayer = FindObjectsOfType<themeSongCS>();
        if(musicPlayer.Length > 1)
            Destroy(musicPlayer[1]);

        DontDestroyOnLoad(gameObject);
    }
}
