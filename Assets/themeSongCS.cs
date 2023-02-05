using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class themeSongCS : MonoBehaviour
{
    private void Awake()
    {
        var sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "Overworld" || sceneName == "MainMenu")
            GetComponent<AudioSource>().Play();
        else
            GetComponent<AudioSource>().Stop();


        DontDestroyOnLoad(gameObject);
    }
}
