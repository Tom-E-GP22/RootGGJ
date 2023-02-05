using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class themeSongCS : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
