using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearKey : MonoBehaviour
{
    [Tooltip("Make sure this is the same key as in OverworldHandler.cs")]
    public void DeleteKey(string key)
    {
        PlayerPrefs.DeleteKey(key);
    }
}
