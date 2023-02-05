using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class themeSongCS : MonoBehaviour
{
    themeSongCS[] musicPlayer;

    private void Awake()
    {
        musicPlayer = FindObjectsOfType<themeSongCS>();
        if(musicPlayer.Length > 1)
            Destroy(musicPlayer[1]);

        var sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Overworld" || sceneName == "MainMenu")
            GetComponent<AudioSource>().Play();
        else
            GetComponent<AudioSource>().Stop();


        DontDestroyOnLoad(gameObject);
    }
}
